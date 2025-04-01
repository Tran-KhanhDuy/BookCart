using BookCart.Models;
using Humanizer;
using PayPal.Core;
using PayPal.v1.Payments;
using System.Net;
namespace BookCart.Service
{
    public class PayPalService : IPayPalService
    {
        private readonly IConfiguration _configuration;
        private const double ExchangeRate = 22_863.0;

        public PayPalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static double ConvertVndToDollar(decimal vnd)
        {
            var total = Math.Round((double)vnd / ExchangeRate, 2);
            return total;
        }

        public async Task<string> CreatePayment(PaymentInformation model, HttpContext context)
        {
            var envSandbox = new SandboxEnvironment(_configuration["Paypal:ClientId"], _configuration["Paypal:SecretKey"]);
            var client = new PayPalHttpClient(envSandbox);
            var paypalOrderId = DateTime.Now.Ticks;
            var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"];
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Amount = new Amount()
                        {
                            Total =ConvertVndToDollar(model.Amount).ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = ConvertVndToDollar(model.Amount).ToString()
                            }
                        }
                        ,
                            ItemList = new ItemList()
                    {
                        Items = new List<Item>()
                        {
                            Name = " | Order: " + model.Description,Currency = "USD",
                            Price = ConvertVndToDollar(model.Amount).ToString(),
                            ShowQuantityAs =1.ToString(),
                            Sku= "0",
                            urlCallBack = "https://localhost:7250"


                        }
                    },
                        Description = $"Invoice # {
                            model.Description }",
                        InvoiceNumber =paypalOrderId.ToString()
                    }

                },
                RedirectUrls = new RedirectUrls()
                {
                    ReturnUrl = $"{urlCallBack}?payment_method=PayPal&success=1& order_id{paypalOrderId}",
                    CancelUrl = $"{urlCallBack}?payment_method=PayPal&success=0& order_id{paypalOrderId}"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };
            var request = new PaymentCreateRequest();
            request.RequestBody(payment);

            var paymentUrl = "";
            var response = await client.Execute(request);
            var statusCode = response.StatusCode;

            if (statusCode is not (HttpStatusCode.Accepted or HttpStatusCode.OK or HttpStatusCode.Created))
                return paymentUrl;

            var result = response.Result<Payment>();
            using var links = result.Links.GetEnumerator();
            while (links.MoveNext())
            {
                var lnk = links.Current;
                if (lnk == null) continue;
                if (!lnk.Rel.ToLower().Trim().Equals("approval_url")) continue;
                paymentUrl = lnk.Href;
            }

            return paymentUrl;
        }
        public PaymentResponse PaymentExecute(IQueryCollection collections)
        {
            var response = new PaymentResponse();

            foreach (var (key, value) in collections)
            {
                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("order_description"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("transaction_id"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("order_id"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("payment_method"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("success"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("paymentid"))
                {
                    response.OrderDescription = value;
                }

                if (!string.IsNullOrEmpty(key) && key.ToLower().Equals("payerid"))
                {
                    response.OrderDescription = value;
                }

                return response;
            }
        }
    }
}

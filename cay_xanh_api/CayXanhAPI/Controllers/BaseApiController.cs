using CayXanhAPI.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private const string authUrl = "https://user.thuathienhue.gov.vn/";
        //private const string authUrl = "https://demouser.thuathienhue.gov.vn/";
        private const string authCitizenUrl = "https://tuongtac.thuathienhue.gov.vn/";
        //private UserInfo _userInfo;
        //private UserInfo _user;
        private bool _IsValid;
        private int _userCount;
        private string AuthenticationType;
        private static readonly Encoding TextEncoder = Encoding.UTF8;
        private static readonly HashAlgorithm Hasher = SHA384.Create();
        private const int ClockSkew = 5; // in minutes; default for clock skew
        private const int SessionTokenTtl = 60; // in minutes = 1 hour
        private const int RenewalTokenTtl = 14; // in days = 2 weeks
        private const string SessionClaimType = "sid";

        //private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(BaseServiceController));
        public const string AuthScheme = "Bearer";
        public string SchemeType => "JWT";

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }

        protected string VerifyUserFromToken(HttpRequest Request)
        {

            var re = Request;
            var headers = re.Headers;
            string token = string.Empty;

            string appCode = string.Empty;
            if (headers.ContainsKey("token"))
            {
                token = Request.Headers.FirstOrDefault(x => x.Key == "token").Value.FirstOrDefault();
            }

            //token = "8E-B9-49-56-83-D3-13-6B-DE-A8-E7-9F-39-9E-18-25-08-0C-20-19";
            if (!string.IsNullOrEmpty(token))
            {
                //token = "hienta.ttcntt";
                // thực hiện kiểm tra token xem có đúng giá trị trả về hay không?
                HttpClient client = new HttpClient();
                string url = string.Empty;
                if (appCode.Equals("HueS"))
                {
                    client.BaseAddress = new Uri(authCitizenUrl);
                    url = "dichvu/AuthenToken/Validate";
                }
                else
                {
                    client.BaseAddress = new Uri(authUrl);
                    url = "api/AuthenToken/Validate";
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("token", token.ToString());
                //ServicePointManager.Expect100Continue = true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                //       | SecurityProtocolType.Tls11
                //       | SecurityProtocolType.Tls12
                //       | SecurityProtocolType.Ssl3;
                HttpResponseMessage response = client.GetAsync(url).Result;
                string value = "";
                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        Task<string> result = content.ReadAsStringAsync();
                        value = result.Result;
                        if (value != "")
                        {
                            JObject o = JObject.Parse(value);
                            bool sucessToken = (bool)o["Success"];
                            if (sucessToken)
                            {
                                string username = "";
                                username = (string)o["Token"];
                                return username;
                            }
                            else
                                return null;// Request.CreateResponse(HttpStatusCode.OK, new ErrorCode() { Id = "1", Message = "Token của bạn không hợp lệ!" }, "application/json");
                        }
                        return null;// Request.CreateResponse(HttpStatusCode.OK, "");
                    }
                }
                else
                    return null;// Request.CreateResponse(HttpStatusCode.OK, new ErrorCode() { Id = "2", Message = "" }, "application/json");
            }
            else
                return null;// Request.CreateRe
        }
    }
}

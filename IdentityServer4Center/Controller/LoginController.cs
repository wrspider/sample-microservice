using Auth.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private IConfiguration configuration;
        public LoginController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpPost]
        public async Task<ActionResult> RequestToken([FromBody] LoginRequestParam model)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["client_id"] = model.ClientId;
            dict["client_secret"] = configuration[$"IdentityClients:{model.ClientId}:ClientSecret"];
            dict["grant_type"] = configuration[$"IdentityClients:{model.ClientId}:GrantType"];
            dict["username"] = model.username;
            dict["password"] = model.password;

            using (HttpClient http = new HttpClient())
            using (var content = new FormUrlEncodedContent(dict))
            {
                var msg = await http.PostAsync(configuration["IdentityService:TokenUri"], content);
                if (!msg.IsSuccessStatusCode)
                {
                    return StatusCode(Convert.ToInt32(msg.StatusCode));
                }

                string result = await msg.Content.ReadAsStringAsync();
                return Content(result, "application/json");
            }
        }
    }
}

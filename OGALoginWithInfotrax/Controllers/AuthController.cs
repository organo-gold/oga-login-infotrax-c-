
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace OGALoginWithInfotrax.Controllers
{
    [Route("api/auth")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : Controller
    {
        public AuthController() { _client = new HttpClient(); }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<string>> Post(string username, string password)
        {
            string serializedObject = "";
            await _client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(string.Format($"{LOGIN_API}", API_KEY, password, username)),
                Method = HttpMethod.Get
            }).ContinueWith((Response) =>
            {
                var jsonTask = Response.Result.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<dynamic>(jsonTask.Result);
                if (model != null) serializedObject = JsonConvert.SerializeObject(model);
            });
            AddResponseHeaders();
            return !string.IsNullOrEmpty(serializedObject)?serializedObject:"{\"MESSAGE\":\"Login Error\",\"DETAIL\":\"Invalid user\",\"TIMESTAMP\":\""+DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")+"\",\"ERRORCODE\":\"902\"}";
        }

        [HttpPost]
        [Route("postcheckuser")]
        public async Task<ActionResult<string>> PostCheckUser(string token)
        {
            string serializedObject = "";
            await _client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(string.Format($"{USER_DETAIL_API}", token, API_KEY, DIST_ID)),
                Method = HttpMethod.Get
            }).ContinueWith((Response) => {
                var json = Response.Result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(json.Result);
                if (data != null) serializedObject = JsonConvert.SerializeObject(data);
            });
            AddResponseHeaders();
            return !string.IsNullOrEmpty(serializedObject)?serializedObject:"{\"MESSAGE\":\"Validation Error\",\"DETAIL\":\"Not Authorized to run this service\",\"TIMESTAMP\":\""+DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")+"\",\"ERRORCODE\":\"904\"}";
        }

        private void AddResponseHeaders()=> Response.Headers.Add("Access-Control-Allow-Origin", new string[] { "https://www.myogacademy.com", "https://ogacademystg.wpengine.com" });

        const string API_KEY = "O3962162";
        const string DIST_ID = "1000101";
        const string LOGIN_API = "http://organogold-dts.myvoffice.com/organogold/index.cfm?service=Session.login&apikey={0}&DTSPASSWORD={1}&DTSUSERID={2}&format=json";
        const string USER_DETAIL_API = "http://organogold-dts.myvoffice.com/organogold/index.cfm?jsessionid={0}&service=Genealogy.distInfoBySavedQuery&apikey={1}&QRYID=DistConfData&DISTID={2}&APPNAME=Admin&GROUP=Reports&format=JSON&fwreturnlog=1";
        readonly HttpClient _client;
    }
}
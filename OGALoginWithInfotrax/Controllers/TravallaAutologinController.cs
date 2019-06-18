
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using OGALoginWithInfotrax.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace OGALoginWithInfotrax.Controllers
{
    //[Route("api/autologin")]
    //public class TravallaAutologinController : Controller
    //{
    //    OrganoSettings organoSettings;
    //    public TravallaAutologinController(IOptions<OrganoSettings> settings) 
    //    { 
    //        _client = new HttpClient(); 
    //        organoSettings = settings.Value;
    //    }
        
    //    //// GET api/values
    //    //[HttpGet]
    //    //[Route("get")]
    //    //public ActionResult<string> Get()
    //    //{
    //    //    Response.Headers.Add("Origin", "*");
    //    //    Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //    //    return "Nothing to show (autologin)";
    //    //}

    //    [HttpPost]
    //    [Route("post")]
    //    public async Task<HttpResponseMessage> Post(string username, string password)
    //    {
    //        string serializedObject = "",url=string.Format($"{LOGIN_API}", ORGANIZATION_ID, password, username);
    //        string token = "", location = "";
    //        List<KeyValuePair<string, IEnumerable<string>>> headers = new List<KeyValuePair<string, IEnumerable<string>>>();
    //        HttpResponseHeaders header;

    //        HttpResponseMessage message=new HttpResponseMessage();
    //        await _client.SendAsync(new HttpRequestMessage()
    //        {
    //            RequestUri = new Uri(url),
    //            Method = HttpMethod.Post
    //        }).ContinueWith((Response) =>
    //        {
    //            message = Response.Result;
    //            //headers = Response.Result.Headers.ToList();
    //            //if (Response.Result.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> result))
    //            //{
    //            //    var values = result.First().ToString().Split(";");
    //            //    token = values[0].Replace("PHPSESSID=", "");
    //            //}

    //            //if (Response.Result.Headers.TryGetValues("Location", out IEnumerable<string> loc))
    //            //{
    //            //    location = loc.First().ToString();
    //            //}
    //        });
    //        AddResponseHeaders();
    //        //foreach (var h in headers)
    //        //{
    //        //    Response.Headers.Add(h.Key, new string[] { h.Value.ToString() });
    //        //}
    //        //Response.Redirect(location, true);
    //        return message;
    //        //return !string.IsNullOrEmpty(serializedObject) ? serializedObject : "{\"MESSAGE\":\"Login Error\",\"DETAIL\":\"Invalid user\",\"TIMESTAMP\":\"" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "\",\"ERRORCODE\":\"902\"}";
    //    }

    //    private void AddResponseHeaders()
    //    {
    //        Response.Headers.Add("Origin", "*");
    //        Response.Headers.Add("Access-Control-Allow-Origin", new string[] { organoSettings.TravallaAllowedOrigin });
    //    }

    //    const string ORGANIZATION_ID = "547";
    //    const string LOGIN_API = "https://foreverweeks.com/landing?_action=login&_organizationsID={0}&user={1}&password={2}";
    //    readonly HttpClient _client;
    //}
}
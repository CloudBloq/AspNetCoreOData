using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreOData.ClientMS.Models;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreOData.ClientMS;

namespace AspNetCoreOData.ClientMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.GetTokenAsync("access_token").Result;

            //Default.Container container = new Default.Container(new Uri("https://localhost:44345/odata"));
            //var item = container.Person.Count();

            //var client = new ODataClient(SetODataToken("https://localhost:44345/odata", accessToken));
            //var client = new ODataClient("https://localhost:44345/odata");

            //var persons = await client.For<Person>()
            //        .Expand(rr => rr.EmailAddress)
            //        .Top(7).Skip(7)
            //        .FindEntriesAsync();

            return View();
        }

        //private ODataClientSettings SetODataToken(string url, string accessToken)
        //{
        //    var oDataClientSettings = new ODataClientSettings(new Uri(url));
        //    oDataClientSettings.BeforeRequest += delegate (HttpRequestMessage message)
        //    {
        //        message.Headers.Add("Authorization", "Bearer " + accessToken);
        //    };

        //    return oDataClientSettings;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[] { "Cookies", "OpenIdConnect" });
        }
    }
}

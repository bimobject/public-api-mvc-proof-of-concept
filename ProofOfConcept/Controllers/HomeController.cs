using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProofOfConcept.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ProofOfConcept.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var getJsonObject = ApiHandler.GetAllProducts();
            return View(getJsonObject);
        }

        [HttpGet]
        public IActionResult Products()
        {
            var getJsonObject = ApiHandler.GetAllProducts();
            return View(getJsonObject);
        }

        [HttpGet]
        public IActionResult Details(string id, string token)
        {
            var getJsonObject = ApiHandler.GetProductsDetails(id);

            return View(getJsonObject);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Brands()
        {
            var getJsonObject = ApiHandler.GetProductsDetailsBrands();
            return View(getJsonObject);
        }

        [HttpGet]
        public IActionResult BrandsProducts(string id)
        {
            var getJsonObject = ApiHandler.GetProductsDetailsBrands(id);
            return View(getJsonObject);
        }

        [HttpGet]
        public async Task<IActionResult> GetFile(string productId, string fileId, string fileName)
        {
            //var clientId2 = ApiHandler.Configuration["clientInfo:clientId2"];
            //var redirectUri = ApiHandler.Configuration["baseUrls:redirectUri"];
            //var authUrl = ApiHandler.Configuration["baseUrls:authUrl"];
            //var url = $"{authUrl}?client_id={clientId2}&response_type=code&redirect_uri={redirectUri}&scope=search_api search_api_downloadbinary offline_access&state={productId}_{fileId}";
            
            if (Request.Cookies["access_token"] == null)
            {
                return RedirectToAction(nameof(LoginAuth));
            }

            var token = Request.Cookies["access_token"];
            var response = await ApiHandler.GetDownloadRequest(productId, fileId, token);
            var statusCode = response.StatusCode;

            if (statusCode != HttpStatusCode.Unauthorized)
                return File(await response.Content.ReadAsByteArrayAsync(), "application/octet-stream", fileName);

            var refreshToken = Request.Cookies["refresh_token"];
            var refreshResponse = ApiHandler.ReAuthorize(refreshToken).Result;
            var details = JObject.Parse(refreshResponse).ToObject<DownloadToken>();

            response = ApiHandler.GetDownloadRequest(productId, fileId, details.access_token).Result;
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(int.Parse(details.expires_in))
            };

            Response.Cookies.Append("access_token", details.access_token, options);
            Response.Cookies.Append("refresh_token", details.refresh_token, options);
            Response.Cookies.Append("token_type", details.token_type, options);

            return File(await response.Content.ReadAsByteArrayAsync(), "application/octet-stream", fileName);
        }

        [HttpGet]
        public IActionResult LoginAuth(string id, string token, string productId, string fileId)
        {
            var data = ApiHandler.RedirectAndDownload(id, productId, fileId);

            return View(data);
        }

    }
}
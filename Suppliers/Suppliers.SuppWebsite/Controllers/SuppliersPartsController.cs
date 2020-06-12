using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MC.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MC.Website.Controllers
{
    public class SuppliersPartsController : Controller
    {
        private const string JSON_MEDIA_TYPE = "application/json";
        private const string AUTHORIZATION_HEADER_NAME = "Authorization";
        private readonly Uri tokenUri = new Uri("https://localhost:44377/api/login");
        private readonly Uri supplierspartsUri = new Uri("https://localhost:44377/api/suppliers");
        private readonly Uri partsUri = new Uri("https://localhost:44377/api/parts");
        private readonly Uri suppliersUri = new Uri("https://localhost:44377/api/Suppliers");

        // GET: suppliers
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync(supplierspartsUri);

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<IEnumerable<supplierViewModel>>(jsonResponse);

                return View(responseData);
            }
        }

        // GET: suppliers/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{supplierspartsUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<supplierViewModel>(jsonResponse);

                return View(responseData);
            }
        }

        // GET: suppliers/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.parts = await GetpartsDropdownItemsAsync();
            ViewBag.Suppliers = await GetSuppliersDropdownItemsAsync();

            return View();
        }

        // POST: suppliers/Create
        [HttpPost]
        public async Task<ActionResult> Create(supplierViewModel supplier)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    var serializedContent = JsonConvert.SerializeObject(supplier);
                    var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                    HttpResponseMessage response = await client.PostAsync(supplierspartsUri, stringContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: suppliers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{supplierspartsUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<supplierViewModel>(jsonResponse);

                ViewBag.parts = await GetpartsDropdownItemsAsync();
                ViewBag.Suppliers = await GetSuppliersDropdownItemsAsync();

                return View(responseData);
            }
        }

        // POST: suppliers/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, supplierViewModel supplier)
        {
            supplier.Id = id;

            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    var serializedContent = JsonConvert.SerializeObject(supplier);
                    var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                    HttpResponseMessage response = await client.PutAsync($"{supplierspartsUri}/{id}", stringContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: suppliers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{supplierspartsUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<supplierViewModel>(jsonResponse);

                return View(responseData);
            }
        }

        // POST: suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    HttpResponseMessage response = await client.DeleteAsync($"{supplierspartsUri}/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }


        private async Task<IEnumerable<SelectListItem>> GetpartsDropdownItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage partsResponse = await client.GetAsync(partsUri);

                if (!partsResponse.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<SelectListItem>();
                }

                string partsJsonResponse = await partsResponse.Content.ReadAsStringAsync();

                var parts = JsonConvert.DeserializeObject<IEnumerable<GenreViewModel>>(partsJsonResponse);

                return parts.Select(genre => new SelectListItem(genre.Name, genre.Id.ToString()));
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetSuppliersDropdownItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage SuppliersResponse = await client.GetAsync(suppliersUri);

                if (!SuppliersResponse.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<SelectListItem>();
                }

                string SuppliersJsonResponse = await SuppliersResponse.Content.ReadAsStringAsync();

                var Suppliers = JsonConvert.DeserializeObject<IEnumerable<DirectorViewModel>>(SuppliersJsonResponse);

                return Suppliers.Select(director => new SelectListItem($"{director.FirstName} {director.LastName}", director.Id.ToString()));
            }
        }

        private async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var serializedContent = JsonConvert.SerializeObject(new { Username = "test1Username", Password = "test1Password" });
                var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                HttpResponseMessage response = await client.PostAsync(tokenUri, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return $"Bearer {await response.Content.ReadAsStringAsync()}";
            }
        }
    }
}
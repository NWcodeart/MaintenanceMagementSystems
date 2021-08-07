using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.MVC.Controllers
{
    public class BeneficiaryController : Controller
    {
        public static string baseUrl = "http://localhost:16982/api/BeneficiaryEntry/";

        public IActionResult Signup()
        {
            return View();
        }

        public async Task<IActionResult> Register(BeneficiaryRegistration RegisterInfo)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(RegisterInfo), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(baseUrl + "Register", stringContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        TempData["SignupError"] = error;
                        return RedirectToAction("Signup");
                    }

                }
                
                return RedirectToAction("Signin");

            }
        }

        public IActionResult Signin()
        {
            return View();
        }

        public async Task<IActionResult> Login(Login Login)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(Login), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(baseUrl + "Login", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        TempData["LoginError"] = error;
                        return RedirectToAction("Signin");
                    }

                    HttpContext.Session.SetString("Token", token);

                    var url = baseUrl + "GetRole";
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string jsonStr = await client.GetStringAsync(url);

                    HttpContext.Session.SetString("Role", jsonStr);
                    var Role = HttpContext.Session.GetString("Role");


                    return RedirectToAction("Profile", "Beneficiary");


                }
            }
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Beneficiary");
        }

        

    }
}

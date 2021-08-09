﻿using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using MaintenanceManagementSystem.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.MVC.Controllers
{
    public class BeneficiaryController : Controller
    {
        public static string baseUrl = "http://localhost:16982/api/BeneficiaryEntry/";

        public async Task<IActionResult> Signup()
        {
            var buildingsList = await ListBuildings();
            var floorsList = await ListFloors();
            SelectList buildingsSelectList = new SelectList(buildingsList, "Id", "Number");
            SelectList floorsSelectList = new SelectList(floorsList, "Id", "Number");
            ViewBag.buildingsList = buildingsSelectList;
            ViewBag.floorsList = floorsSelectList;

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
        
        [HttpGet]
        public async Task<List<Building>> ListBuildings()
        {
            var accessToken = HttpContext.Session.GetString("Token");
            var url = baseUrl + "ListBuildings";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync(url);
            var res = JsonConvert.DeserializeObject<List<Building>>(jsonStr).ToList();
            return res;
        }

        [HttpGet]
        public async Task<List<Floor>> ListFloors()
        {
            var accessToken = HttpContext.Session.GetString("Token");
            var url = baseUrl + "ListFloors";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync(url);
            var res = JsonConvert.DeserializeObject<List<Floor>>(jsonStr).ToList();
            return res;
        }

        public IActionResult NewTicket()
        {
            return View();
        }

        public async Task<IActionResult> RequestNewTicket(NewTicket ticket)
        {
            using (var httpClient = new HttpClient())
            {
                var accessToken = HttpContext.Session.GetString("Token");
                var url = baseUrl + "SubmitRequest";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                string uniqueFileName = null;

                if (ticket.Attachment != null)
                {
                    var dirPath = Assembly.GetExecutingAssembly().Location;
                    dirPath = Path.GetDirectoryName(dirPath);
                    var path = Path.GetFullPath(Path.Combine(dirPath, @"C:\Users\maimu\Source\Repos\NWcodeart\MaintenanceMagementSystems\MaintenanceMagementSystems.Database\TicketRequestsAttachments"));

                    string uploadsFolder = Path.Combine(path);

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + ticket.Attachment.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ticket.Attachment.CopyTo(fileStream);
                    }
                }

                ticket.Ticket.Picture = uniqueFileName;

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(ticket.Ticket), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, stringContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        TempData["NewTicketError"] = error;
                        return RedirectToAction("NewTicket");
                    }

                }
            }

            TempData["NewTicketConfirmation"] = "Your ticket has been sent successfully";
            return RedirectToAction("NewTicket");
        }
    }
}

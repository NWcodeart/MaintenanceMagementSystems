﻿using MaintenanceManagementSystem.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.MVC.Models
{
    public class NewTicket
    {
        public Ticket Ticket { get; set; }

        [BindProperty]
        public IFormFile Attachment { get; set; }
    }
}

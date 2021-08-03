﻿using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.ManyToMany
{
    public class BackOfficesTickets
    {
        public int TicketId { get; set; }
        public Ticket ticket { get; set; }

        public int BackOfficeId { get; set; }
        public User user { get; set; }
    }
}

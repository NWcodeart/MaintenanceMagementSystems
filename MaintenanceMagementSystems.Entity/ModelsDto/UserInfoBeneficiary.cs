﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class UserInfoBeneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int UserRoleId { get; set; }

        public string userRole { get; set; }


        //user location section
        public int? FloorId { get; set; }

        public char floorNumber { get; set; }

        public int BuildingId { get; set; }
        public char buildingNumber { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}

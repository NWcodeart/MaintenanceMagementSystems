using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ManyToManyDto
{
    public class BackOfficesTicketsDto
    {
        public int TicketId { get; set; }
        public TicketDto ticket { get; set; }

        public int BackOfficeId { get; set; }
        public UserDto user { get; set; }
    }
}

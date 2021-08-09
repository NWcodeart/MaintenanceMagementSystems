using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ManyToManyDto
{
    public class UserTicketsDto
    {
        public int TicketId { get; set; }
        public TicketDto ticket { get; set; }

        public int UserId { get; set; }
        public UserDto user { get; set; }
    }
}

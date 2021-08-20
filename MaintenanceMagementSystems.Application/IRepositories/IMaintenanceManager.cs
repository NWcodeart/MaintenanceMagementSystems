using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IMaintenanceManager
    {
        /*
         Can define the maintenance team and their role in the physical work as follow: 1) 
         plumbing team, 2) electrical team, 3) heating and air conditioning team, security 
         and safety, Network and infrastructure team and cleaning and general repairing 
         team
         */

        /*
         Can define the maintenance tools classifications such as: Preventive 
         Maintenance, Condition-Based Maintenance, Predictive Maintenance, Corrective 
         Maintenance, Predetermined Maintenanc
         */

        /*
         Receive maintenance request (ticket) from building manager as has the option to 
         either accept it or reject it.
         */

        /*
         If he accepts the maintenance request, he can assign the maintenance team to 
         this request and notify the beneficiary with the approval for the ticket also, notify 
         the workers that they have a pending request.
         If he rejected the maintenance request (ticket) a notification should be sent to the 
         beneficiary and building manager with the rejection reason.
         Can see the maintenance work schedule on a calendar.
         Can see the availability of the worker in case if the worker was assigned to 
         another request, he cannot assign him to until he is free.
         Can print the work request as a paper.
         */

        /*
         maintenance manager can access all tickets on the system.
         */
        public List<User> ListOfWorkers(int TicketId);
        public List<Ticket> ListNewTickets();
        public Ticket GetTicket(int TicketId);
        public User GetWorker(int WorkerId, int TicketId);
        public bool RespondToTicket(int TicketId, TicketRespond respond);
        public List<TicketDto> ViewTickets();
        public List<TicketDto> ViewUnderReviewTickets();
        public List<MaintenanceType> ViewMainteneceType();
        public bool DeleteMainteneceType(MaintenanceType DeletedType);
        public bool UpdateMainteneceType(MaintenanceType UpdatedType);
        public bool AddMainteneceType(MaintenanceType NewType);
    }
}

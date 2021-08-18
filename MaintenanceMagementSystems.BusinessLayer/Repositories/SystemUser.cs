using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Application.IRepositories;
using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class SystemUser : ISystemUser
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;
        public SystemUser(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;
        }
        public bool UpdateUser(User UpdatedUser)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User user = _maintenanceSysContext.Users.Where(u => u.Id == _backOfficeEntry.GetUserId()).FirstOrDefault();

                    if(user != null)
                      {
                        user.Name = UpdatedUser.Name;
                        user.Phone = UpdatedUser.Phone;
                        user.Email = UpdatedUser.Email;
                        user.floor = UpdatedUser.floor;
                        user.building = UpdatedUser.building;
                        user.Password = UpdatedUser.Password;
                        return true;
                       }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public bool SendEmail(string email)
        {

            try
            {
                User user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == email);


            Guid TempPassword = Guid.NewGuid();
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("aminahahmed1999@gmail.com");
            msg.To.Add(email);
            msg.Subject = "Your temporarily password";
            msg.Body = Convert.ToString(TempPassword);

            user.TemporaryPassword = TempPassword;
            _maintenanceSysContext.SaveChanges();



                using (SmtpClient client = new SmtpClient())
            {
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("aminahahmed1999@gmail.com", "aa123456788");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
            return true;
             }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(Guid tempPassword, string newPassword)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User user = _maintenanceSysContext.Users.FirstOrDefault(u => u.TemporaryPassword == tempPassword);
                    if(user != null)
                    {
                        user.Password = newPassword;
                        _maintenanceSysContext.SaveChanges();
                        return true;
                    }
                    return false;
                  
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

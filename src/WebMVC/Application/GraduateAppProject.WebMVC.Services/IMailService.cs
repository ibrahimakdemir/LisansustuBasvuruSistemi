using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Services
{
    public interface IMailService
    {
        Task SaveMailAsync(CreateNewMailRequest request);
        Task<IList<MailDisplayResponse>> GetMailsAsync();
        IList<MailDisplayResponse> GetMails();
        Task<MailDisplayResponse> GetMailByIdAsync(int id);
        MailDisplayResponse GetMailById(int id);
        Task SaveMail(CreateNewMailRequest request);
    }
}

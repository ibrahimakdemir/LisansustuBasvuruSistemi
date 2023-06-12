using AutoMapper;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services.Extensions;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace GraduateAppProject.WebMVC.Services
{
    public class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public MailService(IMailRepository mailRepository, IMapper mapper, IConfiguration configuration)
        {
            _mailRepository = mailRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public MailDisplayResponse GetMailById(int id)
        {
            var mail = _mailRepository.Get(id);
            var response = mail.ConvertToDTO<HelpMessage, MailDisplayResponse>(_mapper);
            return response;
        }

        public async Task<MailDisplayResponse> GetMailByIdAsync(int id)
        {
            var mail = await _mailRepository.GetAsync(id);
            var response = mail.ConvertToDTO<HelpMessage, MailDisplayResponse>(_mapper);
            return response;
        }

        public IList<MailDisplayResponse> GetMails()
        {
            var mail = _mailRepository.GetAll();
            var response = mail.ConvertToDTO<IList<HelpMessage>, IList<MailDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IList<MailDisplayResponse>> GetMailsAsync()
        {
            var mail = await _mailRepository.GetAllAsync();
            var response = mail.ConvertToDTO<IList<HelpMessage>, IList<MailDisplayResponse>>(_mapper);
            return response;
        }

        public async Task SaveMailAsync(CreateNewMailRequest request)
        {
            var response = request.ConvertToDTO<CreateNewMailRequest, HelpMessage>(_mapper);
            await _mailRepository.CreateAsync(response);
        }
        public async Task SaveMail(CreateNewMailRequest request)
        {
            var response = request.ConvertToDTO<CreateNewMailRequest, HelpMessage>(_mapper);
            _mailRepository.Create(response);
        }


        //Burası iyi tasarlanmalıdır!!!!!!!!!

        //public async Task SendMailAsync(CreateNewMailRequest request)
        //{
        //    var username = _configuration["Mail:Username"];
        //    var password = _configuration["Mail:Password"];
        //    var host = _configuration["Mail:Host"];
        //    int port = Convert.ToInt32(_configuration["Mail:Port"]);

        //    MailMessage mail = new MailMessage();

        //    mail.IsBodyHtml = true;


        //    mail.To.Add("admin@gmail.com"); //Buraya admin e-mail adresi eklenmelidir.

        //    var message = string.Empty;
        //    if (request.IsRegistered)
        //    {
        //        // Get User Information to add message
        //        message = "GetUsersInformationsByUserId IN Session";
        //    }
        //    else
        //    {
        //        message = request.GuestFirstName + " " + request.GuestLastName;
        //    }

        //    mail.Subject = "Lisansüstü Başvuru Sitemi Yardım Talebi";
        //    mail.Body = request.Message;

        //    mail.From = new(username, "AKDEMİR ÜNİVERSİTESİ", System.Text.Encoding.UTF8);

        //    SmtpClient smtp = new();

        //    smtp.Credentials = new NetworkCredential(username, password);
        //    smtp.Port = port;
        //    smtp.EnableSsl = true;
        //    smtp.Host = host;
        //    await smtp.SendMailAsync(mail);
        //}
    }
}

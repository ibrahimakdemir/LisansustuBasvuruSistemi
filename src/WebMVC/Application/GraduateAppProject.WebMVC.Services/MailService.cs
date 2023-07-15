using AutoMapper;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Repositories;
using GraduateAppProject.WebMVC.Services.Extensions;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

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


        public async Task SendMailAsync(Controller controller, string mailAddress, string message, int mailId)
        {
            var username = _configuration["Mail:Username"];
            var password = _configuration["Mail:Password"];
            var host = _configuration["Mail:Host"];
            int port = Convert.ToInt32(_configuration["Mail:Port"]);

            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = true;


            mail.To.Add(mailAddress);

            mail.Subject = "Lisansüstü Başvuru Sistemi Yardım Talebi";
            string body = await RenderViewToStringAsync(controller, "_MailResponseDisplay", message);
            mail.Body = body;

            mail.From = new(username, "AKDEMİR ÜNİVERSİTESİ", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();

            smtp.Credentials = new NetworkCredential(username, password);
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.Host = host;
            await smtp.SendMailAsync(mail);

        
            await _mailRepository.UpdateByIdAsync(mailId);
        }

        public async Task<string> RenderViewToStringAsync(Controller controller, string viewName, object model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = controller.HttpContext.RequestServices };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ControllerActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewEngine = controller.HttpContext.RequestServices.GetRequiredService<ICompositeViewEngine>();
                var viewResult = viewEngine.FindView(actionContext, viewName, false);

                if (viewResult.Success)
                {
                    var tempDataDictionaryFactory = controller.HttpContext.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
                    var tempDataDictionary = tempDataDictionaryFactory.GetTempData(controller.HttpContext);

                    var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    };

                    var viewContext = new ViewContext(
                        actionContext,
                        viewResult.View,
                        viewData,
                        tempDataDictionary,
                        sw,
                        new HtmlHelperOptions()
                    );

                    await viewResult.View.RenderAsync(viewContext);
                    return sw.ToString();
                }
            }

            return string.Empty;
        }



    }
}

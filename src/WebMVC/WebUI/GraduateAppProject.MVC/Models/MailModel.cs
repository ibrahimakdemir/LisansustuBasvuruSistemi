namespace GraduateAppProject.MVC.Models
{
    public class MailModel
    {
        public string[] Receivers { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;
    }
}

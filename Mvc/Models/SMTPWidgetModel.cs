using System.ComponentModel.DataAnnotations;

namespace SitefinityWebApp.Mvc.Models
{
    public class SMTPWidgetModel
    {
        [Display(Name = "Default Sender Email Address")]
        public string DefaultSenderEmailAddress { get; set; }

        public string Domain { get; set; }

        [Display(Name = "Enable SSL")]
        public bool EnableSSL { get; set; }

        public string Host { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }
    }
}
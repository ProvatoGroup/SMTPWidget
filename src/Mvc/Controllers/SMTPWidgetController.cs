
using SitefinityWebApp.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SMTPWidget", Title = "SMTP Widget", SectionName = "Dashboard")]
    public class SMTPWidgetController : Controller
    {
        /// <summary> 
        /// This is the default Action. 
        /// </summary> 
        public ActionResult Index()
        {
            SystemConfig config = Config.Get<SystemConfig>();

            SmtpElement smtpSettings = config.SmtpSettings;

            var model = new SMTPWidgetModel
            {
                DefaultSenderEmailAddress = smtpSettings.DefaultSenderEmailAddress,
                Domain = smtpSettings.Domain,
                EnableSSL = smtpSettings.EnableSSL,
                Host = smtpSettings.Host,
                Password = smtpSettings.Password,
                Port = smtpSettings.Port,
                UserName = smtpSettings.UserName
            };

            return View(model);
        }

        //[RelativeRoute("SaveSMTPSettings")]
        [Route("SaveSMTPSettings")]
        [HttpPost]
        public ActionResult SaveSMTPSettings(SMTPWidgetModel model)
        {
            var manager = ConfigManager.GetManager();

            SystemConfig systemConfig = manager.GetSection<SystemConfig>();

            SmtpElement smtpSettings = systemConfig.SmtpSettings;

            smtpSettings.DefaultSenderEmailAddress = model.DefaultSenderEmailAddress;
            smtpSettings.Domain = model.Domain;
            smtpSettings.EnableSSL = model.EnableSSL;
            smtpSettings.Host = model.Host;
            smtpSettings.Password = model.Password;
            smtpSettings.Port = model.Port;
            smtpSettings.UserName = model.UserName;

            manager.SaveSection(systemConfig);

            return Json(true);
        }
    }
}
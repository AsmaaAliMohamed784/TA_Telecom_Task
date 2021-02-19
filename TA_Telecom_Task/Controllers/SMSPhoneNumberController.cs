using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TA_Telecom_Task.BL.Managers;
using TA_Telecom_Task.BL.ViewModels;

namespace TA_Telecom_Task.Controllers
{
    public class SMSPhoneNumberController : Controller
    {
        PhoneNumberManager _PhoneNumberManager;
        SMSPhoneNumberManager _SMSPhoneNumberManager;
        public SMSPhoneNumberController()
        {
            _PhoneNumberManager = new PhoneNumberManager();
            _SMSPhoneNumberManager = new SMSPhoneNumberManager();
        }

        // GET: SMSPhoneNumber
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                SMSPhoneNumberDTO model = new SMSPhoneNumberDTO()
                {
                    PhoneNumbers = _PhoneNumberManager.GetPhoneNumbers()
                };
                ViewBag.PhoneNumber = model.PhoneNumbers;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, SMSPhoneNumberDTO newMsg)
        {
            string[] ids = formCollection["Id"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var Message = _SMSPhoneNumberManager.Create(newMsg, int.Parse(id));
            }

            return RedirectToAction("Index");
        }

    }
}
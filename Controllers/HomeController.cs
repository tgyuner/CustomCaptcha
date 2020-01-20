using System.Web.Mvc;
using WebApplication1.Captcha;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CaptchaModel captchaModel)
        {
            if (ModelState.IsValid)
            {
                if (Session["captcha"] != null && captchaModel.Captcha == Session["captcha"].ToString())
                {
                    ModelState.AddModelError("", "Doğrulama kodunu doğru girdiniz.");
                }
                else
                {
                    ModelState.AddModelError("", "Doğrulama kodunu yanlış girdiniz.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen doğrulama kodunu boş bırakmayınız.");
            }

            return View(captchaModel);
        }

        public CaptchaResult capthaGetir()
        {
            return new CaptchaResult();
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Captcha
{
    public class CaptchaResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            Bitmap bitmap = new Bitmap(context.HttpContext.Server.MapPath("~/images/codeback.jpg"));
            Graphics graphics = Graphics.FromImage(bitmap);
            string code = GetCaptchaString();
            SolidBrush brush = new SolidBrush(Color.White);
            graphics.DrawString(code, new Font("Courier", 25, FontStyle.Bold), brush, new Point(10, 16));
            HttpResponseBase response = context.HttpContext.Response;
            bitmap.Save(response.OutputStream, ImageFormat.Gif); 
            response.ContentType = "image/jpeg";
            context.HttpContext.Session["captcha"] = code;
        }

        public string GetCaptchaString()
        {
            return new Random().Next(10000, 99999).ToString();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using QRCodeInASPNetCore.Models;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace QRCodeInASPNetCore.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {

            Payload payload = null;

            switch (model.QRCodeType)
            {
                case 1: // website url
                    payload = new Url(model.WebsiteURL);
                    break;
                case 2: // bookmark url
                    payload = new Bookmark(model.BookmarkURL, model.BookmarkURL);
                    break;
                case 3: // compose sms
                    payload = new SMS(model.SMSPhoneNumber, model.SMSBody);
                    break;
                case 4: // compose whatsapp message
                    payload = new WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMessage);
                    break;
                case 5://compose email
                    payload = new Mail(model.ReceiverEmailAddress, model.EmailSubject, model.EmailMessage);
                    break;
                case 6: // wifi qr code
                    payload = new WiFi(model.WIFIName, model.WIFIPassword, WiFi.Authentication.WPA);
                    break;

            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);

            // use this when you want to show your logo in middle of QR Code and change color of qr code
            //Bitmap logoImage = new Bitmap(@"wwwroot/img/Virat-Kohli.jpg");
            //var qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.Red, logoImage);

            string base64String = Convert.ToBase64String(BitmapToByteArray(qrCodeAsBitmap));
            model.QRImageURL = "data:image/png;base64," + base64String;
            return View("Index", model);
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}

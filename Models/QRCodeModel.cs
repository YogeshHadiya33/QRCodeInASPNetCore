using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeInASPNetCore.Models
{
    public class QRCodeModel
    {
        public int QRCodeType { get; set; }
        public string QRImageURL { get; set; }

        //for bookmark qr code
        public string BookmarkTitle { get; set; }
        public string BookmarkURL { get; set; }

        // for email qr codes
        public string ReceiverEmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailMessage { get; set; }
         

        //for sms qr codes
        public string SMSPhoneNumber { get; set; }
        public string SMSBody { get; set; }

        //for website
        public string WebsiteURL { get; set; }

        // for whatsapp qr message code
        public string WhatsAppNumber { get; set; }
        public string WhatsAppMessage { get; set; }

        // for wifi qr code
        public string WIFIName { get; set; }
        public string WIFIPassword { get; set; } 
    }


}

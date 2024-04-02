using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessStudioMobileApp.Model
{
    public class BookingRequest
    {
        public string UserId { get; set; }
        public string ClassSlot { get; set; }
        public string ReceiptUrl { get; set; }
    }
}

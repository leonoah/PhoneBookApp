using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneInv.Interface
{
    public interface IMobilePhone
    {
        public int SerialNum { get; }
        public string Model { get; }
        public bool IsAvailable { get; set; }
        public DateTime BookedAt { get; set; }
        public string BookedBy { get; set; }

        public string DisplayPhoneDetailes();
    }
 
}

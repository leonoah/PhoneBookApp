using PhoneBookApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Model
{
    public class MobilePhone : IMobilePhone
    {
        public MobilePhone(int serialNum, string model) {
            SerialNum = serialNum;
            Model = model;
        }

        public int SerialNum { get; private set; }

        public string Model { get; private set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime BookedAt { get;  set; }

        public string BookedBy { get;  set; }

        
        public virtual string DisplayPhoneDetailes()
        {
            return IsAvailable
                ? $"Phone: {Model} (S/N {SerialNum}) is available for testing"
                : $"Phone: {Model} (S/N {SerialNum}) is booked by{BookedBy} from {BookedAt} and it is not avilable for testing";
        }
    }
}

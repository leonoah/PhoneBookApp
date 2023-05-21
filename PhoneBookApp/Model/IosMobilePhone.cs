using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Model
{
    public class IosMobilePhone : MobilePhone
    {
        public IosMobilePhone(int serialNum, string model, string subModel, string iosVersion):base(serialNum, model)
        {
            SubModel = subModel;
            IosVersion = iosVersion;
        }
        public string SubModel { get; private set; }
        public string IosVersion { get; private set; }

        public override string DisplayPhoneDetailes()
        {
            return IsAvailable
             ? $"Phone: {Model}: {SubModel}  (S/N {SerialNum}, ver:{IosVersion}) is available for testing"
             : $"Phone: {Model}  {SubModel}  (S/N {SerialNum}, ver:{IosVersion}) is booked by{BookedBy} from {BookedAt} and it is not avilable for testing";
        }
    }
}

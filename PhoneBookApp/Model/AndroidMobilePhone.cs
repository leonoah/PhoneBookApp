using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Model
{
    public class AndroidMobilePhone : MobilePhone
    {
        public AndroidMobilePhone(int serialNum, string model, string subModel, string andVersion) :base(serialNum, model)
        {
            SubModel = subModel;
            AndroidVersion = andVersion;
        }
        public string SubModel { get; private set; }
        public string AndroidVersion { get; private set; }

        public override string DisplayPhoneDetailes()
        {
            return IsAvailable
             ? $"Phone: {Model}: {SubModel}  (S/N {SerialNum}, ver:{AndroidVersion}) is available for testing"
             : $"Phone: {Model}  {SubModel}  (S/N {SerialNum}, ver:{AndroidVersion}) is booked by{BookedBy} from {BookedAt} and it is not avilable for testing";
        }
    }
}

using PhoneBookApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Bl
{
    public class MobilePhoneBookAppentory
    {
        private readonly object lockObject = new object();
        public MobilePhoneBookAppentory()
        {
            Phones = new Dictionary<int, IMobilePhone > ();
        }

        public Dictionary<int, IMobilePhone> Phones { get; private set; }

        // Register new phone
        public bool AddPhone(IMobilePhone phone)
        {
            bool res = false;
             lock (lockObject)
            {
                if (Phones.ContainsKey(phone.SerialNum) == false)
                {                 
                    Phones.Add(phone.SerialNum, phone);
                    res = true;
                }
            }

            return res;
        }

        // Remove new phone
        public bool RemovePhone(IMobilePhone phone)
        {
            bool res = false;
             lock (lockObject)
            {
                if (Phones.ContainsKey(phone.SerialNum))
                {
                    Phones.Remove(phone.SerialNum);
                    res = true;
                }                
            }

            return res;
        }

        // Check that phone exist
        public bool IsPhoneExist(int serialNumber) { return Phones.ContainsKey(serialNumber); }
    }

    
}

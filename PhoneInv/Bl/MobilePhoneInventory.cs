using PhoneInv.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneInv.Bl
{
    public class MobilePhoneInventory
    {
        private readonly object lockObject = new object();
        public MobilePhoneInventory()
        {
            Phones = new Dictionary<int, IMobilePhone > ();
        }

        public Dictionary<int, IMobilePhone> Phones { get; private set; }


        public bool AddPhone(IMobilePhone phone)
        {
            bool res = false;
           // lock (lockObject)
            {
                if (Phones.ContainsKey(phone.SerialNum) == false)
                {                 
                    Phones.Add(phone.SerialNum, phone);
                    res = true;
                }
            }

            return res;
        }

        public bool RemovePhone(IMobilePhone phone)
        {
            bool res = false;
           // lock (lockObject)
            {
                if (Phones.ContainsKey(phone.SerialNum))
                {
                    Phones.Remove(phone.SerialNum);
                    res = true;
                }                
            }

            return res;
        }

        public bool IsPhoneExist(int serialNumber) { return Phones.ContainsKey(serialNumber); }
    }

    
}

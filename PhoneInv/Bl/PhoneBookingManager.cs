using PhoneInv.Interface;
using PhoneInv.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneInv.Bl
{
    public class PhoneBookingManager
    {
        public PhoneBookingManager(MobilePhoneInventory inv)
        {
            mobilePhoneInventory = inv ?? throw new Exception("MobilePhoneInventory can't be null")
;
        }
        
        private readonly object lockObject = new object();
        private readonly MobilePhoneInventory mobilePhoneInventory;

        public bool BookPhone(string user, int phoneSerialNumber)
        {
            bool res = false;
            Console.WriteLine("tring to booking...");
            if (mobilePhoneInventory.IsPhoneExist(phoneSerialNumber) == false)
            {
                Console.WriteLine($"Phone with {phoneSerialNumber} s/n does not exist");
                return false;
            }
            Console.WriteLine("tring to booking...");
            IMobilePhone phone = mobilePhoneInventory.Phones[phoneSerialNumber];
            Console.WriteLine("tring to booking...");
            lock (lockObject)
            {
             
            

                if (phone.IsAvailable)
                {
                    Console.WriteLine("tring to booking.");
                    phone.BookedAt = DateTime.Now;
                    Console.WriteLine("tring to booking...");
                    phone.BookedBy = user;
                    Console.WriteLine("tring to booking..2.");
                    phone.IsAvailable = false;
                    Console.WriteLine("tring to booking..");

                    Console.WriteLine($"{phone.Model} ({phone.SerialNum}) has been booked by {user} at {phone.BookedAt}");
                    res = true;
                }
                else
                {
                    Console.WriteLine($"{phone.Model} ({phone.SerialNum}) is already booked");
                }
            }

            return res;
        }
        public bool ReturnPhone(int phoneSerialNumber)
        {
            bool res = false;
            if (mobilePhoneInventory.IsPhoneExist(phoneSerialNumber) == false)
            {
                Console.WriteLine($"Phone with {phoneSerialNumber} s/n does not exist");
                return false;
            }


            lock (lockObject)
            {
                IMobilePhone phone = mobilePhoneInventory.Phones[phoneSerialNumber];
                if (!phone.IsAvailable)
                {
                    phone.IsAvailable = true;
                    phone.BookedAt = DateTime.MinValue;
                    phone.BookedBy = string.Empty;
                    Console.WriteLine($"{phone.Model} has been returned");
                    res = true;
                }
                else
                {
                    Console.WriteLine($"{phone.Model} is already available");
                }
            }
            return res = true;
            
        }
        public void DisplayAvilabilty(int phoneSerialNumber)       
        { 
            if (mobilePhoneInventory.Phones.ContainsKey(phoneSerialNumber) == false)
            {
                Console.WriteLine("Error - not Inventory initialized ");
            }
            else
            {
                Console.WriteLine(mobilePhoneInventory.Phones[phoneSerialNumber].DisplayPhoneDetailes());
            }
        }
        public void DisplayInventory()
        {
            Console.WriteLine("****  Phone Inventory *****");
            foreach (IMobilePhone phone in mobilePhoneInventory.Phones.Values)
            {
                Console.WriteLine(phone.DisplayPhoneDetailes());
            }
            Console.WriteLine("*********");
        }

    }
}

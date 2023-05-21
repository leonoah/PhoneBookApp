using PhoneBookApp.Interface;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Bl
{
    public class PhoneBookingManager
    {
        public PhoneBookingManager(MobilePhoneBookAppentory inv)
        {
            mobilePhoneBookAppentory = inv ?? throw new Exception("MobilePhoneBookAppentory can't be null")
;
        }
        
        private readonly object lockObject = new object();
        private readonly MobilePhoneBookAppentory mobilePhoneBookAppentory;

        // Book new phone
        public bool BookPhone(string user, int phoneSerialNumber)
        {
            bool res = false; 
            if (mobilePhoneBookAppentory.IsPhoneExist(phoneSerialNumber) == false)
            {
                Console.WriteLine($"Phone with {phoneSerialNumber} s/n does not exist");
                return false;
            }
        
            lock (lockObject)
            {
                IMobilePhone phone = mobilePhoneBookAppentory.Phones[phoneSerialNumber];

                if (phone.IsAvailable)
                {
                    phone.IsAvailable = false;
                    phone.BookedAt = DateTime.Now; 
                    phone.BookedBy = user; 
                
                    Console.WriteLine($"{phone.Model} ({phone.SerialNum}) has been booked by {user} at {phone.BookedAt}");
                    res = true;
                }
                else
                {
                    Console.WriteLine($"{phone.Model} ({phone.SerialNum}) is already booked by {phone.BookedBy}");
                }
            }

            return res;
        }

        // Return booked phone
        public bool ReturnPhone(int phoneSerialNumber)
        {
            bool res = false;
            if (mobilePhoneBookAppentory.IsPhoneExist(phoneSerialNumber) == false)
            {
                Console.WriteLine($"Phone with {phoneSerialNumber} s/n does not exist");
                return false;
            }

            lock (lockObject)
            {
                IMobilePhone phone = mobilePhoneBookAppentory.Phones[phoneSerialNumber];
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
            return res ;
            
        }

        // Display deisre phone avilabilty
        public void DisplayAvilabilty(int phoneSerialNumber)       
        { 
            if (mobilePhoneBookAppentory.Phones.ContainsKey(phoneSerialNumber) == false)
            {
                Console.WriteLine("Error - not Inventory initialized ");
            }
            else
            {
                Console.WriteLine(mobilePhoneBookAppentory.Phones[phoneSerialNumber].DisplayPhoneDetailes());
            }
        }

        // Display all phone avilabilty
        public void DisplayInventory()
        {
            Console.WriteLine("****  Phone Inventory *****");
            foreach (IMobilePhone phone in mobilePhoneBookAppentory.Phones.Values)
            {
                Console.WriteLine(phone.DisplayPhoneDetailes());
            }
            Console.WriteLine("*********");
        }

    }
}

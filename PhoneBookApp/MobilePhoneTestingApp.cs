using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PhoneBookApp.Bl;
using PhoneBookApp.Model;

namespace PhoneBookApp
{
    public class MobilePhoneTestingApp
    {
        public MobilePhoneTestingApp()
        {
            // Creates Phone Inventory
            inventory = new MobilePhoneBookAppentory();

            // Init Inventory
            initInvetntory();

            // Create and Init Booking Manager 
            phoneBookingManager = new PhoneBookingManager(inventory);            
        }


        MobilePhoneBookAppentory inventory;
        PhoneBookingManager phoneBookingManager;

        private void initInvetntory()
        {
            // Add all phones
            inventory.AddPhone(new AndroidMobilePhone(1, "Samsung", "Galaxy S9", "a"));
            inventory.AddPhone(new AndroidMobilePhone(2, "Samsung", "Galaxy S8", "b"));
            inventory.AddPhone(new AndroidMobilePhone(3, "Samsung", "Galaxy S8", "a"));
            inventory.AddPhone(new MobilePhone(4, "Motorola Nexus 6"));
            inventory.AddPhone(new MobilePhone(5, "Oneplus 9"));
            inventory.AddPhone(new IosMobilePhone(6, "Apple iPhone", "13", "IOS11"));
            inventory.AddPhone(new IosMobilePhone(7, "Apple iPhone", "12", "IOS11"));
            inventory.AddPhone(new IosMobilePhone(8, "Apple iPhone", "11", "IOS11"));
            inventory.AddPhone(new IosMobilePhone(9, "Apple iPhone", "X", "IOS13"));
            inventory.AddPhone(new MobilePhone(10, "Nokia 3310"));
        }

        public void RunApp()
        {
            phoneBookingManager.DisplayInventory();
            phoneBookingManager.BookPhone("David", 1);
            phoneBookingManager.DisplayAvilabilty(1);
            phoneBookingManager.ReturnPhone(1);
            phoneBookingManager.DisplayAvilabilty(1);

            phoneBookingManager.BookPhone("David", 2);
            phoneBookingManager.BookPhone("Avi", 2);
            phoneBookingManager.DisplayInventory();
            phoneBookingManager.ReturnPhone(2);
            phoneBookingManager.BookPhone("Avi", 2);
            phoneBookingManager.DisplayAvilabilty(2);
            phoneBookingManager.ReturnPhone(2);
            phoneBookingManager.DisplayAvilabilty(2);
            phoneBookingManager.ReturnPhone(2);
            phoneBookingManager.BookPhone("Avi", 20);
        }


        public void RunAppAsync()
        {
            //  David tring to booking first phone (with delay)
            Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine(" David is tring to booking...");
                phoneBookingManager.BookPhone("David", 1);
            });

            // Avi is trring to book phone 1
            Task.Run(() =>
            {
                Console.WriteLine(" Avi is tring to booking...");
                phoneBookingManager.BookPhone("Avi", 1);
            });

            // returning phone 1
            Task.Run(() =>
             {
                 phoneBookingManager.ReturnPhone(1);
             });
        }

    }
}

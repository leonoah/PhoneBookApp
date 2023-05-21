using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PhoneInv.Bl;
using PhoneInv.Model;

namespace PhoneInv
{
    public class MobilePhoneTestingApp
    {
        public MobilePhoneTestingApp()
        {
            inventory = new MobilePhoneInventory();
            initInvetntory();
            phoneBookingManager = new PhoneBookingManager(inventory);            
        }


        MobilePhoneInventory inventory;
        PhoneBookingManager phoneBookingManager;

        private void initInvetntory()
        {

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

            //     phoneBookingManager.DisplayInventory();
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };
            Task t1 = new Task(action, "alpha");

            t1.Start();

            Task t = new Task(() => {
               Console.WriteLine("tring to booking...");
              //  phoneBookingManager.BookPhone("David", 1);
            });

          //  t.Start();

           //Task.Run(() =>
          //  {
          //      phoneBookingManager.ReturnPhone(1);
          //  });

          //  Task.Run(() =>
            //{
              //  phoneBookingManager.BookPhone("Avi", 1);
               // phoneBookingManager.DisplayAvilabilty(1);
            //});

          
        }

    }
}

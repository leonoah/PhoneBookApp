using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Interface
{
    public interface IMobilePhone
    {
         int SerialNum { get; }
         string Model { get; }
         bool IsAvailable { get; set; }
         DateTime BookedAt { get; set; }
         string BookedBy { get; set; }

         string DisplayPhoneDetailes();
    }
 
}

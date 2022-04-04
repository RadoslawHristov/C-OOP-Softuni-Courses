using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone: ICall
    {
        private string phone;

        public string PhoneNumber
        {
            get => phone;
            set => phone=value;
        }

        public void Calling(string number)
        {
            if (number.Length==7)
            {
                Console.WriteLine($"Dialing... {number}");
                // number should be 7 digits
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}

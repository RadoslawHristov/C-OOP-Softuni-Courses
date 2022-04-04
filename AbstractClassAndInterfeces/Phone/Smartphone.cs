using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone: ICall,IBrowsing
    {
        private string phonenumber;
        private string website;
        public string PhoneNumber
        {
            get => phonenumber;
            set => phonenumber=value;
        }

        public void Calling(string number)
        {
            // phone number 10-smartphone-- 7 digits-stationary
            if (number.Length==10)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public string WebSite
        {
            get => website;
            set => website=value;
        }

        public void Browsing(string website)
        {
            // site not contains digits
            bool isValid = true;
            for (int i = 0; i < website.Length; i++)
            {
                char curent = website[i];
                if (char.IsDigit(curent))
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Browsing: {website}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}

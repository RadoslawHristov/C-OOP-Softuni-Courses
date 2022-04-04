using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webSite = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICall smartphone = null;
            IBrowsing browsing = null;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                string curentNumber = phoneNumber[i];

                if (curentNumber.Length==10)
                {
                    smartphone = new Smartphone();
                    smartphone.Calling(curentNumber);
                }
                else
                {
                    smartphone = new StationaryPhone();
                    smartphone.Calling(curentNumber);
                }
            }

            for (int i = 0; i < webSite.Length; i++)
            {
                string curentWeb = webSite[i];

                browsing = new Smartphone();
                browsing.Browsing(curentWeb);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HRS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation Program");
            List<Hotel> hotelList = new List<Hotel>();
            while(true)
            {
                showHotel(hotelList);
                Console.WriteLine("Enter 1 to add hotel and 2 to stop.");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                    addHotel(hotelList);
                else if (input == 2)
                    break;
                else
                    Console.WriteLine("Wrong Input");
            }
        }

        public static void addHotel(List<Hotel> hotelList)
        {
            Console.WriteLine("Enter hotel name");
            string hotelName = Console.ReadLine();
            Console.WriteLine("Enter hotel rate");
            int regularRate= Convert.ToInt32(Console.ReadLine());
            Hotel hotel=new Hotel(){ hotelName = hotelName, regularRate=regularRate};
            hotelList.Add(hotel);
            Console.WriteLine("--------------------");
        }
        
        public static void showHotel(List<Hotel> hotelList)
        {
            foreach(var item in hotelList)
                Console.WriteLine("Hotel Name: " + item.hotelName + "\tHotel Rate: " + item.regularRate);
            if (hotelList.Count == 0)
                Console.WriteLine("Currently no hotels are there in the list.");
            Console.WriteLine("--------------------");
        }
    }
}

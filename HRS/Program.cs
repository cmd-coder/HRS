using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace HRS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation Program");
            RunHRS();
        }

        public static void RunHRS()
        {
            List<Hotel> hotelList = new List<Hotel>();
            ManageHotels.AddHotel(hotelList);
            ManageHotels.ShowHotel(hotelList);
            string startDateString = "01/01/0001";//mm/dd/yyyy
            string endDateString = "01/01/0001";
            DateTime startDate = Convert.ToDateTime(startDateString);
            DateTime endDate = Convert.ToDateTime(endDateString);
            DateTime[] dateArray = new DateTime[2];
            ManageHotels.TakeDates(dateArray);
            startDate = dateArray[0];
            endDate = dateArray[1];

            String customerType = ManageHotels.TakeCustomerType();

            if (customerType.ToLower() == "regular")
            {
                ManageHotels.FindCheapestHotelInDateRangeRegularCustomers(startDate, endDate, hotelList);
                ManageHotels.FindBestHotelInDateRangeRegularCustomers(startDate, endDate, hotelList);
            }
            else
            {
                ManageHotels.FindCheapestHotelInDateRangeForLoyalCustomers(startDate, endDate, hotelList);
            }
        }
        
    }
}
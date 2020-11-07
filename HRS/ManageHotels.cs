using System;
using System.Collections.Generic;
using System.Text;

namespace HRS
{
    public class ManageHotels
    {

        public static void AddHotel(List<Hotel> hotelList)
        {
            Hotel hotel = new Hotel() { hotelName = "Lakewood", regularRate = 110, regularRateWeekend = 90, rating = 3, rewardRate = 80, rewardRateWeekend = 80 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend = 50, rating = 4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend = 150, rating = 5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList.Add(hotel);
            Console.WriteLine("--------------------");
        }

        public static void ShowHotel(List<Hotel> hotelList)
        {
            foreach (var item in hotelList)
                Console.WriteLine("Hotel Name: " + item.hotelName + "\tHotel Rate: " + item.regularRate + "\t Weekend Rate: " + item.regularRateWeekend);
            Console.WriteLine("--------------------");
        }

        public static void TakeDates(DateTime[] dateArray)
        {
            DateTime startDate; DateTime endDate;
            while (true)
            {
                Console.WriteLine("Enter start date in \"mm/dd/yyyy\" pattern");
                string sDate = Console.ReadLine();
                Console.WriteLine("Enter end date in \"mm/dd/yyyy\" pattern");
                string eDate = Console.ReadLine();
                startDate = Convert.ToDateTime(sDate);
                endDate = Convert.ToDateTime(eDate);

                try
                {
                    bool flag = CheckDate(startDate, endDate);
                    dateArray[0] = startDate;
                    dateArray[1] = endDate;
                    break;
                }
                catch (HRSCustomException hrsce)
                {
                    Console.WriteLine(hrsce.Message);
                    Console.WriteLine("Enter the dates again.");
                    Console.WriteLine("---------------------");
                }
            }
        }

        public static bool CheckDate(DateTime startDate, DateTime endDate)
        {
            if (endDate > startDate)
                return true;
            throw new HRSCustomException(HRSCustomException.ExceptionType.WRONG_DATES, "Date range is wrong");
        }

        public static String TakeCustomerType()
        {
            while (true)
            {
                Console.WriteLine("Enter the customer type: Reward or Regular");
                String type = Console.ReadLine();
                try
                {
                    bool flag = CheckCustomerType(type);
                    return type;
                }
                catch (HRSCustomException hrsce)
                {
                    Console.WriteLine(hrsce.Message);
                    Console.WriteLine("Enter the customer type again.");
                    Console.WriteLine("---------------------");
                }
            }

        }

        public static bool CheckCustomerType(String type)
        {
            if (type.ToLower() == "regular" || type.ToLower() == "reward")
                return true;
            throw new HRSCustomException(HRSCustomException.ExceptionType.WRONG_CUSTOMER_TYPE, "Customer Type is wrong");
        }

        public static int FindCheapestHotelInDateRangeRegularCustomers(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = hotelList[0];
            foreach (var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        hotelCost += item.regularRateWeekend;
                    else
                        hotelCost += item.regularRate;
                }
                if (totalCost > hotelCost && hotel.rating < item.rating)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine("The cheapest hotel available with best rating is:");
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost);
            Console.WriteLine("--------------------");
            return totalCost;
        }

        public static int FindBestHotelInDateRangeRegularCustomers(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = hotelList[0];
            foreach (var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        hotelCost += item.regularRateWeekend;
                    else
                        hotelCost += item.regularRate;
                }
                if (hotel.rating < item.rating)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine("The best hotel available is:");
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost);
            Console.WriteLine("--------------------");
            return totalCost;
        }

        public static int FindCheapestHotelInDateRangeForLoyalCustomers(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = hotelList[0];
            foreach (var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        hotelCost += item.rewardRateWeekend;
                    else
                        hotelCost += item.rewardRate;
                }
                if (totalCost > hotelCost && hotel.rating < item.rating)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine("The cheapest hotel available with best rating for loyal customers is:");
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost + ", Rating: " + hotel.rating);
            Console.WriteLine("--------------------");
            return totalCost;
        }

    }
}

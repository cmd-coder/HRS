﻿using System;
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
            List<Hotel> hotelList = new List<Hotel>();
            addHotel(hotelList);
            showHotel(hotelList);
            string startDateString = "09/11/2020";//mm/dd/yyyy
            string endDateString = "09/12/2020";
            DateTime startDate = Convert.ToDateTime(startDateString);
            DateTime endDate = Convert.ToDateTime(endDateString);
            findCheapestHotelInDateRange(startDate, endDate, hotelList);
            findBestHotelInDateRange(startDate, endDate, hotelList);
            findCheapestHotelInDateRangeForLoyalCustomers(startDate, endDate, hotelList);
        }

        public static void addHotel(List<Hotel> hotelList)
        {
            Hotel hotel=new Hotel(){ hotelName = "Lakewood", regularRate=110, regularRateWeekend=90, rating=3, rewardRate=80, rewardRateWeekend=80};
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend= 50, rating=4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend=150, rating=5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList.Add(hotel);
            Console.WriteLine("--------------------");
        }
        
        public static void showHotel(List<Hotel> hotelList)
        {
            foreach(var item in hotelList)
                Console.WriteLine("Hotel Name: " + item.hotelName + "\tHotel Rate: " + item.regularRate+"\t Weekend Rate: "+item.regularRateWeekend);
            Console.WriteLine("--------------------");
        }

        public static void findCheapestHotelInDateRange(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = hotelList[0];
            foreach(var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate;date <= endDate;date=date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        hotelCost += item.regularRateWeekend;
                    else
                        hotelCost += item.regularRate;
                }
                if (totalCost > hotelCost && hotel.rating<item.rating)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine("The cheapest hotel available with best rating is:");
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost);
            Console.WriteLine("--------------------");
        }

        public static void findBestHotelInDateRange(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = hotelList[0];
            foreach(var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate;date <= endDate;date=date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        hotelCost += item.regularRateWeekend;
                    else
                        hotelCost += item.regularRate;
                }
                if (hotel.rating<item.rating)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine("The best hotel available is:");
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost);
            Console.WriteLine("--------------------");
        }

        public static void findCheapestHotelInDateRangeForLoyalCustomers(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
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
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost+", Rating: "+hotel.rating);
            Console.WriteLine("--------------------");
        }
    }
}

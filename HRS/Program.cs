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
            string startDateString = "09/10/2020";//mm/dd/yyyy
            string endDateString = "09/11/2020";
            DateTime startDate = Convert.ToDateTime(startDateString);
            DateTime endDate = Convert.ToDateTime(endDateString);
            findCheapestHotelInDateRange(startDate, endDate, hotelList);
        }

        public static void addHotel(List<Hotel> hotelList)
        {
            Hotel hotel=new Hotel(){ hotelName = "Lakewood", regularRate=110};
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 160 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220 };
            hotelList.Add(hotel);
            Console.WriteLine("--------------------");
        }
        
        public static void showHotel(List<Hotel> hotelList)
        {
            foreach(var item in hotelList)
                Console.WriteLine("Hotel Name: " + item.hotelName + "\tHotel Rate: " + item.regularRate);
            Console.WriteLine("--------------------");
        }

        public static void findCheapestHotelInDateRange(DateTime startDate, DateTime endDate, List<Hotel> hotelList)
        {
            int totalCost = Int32.MaxValue;
            Hotel hotel = new Hotel();
            foreach(var item in hotelList)
            {
                int hotelCost = 0;
                for (var date = startDate;date <= endDate;date=date.AddDays(1))
                {
                    hotelCost += item.regularRate;
                }
                if (totalCost > hotelCost)
                {
                    totalCost = hotelCost;
                    hotel = item;
                }
            }
            Console.WriteLine(hotel.hotelName + ", Total Rates: " + totalCost);
        }
    }
}

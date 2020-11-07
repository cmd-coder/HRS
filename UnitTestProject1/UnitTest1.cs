using HRS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddHotelMethodByPassingAnEmptyListAndMakingItAddHotels()
        {
            List<Hotel> hotelList2 = new List<Hotel>();
            Hotel hotel = new Hotel() { hotelName = "Lakewood", regularRate = 110, regularRateWeekend = 90, rating = 3, rewardRate = 80, rewardRateWeekend = 80 };
            hotelList2.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend = 50, rating = 4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList2.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend = 150, rating = 5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList2.Add(hotel);
            List<Hotel> hotelList = new List<Hotel>();
            ManageHotels.AddHotel(hotelList);

            string[] hotelNames = { "Lakewood", "BridgeWood", "RidgeWood" };
            for(int i=0;i<hotelNames.Length;i++)
            {
                Assert.AreEqual(hotelList[i].hotelName, hotelList2[i].hotelName);
            }
        }

        [TestMethod]
        public void HappyTestCheckDateMethodByPassingTwoDatesAndGettingTrueIfCorrect()
        {
            DateTime startDate = Convert.ToDateTime("09/11/2020");
            DateTime endDate = Convert.ToDateTime("09/12/2020");
            bool flag = ManageHotels.CheckDate(startDate, endDate);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void SadTestCheckDateMethodByPassingTwoDatesAndGettingTrueIfCorrect()
        {
            DateTime endDate = Convert.ToDateTime("09/11/2020");
            DateTime startDate = Convert.ToDateTime("09/12/2020");
            //bool flag = ManageHotels.CheckDate(startDate, endDate);
            var exception = Assert.ThrowsException<HRSCustomException>(
            () => ManageHotels.CheckDate(startDate,endDate), "Date range is wrong");
            Assert.AreEqual("Date range is wrong", exception.Message);
        }

        [TestMethod]
        public void HappyTestCheckCustomerMethodByPassingTwoDatesAndGettingTrueIfCorrect()
        {
            String customerType = "Reward";
            bool flag = ManageHotels.CheckCustomerType(customerType);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void SadTestCheckCustomerMethodByPassingTwoDatesAndGettingTrueIfCorrect()
        {
            String wrongCustomerType = "WrongCustomerType";
            var exception = Assert.ThrowsException<HRSCustomException>(
            () => ManageHotels.CheckCustomerType(wrongCustomerType), "Customer Type is wrong");
            Assert.AreEqual("Customer Type is wrong", exception.Message);
        }

        [TestMethod]
        public void TestFindCheapestHotelInDateRangeRegularCustomersMethodByPassingTwoDatesAndHotelListAndGettingTotalCost()
        {
            List<Hotel> hotelList = new List<Hotel>();
            Hotel hotel = new Hotel() { hotelName = "Lakewood", regularRate = 110, regularRateWeekend = 90, rating = 3, rewardRate = 80, rewardRateWeekend = 80 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend = 50, rating = 4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend = 150, rating = 5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList.Add(hotel);

            DateTime endDate = Convert.ToDateTime("09/12/2020");
            DateTime startDate = Convert.ToDateTime("09/11/2020");

            int actualTotalCost = ManageHotels.FindCheapestHotelInDateRangeRegularCustomers(startDate, endDate, hotelList);
            int expectedTotalCost = 200;
            Assert.AreEqual(actualTotalCost, expectedTotalCost);
        }

        [TestMethod]
        public void TestFindBestHotelInDateRangeRegularCustomersMethodByPassingTwoDatesAndHotelListAndGettingTotalCost()
        {
            List<Hotel> hotelList = new List<Hotel>();
            Hotel hotel = new Hotel() { hotelName = "Lakewood", regularRate = 110, regularRateWeekend = 90, rating = 3, rewardRate = 80, rewardRateWeekend = 80 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend = 50, rating = 4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend = 150, rating = 5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList.Add(hotel);

            DateTime endDate = Convert.ToDateTime("09/12/2020");
            DateTime startDate = Convert.ToDateTime("09/11/2020");

            int actualTotalCost = ManageHotels.FindBestHotelInDateRangeRegularCustomers(startDate, endDate, hotelList);
            int expectedTotalCost = 370;
            Assert.AreEqual(actualTotalCost, expectedTotalCost);
        }

        [TestMethod]
        public void TestFindCheapestHotelInDateRangeForLoyalCustomersMethodByPassingTwoDatesAndHotelListAndGettingTotalCost()
        {
            List<Hotel> hotelList = new List<Hotel>();
            Hotel hotel = new Hotel() { hotelName = "Lakewood", regularRate = 110, regularRateWeekend = 90, rating = 3, rewardRate = 80, rewardRateWeekend = 80 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Bridgewood", regularRate = 150, regularRateWeekend = 50, rating = 4, rewardRate = 110, rewardRateWeekend = 50 };
            hotelList.Add(hotel);
            hotel = new Hotel() { hotelName = "Ridgewood", regularRate = 220, regularRateWeekend = 150, rating = 5, rewardRate = 100, rewardRateWeekend = 40 };
            hotelList.Add(hotel);

            DateTime endDate = Convert.ToDateTime("09/12/2020");
            DateTime startDate = Convert.ToDateTime("09/11/2020");

            int actualTotalCost = ManageHotels.FindCheapestHotelInDateRangeForLoyalCustomers(startDate, endDate, hotelList);
            int expectedTotalCost = 140;
            Assert.AreEqual(actualTotalCost, expectedTotalCost);
        }

    }
}

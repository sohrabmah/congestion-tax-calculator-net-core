using Core.DTOs;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
    **/

    public int GetTax(VehicleDto vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private bool IsTollFreeVehicle(VehicleDto vehicle)
    {
        if (vehicle == null) return false;
        String vehicleType = vehicle.GetVehicleType();
        return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Busses.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Military.ToString());
    }

    public int GetTollFee(DateTime date, VehicleDto vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        var tollFeeList = new List<TollFeeModel>();
        using (StreamReader r = new StreamReader("Roles.json"))
        {
            string json = r.ReadToEnd();
            tollFeeList = JsonConvert.DeserializeObject<List<TollFeeModel>>(json);
        }

        if (hour == 6 && minute >= 0 && minute <= 29) return tollFeeList.Find(m => m.Key == "06:00–06:29").Value;
        else if (hour == 6 && minute >= 30 && minute <= 59) return tollFeeList.Find(m => m.Key == "06:30–06:59").Value;
        else if (hour == 7 && minute >= 0 && minute <= 59) return tollFeeList.Find(m => m.Key == "07:00–07:59").Value;
        else if (hour == 8 && minute >= 0 && minute <= 29) return tollFeeList.Find(m => m.Key == "08:00–08:29").Value;
        else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return tollFeeList.Find(m => m.Key == "08:30–14:59").Value;
        else if (hour == 15 && minute >= 0 && minute <= 29) return tollFeeList.Find(m => m.Key == "15:00–15:29").Value;
        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return tollFeeList.Find(m => m.Key == "15:30–16:59").Value;
        else if (hour == 17 && minute >= 0 && minute <= 59) return tollFeeList.Find(m => m.Key == "17:00–17:59").Value;
        else if (hour == 18 && minute >= 0 && minute <= 29) return tollFeeList.Find(m => m.Key == "18:00–18:29").Value;
        else return tollFeeList.Find(m => m.Key == "18:30–05:59").Value;
    }

    private Boolean IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    private enum TollFreeVehicles
    {
        Emergency = 0,
        Busses = 1,
        Diplomat = 2,
        Motorcycle = 3,
        Military = 4,
        Foreign = 5,
    }
}
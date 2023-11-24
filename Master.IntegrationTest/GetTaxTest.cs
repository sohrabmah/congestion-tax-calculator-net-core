using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace HospitalManager.IntegrationTest
{
    public class GetTaxTest
    {
        [Test]
        public void GetCarTax()
        {
            var car = new CarDto();
            car.Id = Guid.NewGuid();
            car.Name = "Ferrari";
            car.Plate = "123456";

            var mockSet = new Mock<ICarRepo>();
            var mockSetMapper = new Mock<IMapper>();
            var service = new CongestionTaxCalculator();

            DateTime[] dateTimes = new DateTime[]
            {
                DateTime.Parse("2013-01-14 21:00:00"),DateTime.Parse("2013-01-15 21:00:00"),DateTime.Parse("2013-02-07 06:23:27"),
                DateTime.Parse("2013-02-07 15:27:00"),DateTime.Parse("2013-02-08 06:27:00"  ),DateTime.Parse("2013-02-08 06:20:27"),
                DateTime.Parse("2013-02-08 14:35:00"),DateTime.Parse("2013-02-08 15:29:00"),DateTime.Parse("2013-02-08 15:47:00"),
                DateTime.Parse("2013-02-08 16:01:00"),DateTime.Parse("2013-02-08 16:48:00"),DateTime.Parse("2013-02-08 17:49:00"),
                DateTime.Parse("2013-02-08 18:29:00"),DateTime.Parse("2013-02-08 18:35:00"),DateTime.Parse("2013-03-26 14:25:00"),
                DateTime.Parse("2013-03-28 14:07:27"),
            };

            var result = service.GetTax(car, dateTimes);
            Assert.AreEqual(0, result);
        }
    }
}


using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using RCS.IoT.Service;
using System;
using System.Collections.Generic;

namespace RCS.IoT
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Proccess Starting...");
            Console.ReadLine();

            var residentFilterParams = new ResidentsFilterParams();

            AuthenticationService.Authorize(new Model.CurrentUserViewModel
            {
                Email = "admin@gmail.com",
                Password = "123456"
            });

            var resientsResult = ResidentService.GetResidents(residentFilterParams);

            GenereteObservations(resientsResult.Collection);

            var totalPages = Math.Ceiling((double)resientsResult.TotalCount / residentFilterParams.Take);

            for (var i = 1; i <= totalPages; i++)
            {
                residentFilterParams.Skip = residentFilterParams.Take * (i - 1);

                var residents = ResidentService.GetResidents(residentFilterParams);
                GenereteObservations(residents.Collection);
            }

            Console.WriteLine("Press enter to stop proccess...");
            Console.ReadLine();
        }

        static void GenereteObservations(IEnumerable<ResidentDto> residents)
        {
            foreach (var resident in residents)
            {
                for (int i = 0; i < 30; i++)
                {
                    var bloodPressure = CreateObservation(ObservationType.BloodPressure, resident, i);
                    var heartRate = CreateObservation(ObservationType.HeartRate, resident, i);


                    Console.WriteLine($"Resident #{resident.ResidentId} blood pressure is {bloodPressure.SystolicValue} / {bloodPressure.DiastolicValue} {bloodPressure.Unit}");
                    Console.WriteLine($"Resident #{resident.ResidentId} heart rate is {heartRate.Value} {bloodPressure.Unit}");


                    ObservationService.AddObservation(bloodPressure);
                    ObservationService.AddObservation(heartRate);
                }

                for (int i = 0; i < 7; i++)
                {
                    var temperature = CreateObservation(ObservationType.Temperature, resident, i);

                    Console.WriteLine($"Resident #{resident.ResidentId} temperature is {temperature.Value} {temperature.Unit}");

                    ObservationService.AddObservation(temperature);
                }

            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int GetRandomNumber(int minimum, int maximum)
        {
            return random.Next(minimum, maximum);
        }

        static AddObservationDto CreateObservation(ObservationType type, ResidentDto resident, int i)
        {
            switch (type)
            {
                case ObservationType.BloodPressure:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.BloodPressure,
                        RecordedDate = DateTime.Now.AddDays(i * -1),
                        DiastolicValue = GetRandomNumber(80, 140),
                        SystolicValue = GetRandomNumber(80, 140),
                        Unit = "mmHg"
                    };
                case ObservationType.HeartRate:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.HeartRate,
                        RecordedDate = DateTime.Now.AddDays(i * -1),
                        Value = Math.Round(GetRandomNumber(60.0, 120.0), 2),
                        Unit = "bpm"
                    };
                case ObservationType.Temperature:
                    return new AddObservationDto
                    {
                        ResidentId = resident.ResidentId,
                        Type = ObservationType.Temperature,
                        RecordedDate = DateTime.Now.AddDays(i * -1),
                        Value = Math.Round(GetRandomNumber(36.0, 38.0), 2),
                        Unit = "°C"
                    };
            }

            return null;
        }
    }
}

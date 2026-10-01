using lab6.Implementations;
using lab6.Interfaces;
using lab6.Models;

namespace lab6;

public static class AppInitializer
{
    public static List<ICarDealer> CreateDealers()
    {
        List<ICarDealer> carDealers =
        [
            new CarDealer(
                "Toyota",
                new Inventory(
                [
                    new Sedan(
                        "Toyota",
                        "Camry",
                        2022,
                        25_000,
                        4),

                    new SUV(
                        "Toyota",
                        "RAV4",
                        2021,
                        28_000,
                        true),

                    new Sedan(
                        "Toyota",
                        "Corolla",
                        2020,
                        18_000,
                        4)
                ]),
                new CurrentAccount(50_000)),

            new CarDealer(
                "BMW",
                new Inventory(
                [
                    new Sedan(
                        "BMW",
                        "3 Series",
                        2022,
                        32_000,
                        4),

                    new SUV(
                        "BMW",
                        "X5",
                        2023,
                        55_000,
                        true),

                    new Sedan(
                        "BMW",
                        "5 Series",
                        2021,
                        40_000,
                        4)
                ]),
                new CurrentAccount(70_000)),

            new CarDealer(
                "Audi",
                new Inventory(
                [
                    new Sedan(
                        "Audi",
                        "A4",
                        2022,
                        30_000,
                        4),

                    new SUV(
                        "Audi",
                        "Q5",
                        2023,
                        45_000,
                        true),

                    new Sedan(
                        "Audi",
                        "A6",
                        2021,
                        42_000,
                        4)
                ]),
                new CurrentAccount(65_000))
        ];

        return carDealers;
    }
}
using Garage.Model.Garage;
using Garage.Model.Vehicle;


namespace Garage.Model.Test.Garage;


public class GarageTest
{
    public class Fixture
    {
        internal GarageFactory<ParkingLot> GarageFactory { get; private init; }
        
        internal Mock<IVehicle> MockVehicle { get; private init; }

        public Fixture()
        {
            GarageFactory = new GarageFactory<ParkingLot>();
            MockVehicle = new Mock<IVehicle>();
        }
    }

    public class StaffEntityConstructor()
    {
        public static IEnumerable<object[]> ValidTestData = [
            [1, 1],
            [100, 100],
            [1000, 1000],
            [0, 0],
        ];

        [Theory(DisplayName = "Create a garage with parking lot of the in capacity.")]
        [MemberData(nameof(ValidTestData))]
        internal void T1(
            uint inCapacity,
            uint expectedCapacity
            )
        {
            var garage = new Garage<ParkingLot>(inCapacity);
            var actualCapacity = garage.Capacity;
            Assert.Equal(expectedCapacity, actualCapacity);
        }
    }

    public class TryAddVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> FailureTestData = [
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ]
        ];

        [Theory(DisplayName = """
        🧪 Output null value for parking lot
        when try parking in none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T1_Failure(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out ParkingLot? parkingLot
            );

            Assert.Null(parkingLot);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try parking in none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T2_Failure(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out ParkingLot? parkingLot
            );

            Assert.False(parkingResult);
        }

        public static IEnumerable<object[]> SuccessTestData = [
            [ 1, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 2, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 3, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ]
        ];

        [Theory(DisplayName = """
        🧪 Output existing parking lot
        when try parking in existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T1_Success(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;  

            garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out ParkingLot? parkingLot
            );

            Assert.Equal(parkingLot!.ID, parkingLotId);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try parking in existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T2_Success(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out ParkingLot? parkingLot
            );

            Assert.True(parkingResult);
        }

        public void Dispose()
        {            
            _f.MockVehicle.Reset();
        }
    }

    public class TryRemoveVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> FailureTestData = [
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 4, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ]
        ];

        [Theory(DisplayName = """
        🧪 Output null value for vehicle
        when try to remove vehicle from none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T1_Failure(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = _f.MockVehicle.Object;
            }
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            garage.TryRemoveVehicle(
                parkingLotId, out IVehicle? vehicle
            );

            Assert.Null(vehicle);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try to remove vehicle from none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T2_Failure(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = _f.MockVehicle.Object;
            }
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var removeCarResult = garage.TryRemoveVehicle(
                parkingLotId, out IVehicle? vehicle
            );

            Assert.False(removeCarResult);
        }

        public static IEnumerable<object[]> SuccessTestData = [
            [ 1, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 2, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ],
            [ 3, new HashSet<ParkingLot>
                {
                    new ParkingLot() { ID = 1 },
                    new ParkingLot() { ID = 2 },
                    new ParkingLot() { ID = 3 }
                }
            ]
        ];

        [Theory(DisplayName = """
        🧪 Output value for vehicle
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T1_Success(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = _f.MockVehicle.Object;
            }
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var removeCarResult = garage.TryRemoveVehicle(
                parkingLotId, out IVehicle? vehicle
            );

            Assert.NotNull(vehicle);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T2_Success(
            uint parkingLotId,
            HashSet<ParkingLot> parkingLots
            )
        {
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = _f.MockVehicle.Object;
            }
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var removeCarResult = garage.TryRemoveVehicle(
                parkingLotId, out IVehicle? vehicle
            );

            Assert.True(removeCarResult);
        }


        public void Dispose()
        {
            _f.MockVehicle.Reset();
        }
    }
}

using Garage.Model.Garage;
using Garage.Model.Vehicle;
using Garage.Model.ParkingLot;


namespace Garage.Model.Test.Garage;

public class GarageTest
{
    private static Mock<IParkingLot> CreateMockParkingLot(uint id)
    {
        var parkingLotMock = new Mock<IParkingLot>();
        var vehicleMock = new Mock<IVehicle>();
        parkingLotMock.Setup(lot => lot.ID).Returns(id);
        parkingLotMock.SetupProperty(lot => lot.CurrentVehicle, vehicleMock.Object);
        return parkingLotMock;
    }

    public class Fixture
    {
        internal BasicGarageFactory<IParkingLot> GarageFactory { get; private init; }

        internal Mock<IVehicle> MockVehicle { get; private init; }

        public Fixture()
        {
            GarageFactory = new BasicGarageFactory<IParkingLot>();
            MockVehicle = new Mock<IVehicle>();
        }
    }

    public class Constructor()
    {
        public static IEnumerable<object[]> TestDataUintAsCapacity = [
            [1, 1],
            [100, 100],
            [1000, 1000],
            [0, 0],
        ];

        [Theory(DisplayName = """
        🧪 Create a garage instance
        with same number of parking lots as the in capacity.
        """)]
        [MemberData(nameof(TestDataUintAsCapacity))]
        internal void T1(
            uint inCapacity,
            uint expectedCapacity
            )
        {
            var parkingLotFactory = new ParkingLotFactory();
            var garage = new Garage<GeneralParkingLot>(inCapacity, parkingLotFactory);
            var actualCapacity = garage.Capacity;
            Assert.Equal(expectedCapacity, actualCapacity);
        }

        public static IEnumerable<object[]> TestDataSetAsCapacity = [
            [ new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ]
        ];

        [Theory(DisplayName = """
        🧪 Create a garage instance
        with same parking lots as the input parking lots.
        """)]
        [MemberData(nameof(TestDataSetAsCapacity))]
        internal void T2(HashSet<IParkingLot> inParkingLots)
        {
            var garage = new Garage<IParkingLot>(inParkingLots);
            var actualCapacity = garage.Capacity;
            Assert.Equal((uint)inParkingLots.Count, actualCapacity);
        }
    }

    public class TryAddVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> FailureTestData = [
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
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
            HashSet<IParkingLot> parkingLots
            )
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot? parkingLot
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
            HashSet<IParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot? parkingLot
            );

            Assert.False(parkingResult);
        }

        public static IEnumerable<object[]> SuccessTestData = [
            [ 1, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 2, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 3, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
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
            HashSet<IParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;  

            garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot? parkingLot
            );

            Assert.Equal(parkingLot!.ID, parkingLotId);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try parking in an existing parking lot
        with no current vehicle.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T2_Success(
            uint parkingLotId,
            HashSet<IParkingLot> parkingLots
            )
        {
            // Remove all default vehicles.
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = null;
            }
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot? parkingLot
            );

            Assert.True(parkingResult);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try parking in an existing parking lot
        with a current vehicle.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T3_Success(
            uint parkingLotId,
            HashSet<IParkingLot> parkingLots
            )
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot? parkingLot
            );

            Assert.False(parkingResult);
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
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
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
            HashSet<IParkingLot> parkingLots
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
            HashSet<IParkingLot> parkingLots)
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

        public static IEnumerable<object[]> SuccessTestData = new List<object[]>
        {
            new object[] { 1, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            },
            new object[] { 2, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            },
            new object[] { 3, new HashSet<IParkingLot>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            }
        };

        [Theory(DisplayName = """
        🧪 Output value for vehicle
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T1_Success(
            uint parkingLotId,
            HashSet<IParkingLot> parkingLots)
        {
            //foreach (var lot in parkingLots)
            //{
            //    lot.CurrentVehicle = _f.MockVehicle.Object;
            //}
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var removeCarResult = garage.TryRemoveVehicle(parkingLotId, out IVehicle? vehicle);

            Assert.NotNull(vehicle);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T2_Success(
            uint parkingLotId,
            HashSet<IParkingLot> parkingLots)
        {
            foreach (var lot in parkingLots)
            {
                lot.CurrentVehicle = _f.MockVehicle.Object;
            }
            var garage = _f.GarageFactory.CreateGarage(parkingLots);
            var actualCapacity = garage.Capacity;

            var removeCarResult = garage.TryRemoveVehicle(parkingLotId, out IVehicle? vehicle);

            Assert.True(removeCarResult);
        }

        public void Dispose()
        {
            _f.MockVehicle.Reset();
        }
    }
}

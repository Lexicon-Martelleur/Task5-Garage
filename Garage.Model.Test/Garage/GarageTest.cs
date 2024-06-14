using Garage.Model.Garage;
using Garage.Model.Vehicle;
using Garage.Model.ParkingLot;


namespace Garage.Model.Test.Garage;

public class GarageTest
{
    # region Helpers Region
    private static IEnumerable<object[]> CreateFailureTestData()
    {
        return [
            [ 4, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 4, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ]
        ];
    }

    private static IEnumerable<object[]> CreateSuccessTestData()
    {
        return [
            [ 1, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 2, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ 3, new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ]
        ];
    }

    private static Mock<IParkingLot<IVehicle>> CreateMockParkingLot(uint id)
    {
        var parkingLotMock = new Mock<IParkingLot<IVehicle>>();
        var vehicleMock = new Mock<IVehicle>();
        parkingLotMock.Setup(lot => lot.ID).Returns(id);
        parkingLotMock.SetupProperty(lot => lot.CurrentVehicle, vehicleMock.Object);
        return parkingLotMock;
    }

    private static IEnumerable<object[]> CreateGarageWithHashSetTestData()
    {
        return [
            [ new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ],
            [ new HashSet<IParkingLot<IVehicle>>
                {
                    CreateMockParkingLot(1).Object,
                    CreateMockParkingLot(2).Object,
                    CreateMockParkingLot(3).Object
                }
            ]
        ];
    }

    private static void CleanDefaultGarageVehiclesBeforeTest(HashSet<IParkingLot<IVehicle>> parkingLots)
    {
        foreach (var lot in parkingLots)
        {
            lot.CurrentVehicle = null;
        }
    }

    private static void AddGarageVehiclesBeforeTest(
        HashSet<IParkingLot<IVehicle>> parkingLots,
        IVehicle vehicle
        )
    {
        foreach (var lot in parkingLots)
        {
            lot.CurrentVehicle = vehicle;
        }
    }

    #endregion

    #region Setup Region
    public class Fixture
    {
        internal IGarageFactory<IParkingLot<IVehicle>, IVehicle> GarageFactory
        {
            get;
            private init;
        }

        internal Mock<IVehicle> MockVehicle { get; private init; }

        public Fixture()
        {
            GarageFactory = new GarageFactory<IVehicle>();
            MockVehicle = new Mock<IVehicle>();
        }
    }
    # endregion

    # region Test Region
    public class Constructor()
    {

        public static IEnumerable<object[]> TestDataWithHashSetAsCapacity = CreateGarageWithHashSetTestData();

        [Theory(DisplayName = """
        🧪 Create a garage instance
        with same parking lots as the input parking lots.
        """)]
        [MemberData(nameof(TestDataWithHashSetAsCapacity))]
        internal void T2_Constructor(HashSet<IParkingLot<IVehicle>> inParkingLots)
        {
            var garage = new UniversalGarage<
                IParkingLot<IVehicle>,
                IVehicle
            >(inParkingLots, "ADDRESS", GarageDescription.MULTI);
            var actualCapacity = garage.Capacity;
            Assert.Equal((uint)inParkingLots.Count, actualCapacity);
        }
    }

    public class TryAddVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> FailureTestData = CreateFailureTestData();

        public static IEnumerable<object[]> SuccessTestData = CreateSuccessTestData();

        [Theory(DisplayName = """
        🧪 Output null value for parking lot
        when try parking in none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T1_TryAddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            garage.TryAddVehicle(
                parkingLotId,
                _f.MockVehicle.Object,
                out IParkingLot<IVehicle>? parkingLot
            );

            Assert.Null(parkingLot);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try parking in none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T2_TryAddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var parkingResult = garage.TryAddVehicle(
                parkingLotId,
                _f.MockVehicle.Object,
                out IParkingLot<IVehicle>? parkingLot
            );

            Assert.False(parkingResult);
        }
        
        [Theory(DisplayName = """
        🧪 Output existing parking lot
        when try parking in existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T3_TryAddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
         
            garage.TryAddVehicle(
                parkingLotId,
                _f.MockVehicle.Object,
                out IParkingLot<IVehicle>? parkingLot
            );

            Assert.Equal(parkingLot!.ID, parkingLotId);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try parking in an existing parking lot
        with no current vehicle.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T4_TryAddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            CleanDefaultGarageVehiclesBeforeTest(parkingLots);
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var parkingResult = garage.TryAddVehicle(
                parkingLotId,
                _f.MockVehicle.Object,
                out IParkingLot<IVehicle>? parkingLot
            );

            Assert.True(parkingResult);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try parking in an existing parking lot
        with a current vehicle.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T5_TryAddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var parkingResult = garage.TryAddVehicle(
                parkingLotId, _f.MockVehicle.Object, out IParkingLot<IVehicle>? parkingLot
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

        public static IEnumerable<object[]> FailureTestData = CreateFailureTestData();

        public static IEnumerable<object[]> SuccessTestData = CreateSuccessTestData();

        [Theory(DisplayName = """
        🧪 Output null value for vehicle
        when try to remove vehicle from none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T1_TryRemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            CleanDefaultGarageVehiclesBeforeTest(parkingLots);
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);

            garage.TryRemoveVehicle(
                parkingLotId,
                out IVehicle? vehicle
            );

            Assert.Null(vehicle);
        }

        [Theory(DisplayName = """
        🧪 Return false
        when try to remove vehicle from none existing parking lot id.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T2_TryRemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            CleanDefaultGarageVehiclesBeforeTest(parkingLots);
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var removeCarResult = garage.TryRemoveVehicle(
                parkingLotId,
                out IVehicle? vehicle
            );

            Assert.False(removeCarResult);
        }

        
        [Theory(DisplayName = """
        🧪 Output value for vehicle
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T3_TryRemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            // TODO! Why do not default vehicle work here?
            AddGarageVehiclesBeforeTest(parkingLots, _f.MockVehicle.Object);
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var removeCarResult = garage.TryRemoveVehicle(parkingLotId, out IVehicle? vehicle);
            Assert.NotNull(vehicle);
        }

        [Theory(DisplayName = """
        🧪 Return true
        when try to remove vehicle from existing parking lot id.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T4_TryRemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var garage = _f.GarageFactory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var removeCarResult = garage.TryRemoveVehicle(parkingLotId, out IVehicle? vehicle);

            Assert.True(removeCarResult);
        }

        public void Dispose()
        {
            _f.MockVehicle.Reset();
        }
    }

    public class AddVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> FailureTestData = CreateSuccessTestData();

        public static IEnumerable<object[]> SuccessTestData = CreateFailureTestData();

        [Theory(DisplayName = """
        🧪 Return parking lot with vehicle
        when parking in existing parking lot.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T1_AddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            CleanDefaultGarageVehiclesBeforeTest(parkingLots);
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            var parkingLot = garage.AddVehicle(
                parkingLotId, _f.MockVehicle.Object
            );
            
            Assert.NotNull(parkingLot);
            Assert.Equal(_f.MockVehicle.Object, parkingLot.CurrentVehicle);
        }

        [Theory(DisplayName = """
        🧪 Throw custom model exception
        when try parking in existing parking lot
        with existing car.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T2_AddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            
            Assert.Throws<InvalidGarageStateException>(() => garage.AddVehicle(
                parkingLotId, _f.MockVehicle.Object
            ));
        }

        [Theory(DisplayName = """
        🧪 Throw custome exception 
        when try parking in none existing parking lot.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T3_AddVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            CleanDefaultGarageVehiclesBeforeTest(parkingLots);
            var factory = _f.GarageFactory;

            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);

            Assert.Throws<InvalidGarageStateException>(() => garage.AddVehicle(
                parkingLotId, _f.MockVehicle.Object
            ));
        }

        public void Dispose()
        {
            _f.MockVehicle.Reset();
        }
    }

    public class RemoveVehicle(Fixture fixture) : IClassFixture<Fixture>, IDisposable
    {
        private readonly Fixture _f = fixture;

        public static IEnumerable<object[]> SuccessTestData = CreateSuccessTestData();

        public static IEnumerable<object[]> FailureTestData = CreateFailureTestData();

        [Theory(DisplayName = """
        🧪 Return vehicle
        when remove vehicle from
        existing parking lot.
        """)]
        [MemberData(nameof(SuccessTestData))]
        internal void T1_RemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            AddGarageVehiclesBeforeTest(parkingLots, _f.MockVehicle.Object);
            
            var reomvedVehicle = garage.RemoveVehicle(parkingLotId);
            Assert.NotNull(reomvedVehicle);
            Assert.Equal(_f.MockVehicle.Object, reomvedVehicle);
        }

        [Theory(DisplayName = """
        🧪 Throw custom model exception
        when remove vehicle from 
        none existing parking lot.
        """)]
        [MemberData(nameof(FailureTestData))]
        internal void T2_RemoveVehicle(
            uint parkingLotId,
            HashSet<IParkingLot<IVehicle>> parkingLots)
        {
            var factory = _f.GarageFactory;
            var garage = factory.CreateGarage(parkingLots, "ADDRESS", GarageDescription.MULTI);
            AddGarageVehiclesBeforeTest(parkingLots, _f.MockVehicle.Object);

            Assert.Throws<InvalidGarageStateException>(() => garage.RemoveVehicle(
                parkingLotId
            ));            
        }


        public void Dispose()
        {
            _f.MockVehicle.Reset();
        }
    }

    #endregion
}

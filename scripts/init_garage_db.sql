CREATE TABLE Garages (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    capacity INTEGER NOT NULL,
    name TEXT NOT NULL,
    address TEXT
);

CREATE TABLE ParkingLots (
    id INTEGER PRIMARY KEY,
    garage_id INTEGER,
    vehicle_type_id INTEGER,
    FOREIGN KEY (garage_id) REFERENCES Garages(id),
    FOREIGN KEY (vehicle_type_id) REFERENCES VehicleTypes(id)
);

CREATE TABLE VehicleTypes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    type TEXT NOT NULL
);

CREATE TABLE Vehicles (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    vehicle_type_id INTEGER,
    parking_lot_id INTEGER,
    registration_number TEXT NOT NULL UNIQUE,
    color TEXT,
    power_source TEXT,
    vehicle_weight INTEGER,
    FOREIGN KEY (parking_lot_id) REFERENCES ParkingLots(id)
);

CREATE TABLE Cars (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    parent_id INTEGER,
    car_brand TEXT,
    FOREIGN KEY (parent_id) REFERENCES Vehicles(id)
);

CREATE TABLE Boats (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    parent_id INTEGER,
    steering_mechanism TEXT,
    FOREIGN KEY (parent_id) REFERENCES Vehicles(id)
);

CREATE TABLE Airplanes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    parent_id INTEGER,
    wing_span INTEGER,
    passenger INTEGER,
    FOREIGN KEY (parent_id) REFERENCES Vehicles(id)
);

CREATE TABLE Buses (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    parent_id INTEGER,
    passenger_sitting INTEGER,
    passenger_standing INTEGER,
    FOREIGN KEY (parent_id) REFERENCES Vehicles(id)
);

CREATE TABLE Motorcycles (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    parent_id INTEGER,
    noise_level INTEGER,
    FOREIGN KEY (parent_id) REFERENCES Vehicles(id)
);

CREATE TABLE VehicleDimesions (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    x INTEGER,
    y INTEGER,
    z INTEGER,
    vehicle_id INTEGER,
    FOREIGN KEY (vehicle_id) REFERENCES Vehicles(id)
);

CREATE VIEW CarsView AS
SELECT
    Vehicles.id AS parent_id,
    Vehicles.vehicle_type_id,
    Vehicles.parking_lot_id,
    Vehicles.registration_number,
    Vehicles.color,
    Vehicles.power_source,
    Vehicles.vehicle_weight,
    Cars.id AS car_id,
    Cars.car_brand
FROM Vehicles
LEFT JOIN Cars ON Vehicles.id = Cars.parent_id;


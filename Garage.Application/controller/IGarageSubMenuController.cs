namespace Garage.Application.Controller;

internal interface IGarageSubMenuController
{
    void HandleAddVehicleToGarage();
    void HandleCreateGarage();
    void HandleFilterVehicle();
    void HandleListAllGarages();
    void HandleListAllVehicles();
    void HandleListGroupedVehiclesByType();
    void HandleRemoveVehicleFromGarage();
    void HandleSearchVehicleByRegNumber();
}

namespace Garage.Application.Controller;

/// <summary>
/// INterface used to describe a IGarageSubMenuController.
/// </summary>
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

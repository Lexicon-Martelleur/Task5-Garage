﻿namespace Garage.Application.View;

/// <summary>
/// An interface used to describe an IGarageMenuView
/// view type.
/// </summary>
internal interface IGarageMenuView
{
    void PrintCorruptedData(string selection);
    string PrintGarageMainMenu();
    void PrintIncorrectMenuSelection(string selection);
    void WriteRemoveAddVehicleMenu();
    void WriteStartAddVehicleMenu();
    void WriteStartCreateGarageMenu();
    void WriteStartFilterMenu();
    void WriteStartGroupedVehiclesByTypeMenu();
    void WriteStartListAllGaragesMenu();
    void WriteStartListAllVehiclesMenu();
    void WriteStartSearchVehicleByRegNrMenu();
}
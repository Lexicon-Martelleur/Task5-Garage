using Garage.Model.Garage;
using Garage.Model.Repository;

namespace Garage.Model.Service;


public class GarageService(IGarageRepository repository) : IGarageService
{
    public GarageKeeper GetAllGarages()
    {
        return ValidateGarages(repository.GetAllGarages());
    }

    private GarageKeeper ValidateGarages(GarageKeeper garages)
    {
        if (!IsUniqueGarageAddresses(garages))
        {
            throw new InvalidGarageStateException("Address must be unique for each garage.");
        }
        return garages;
    }

    private bool IsUniqueGarageAddresses(GarageKeeper garages)
    {
        var uniqueAddresses = new HashSet<string>();
        uint counter = 0;
        counter = AddUniqueAddresses(
            garages.CarGarages.Select(garage => garage.Address),
            counter,
            uniqueAddresses
        );
        if (uniqueAddresses.Count() != counter) { return false; }

        counter = AddUniqueAddresses(
            garages.BusGarages.Select(garage => garage.Address),
            counter,
            uniqueAddresses
        );
        if (uniqueAddresses.Count() != counter) { return false; }

        counter = AddUniqueAddresses(
            garages.MCGarages.Select(garage => garage.Address),
            counter,
            uniqueAddresses
        );
        if (uniqueAddresses.Count() != counter) { return false; }

        counter = AddUniqueAddresses(
            garages.BoatHarbors.Select(garage => garage.Address),
            counter,
            uniqueAddresses
        );
        if (uniqueAddresses.Count() != counter) { return false; }

        counter = AddUniqueAddresses(
            garages.AirplaneHangars.Select(garage => garage.Address),
            counter,
            uniqueAddresses
        );
        if (uniqueAddresses.Count() != counter) { return false; }

        return true;
    }

    private uint AddUniqueAddresses(
        IEnumerable<string> addresses,
        uint counter,
        HashSet<string> uniqueAddresses
    )
    {
        uint updatedCounter = counter;
        foreach (var addrress in addresses)
        {
            updatedCounter++;
            uniqueAddresses.Add(addrress);
        }
        return updatedCounter;
    }
}


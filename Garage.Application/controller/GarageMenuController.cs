using Garage.Application.View;
using Garage.Model.Service;

namespace Garage.Application.controller;

internal class GarageMenuController(GarageMenuView view, IGarageService service)
{
    internal void Start()
    {
        var quitMenu = false;
        var garages = service.GetAllGarages();
        do
        {
            view.PrintMainMenu(garages);

        } while (quitMenu);
    }
}

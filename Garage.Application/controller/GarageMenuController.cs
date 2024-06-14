using Garage.Application.View;
using Garage.Model.Service;

namespace Garage.Application.controller;

internal class GarageMenuController(GarageMenuView view, IGarageService service)
{
    internal void StartMainMenu()
    {
        var quitMenu = false;
        var garages = service.GetAllGarages();
        do
        {
            var resultMainMenuInput = view.PrintMainMenu(garages);
            var parsedResult = ParseMainMenuInput(resultMainMenuInput);
            if (IsQuit(resultMainMenuInput.UserInput))
            {
                quitMenu = true;
            }
            else if (parsedResult != null)
            {
                StartGarageMenu(parsedResult);
            }

        } while (!quitMenu);
    }

    private bool IsQuit(string userInput)
    {
        return userInput == "q" || userInput == "Q";
    }

    private GarageInfo? ParseMainMenuInput((
        List<GarageInfo> GarageInfoItems,
        string UserInput) result)
    {
        try {
            var userInput = int.Parse(result.UserInput);
            var numerOfGarages = result.GarageInfoItems.ToList().Count();

            if (userInput > numerOfGarages || userInput < 0)
            {
                throw new InvalidOperationException("_");
            }
            return result.GarageInfoItems.ToList()[userInput];
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return null;
        }
    }

    internal void StartGarageMenu(GarageInfo garageInfo)
    {
        var quitMenu = false;
        do
        {
            var resultGarageMenuInput = view.PrintGarageMenu(garageInfo);
            if (IsQuit(resultGarageMenuInput))
            {
                quitMenu = true;
            }

        } while (!quitMenu);
    }
}

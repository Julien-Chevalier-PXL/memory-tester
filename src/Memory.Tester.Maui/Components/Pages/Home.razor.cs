namespace Memory.Tester.Maui.Components.Pages;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Code-behind of the <see cref="Home"/> component.
/// </summary>
public sealed partial class Home
{
    private readonly NavigationManager _navigationManager;

    public Home(NavigationManager navigationManager)
    {
        this._navigationManager = navigationManager;
    }

    private void NavigateToTraining()
    {
        this._navigationManager.NavigateTo("/training");
    }

    private void NavigateToQuestions()
    {
        this._navigationManager.NavigateTo("/questions");
    }
}

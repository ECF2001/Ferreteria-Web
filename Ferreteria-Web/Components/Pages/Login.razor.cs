using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Ferreteria_Web.Components.Pages;

public partial class Login : ComponentBase
{
    [Inject] private NavigationManager navManager { get; set; } = default!;

    private LoginModel loginModel = new();
    private bool isLoading = false;
    private bool loginFailed = false;
    private InputType passwordInputType = InputType.Password;
    private string passwordIcon = Icons.Material.Filled.VisibilityOff;

    private async Task HandleLogin()
    {
        isLoading = true;
        loginFailed = false;
     

        if (loginModel.Username == "admin" && loginModel.Password == "12345")
        {
            navManager.NavigateTo("/home");
        }
        else
        {
            loginFailed = true;
        }

        isLoading = false;
    }

    private void TogglePasswordVisibility()
    {
        if (passwordInputType == InputType.Password)
        {
            passwordInputType = InputType.Text;
            passwordIcon = Icons.Material.Filled.Visibility;
        }
        else
        {
            passwordInputType = InputType.Password;
            passwordIcon = Icons.Material.Filled.VisibilityOff;
        }
    }
}
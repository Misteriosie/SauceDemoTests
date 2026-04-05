using FluentAssertions;
using OpenQA.Selenium;
using SauceDemo.Framework.Pages.Base;
using SauceDemo.Framework.Web.Logging;
using SauceDemo.Framework.Pages.Inventory;

namespace SauceDemo.Framework.Pages.Login;

public sealed class LoginPage : BasePage
{
    private readonly By usernameInput = By.CssSelector("input[data-test='username']");
    private readonly By passwordInput = By.CssSelector("input[data-test='password']");
    private readonly By loginButton = By.CssSelector("input[data-test='login-button']");
    private readonly By errorMessage = By.CssSelector("h3[data-test='error']");

    public LoginPage(IWebDriver driver, int timeoutSeconds)
        : base(driver, timeoutSeconds)
    {
    }

    public void Open(string baseUrl)
    {
        TestLogger.Info("Opening login page.");
        this.NavigateTo(baseUrl);
    }

    public void EnterUsername(string username)
    {
        TestLogger.Info($"Entering username: {username}");
        this.TypeText(this.usernameInput, username);
    }

    public void EnterPassword(string password)
    {
        TestLogger.Info("Entering password.");
        this.TypeText(this.passwordInput, password);
    }

    public void ClearPassword()
    {
        TestLogger.Info("Clearing password field.");
        this.Clear(this.passwordInput);

        string actualValue = this.GetValue(this.passwordInput);
        actualValue.Should().BeEmpty("the password field must be empty before clicking Login");
    }

    public void ClickLogin()
    {
        TestLogger.Info("Clicking Login button.");
        this.Click(this.loginButton);
    }

    public InventoryPage LoginAs(string username, string password)
    {
        this.EnterUsername(username);
        this.EnterPassword(password);
        this.ClickLogin();

        return new InventoryPage(this.Driver, this.TimeoutSeconds);
    }

    public string GetErrorMessage()
    {
        TestLogger.Info("Reading error message.");
        return this.GetText(this.errorMessage);
    }
}
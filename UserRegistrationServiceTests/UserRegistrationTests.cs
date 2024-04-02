using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserRegistrationService;
namespace UserRegistrationServiceTests;
[TestClass]

public class UserRegistrationServiceTests
{
     //Testmetod för att registrera en användare och kontrollera om registreringen lyckades
    [TestMethod]
    public void UserRegistration()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var Result = registrationService.RegisterUser("Mona", "Lösenord!", "mona@hotmail.com");
        var Result1 = registrationService.RegisterUser("Sara", "Lösenord1!", "Sara@hotmail.com");

        // Assert
        Assert.AreEqual("User Mona successfully registered.", Result);
        Assert.AreEqual("User Sara successfully registered.", Result1);
    }

    // Testmetod för att validera användarnamn enligt givna krav
    [TestMethod]
    public void validUsername()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var result = registrationService.IsValidUsername("Hanna");

        // Assert
        Assert.IsTrue(result);
    }

    // Testmetod för att validera lösenord enligt givna krav
    [TestMethod]
    public void validPassword()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var result = registrationService.IsValidPassword("Lösenord!");

        // Assert
        Assert.IsTrue(result);
    }

    // Testmetod för att validera e-postadress enligt givna krav
    [TestMethod]
    public void validEmail()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var result = registrationService.IsValidEmail("user@example.com");

        // Assert
        Assert.IsTrue(result);
    }

    // Testmetod för att kontrollera om ett användarnamn redan är upptaget
    [TestMethod]
    public void DuplicateUsername()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Lägg till en användare i listan för att simulera att det redan finns en användare med samma användarnamn
        registrationService.RegisterUser("User", "password!", "user@example.com");

        // Act
        var result = registrationService.IsUsernameTaken("User1");

        // Assert
        Assert.IsTrue(result);
    }
}









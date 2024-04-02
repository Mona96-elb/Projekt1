using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserRegistrationService;
namespace UserRegistrationServiceTests;
[TestClass]

public class UserRegistrationServiceTests
{
     //Testmetod f�r att registrera en anv�ndare och kontrollera om registreringen lyckades
    [TestMethod]
    public void UserRegistration()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var Result = registrationService.RegisterUser("Mona", "L�senord!", "mona@hotmail.com");
        var Result1 = registrationService.RegisterUser("Sara", "L�senord1!", "Sara@hotmail.com");

        // Assert
        Assert.AreEqual("User Mona successfully registered.", Result);
        Assert.AreEqual("User Sara successfully registered.", Result1);
    }

    // Testmetod f�r att validera anv�ndarnamn enligt givna krav
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

    // Testmetod f�r att validera l�senord enligt givna krav
    [TestMethod]
    public void validPassword()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // Act
        var result = registrationService.IsValidPassword("L�senord!");

        // Assert
        Assert.IsTrue(result);
    }

    // Testmetod f�r att validera e-postadress enligt givna krav
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

    // Testmetod f�r att kontrollera om ett anv�ndarnamn redan �r upptaget
    [TestMethod]
    public void DuplicateUsername()
    {
        // Arrange
        var registrationService = new UserRegistrationServices();

        // L�gg till en anv�ndare i listan f�r att simulera att det redan finns en anv�ndare med samma anv�ndarnamn
        registrationService.RegisterUser("User", "password!", "user@example.com");

        // Act
        var result = registrationService.IsUsernameTaken("User1");

        // Assert
        Assert.IsTrue(result);
    }
}









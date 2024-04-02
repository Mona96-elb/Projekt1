using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationService;

public class User
{
    // Egenskaper för att lagra användarinformation: användarnamn, lösenord och e-postadress
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    // Konstruktor för att initiera användarobjekt med angivet användarnamn, lösenord och e-postadress
    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}

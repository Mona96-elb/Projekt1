using System.Collections.Frozen;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UserRegistrationService
{
    public class UserRegistrationServices
    {
        // En lista som lagrar användarobjekt för att hålla reda på registrerade användare
        public readonly List<User> Users = new List<User>();

        // Metod för att registrera en ny användare med angivet användarnamn, lösenord och e-postadress
        // Den kastar undantag om användarnamnet eller e-postadressen redan är upptagna
        public string RegisterUser(string username, string password, string email)
        {
            // Kolla om användarnamnet eller e-postadressen redan är upptagna
            if (Users.Any(u => u.Username == username))
                throw new ArgumentException($"Username '{username}' is already taken.");

            if (Users.Any(u => u.Email == email))
                throw new ArgumentException($"Email '{email}' is already registered.");

            // Skapa en ny användare och lägg till den i listan över registrerade användare
            Users.Add(new User(username, password, email));

            return $"User {username} successfully registered.";
        }

        // Metod för att validera användarnamn enligt givna krav
        // Den kastar undantag om användarnamnet inte uppfyller längd- eller teckenkraven
        public bool IsValidUsername(string username)
        {
            // Steg 1: Kontrollera längden på användarnamnet
            if (username.Length < 4 || username.Length > 10)
            {
                // Om användarnamnet inte är mellan 4 och 10 tecken långt, anses det ogiltigt
                throw new ArgumentException("Invalid username. Username must be between 4 and 10 characters long and contain only alphanumeric characters.");
            }

            // Steg 2: Kontrollera varje tecken i användarnamnet
            foreach (char c in username)
            {
                // Om ett tecken inte är en bokstav eller en siffra, anses användarnamnet ogiltigt
                if (!char.IsLetterOrDigit(c))
                {
                    throw new ArgumentException("Invalid Name. Name can't contain special characters.");
                }
            }

            // Om användarnamnet uppfyller alla krav, anses det giltigt
            return true;
        }

        // Metod för att validera lösenord enligt givna krav
        // Den kastar undantag om lösenordet inte uppfyller längd- eller specialteckenkraven
        public bool IsValidPassword(string password)
        {
            // Steg 1: Kontrollera längden på lösenordet
            if (password.Length < 8)
            {
                // Om lösenordet är kortare än 8 tecken, kasta ett undantag
                throw new ArgumentException("Invalid password. Password must be at least 8 characters long.");
            }

            // Steg 2: Kontrollera om lösenordet innehåller minst ett specialtecken
            bool containsSpecialCharacter = false;
            foreach (char c in password)
            {
                // Om ett tecken är ett specialtecken, anses lösenordet giltigt
                if (!char.IsLetterOrDigit(c))
                {
                    containsSpecialCharacter = true;
                    break; // Avbryt loopen eftersom vi redan har hittat ett specialtecken
                }
            }

            // Om lösenordet inte innehåller minst ett specialtecken, kasta ett undantag
            if (!containsSpecialCharacter)
            {
                throw new ArgumentException("Invalid password. Password must contain at least one special character.");
            }

            // Om lösenordet uppfyller alla krav, anses det giltigt
            return true;
        }

        // Metod för att validera e-postadress enligt givna krav
        // Den kastar undantag om e-postadressen inte följer det angivna formatet
        public bool IsValidEmail(string email)
        {
            // Kontrollera om e-postadressen innehåller '@' och '.'
            if (email.Contains('@') && email.Contains('.'))
            {
                return true;
            }

            // Om e-postadressen inte följer det angivna formatet, kasta ett undantag
            throw new ArgumentException("Email addresses must follow a valid format (e.g., user@example.com)");
        }

        // Metod för att kontrollera om ett användarnamn redan är upptaget
        // Den kastar undantag om användarnamnet redan finns i listan över användare
        public bool IsUsernameTaken(string username)
        {
            // Använd LINQ Any-metoden för att kontrollera om det finns någon användare med samma användarnamn
            if (Users.Any(u => u.Username == username))
            {
                // Om ett matchande användarnamn hittas, anses det vara upptaget
                throw new ArgumentException("Username is already taken, registration failed.");
            }

            // Om inget matchande användarnamn hittas, anses det inte vara upptaget
            return true;
        }
    }
}

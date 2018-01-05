using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "jail", "booked", "keys", "police", "pistol" };
    string[] level2Passwords = { "agent", "federal", "wanted", "bureau", "investigation" };
    string[] level3Passwords = { "department", "defense", "general", "terrorist", "military" };

    // Game State
    int level;
    enum Screen { MainMenu, Password, Win, Intro };
    Screen currentScreen;
    string password;
    string levelName;
    string playerName;

    // Use this for initialization
    void Start()
    {
        GetPlayerName();
    }


    void GetPlayerName()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Intro;
        Terminal.WriteLine("Please enter username to begin");
    }
    void ShowMainMenu(string playerName)
    {
        if (playerName == "007")
        {
            Terminal.ClearScreen();
            currentScreen = Screen.MainMenu;
            Terminal.WriteLine("Welcome Mr. Bond to the MI6 Terminal");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("Please select the facility in which you wish to hack.");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("1. Local Police Station");
            Terminal.WriteLine("2. FBI Field Office - Springfield, IL");
            Terminal.WriteLine("3. The Pentagon - Washington, D.C.");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("Enter Selection:");
        }
        else
        {
            Terminal.ClearScreen();
            currentScreen = Screen.MainMenu;
            Terminal.WriteLine("Welcome " + playerName + " to the Hacker-tron 2000");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("Please select the facility in which you wish to hack.");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("1. Local Police Station");
            Terminal.WriteLine("2. FBI Field Office - Springfield, IL");
            Terminal.WriteLine("3. The Pentagon - Washington, D.C.");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("Enter Selection:");
        }
    }

    void OnUserInput(string userInput)
    {
        print("The user typed " + userInput);

        if (userInput == "menu" || userInput == "Menu") // we can always go directly to main menu
        {
            ShowMainMenu(playerName);
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(userInput);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(userInput);
        }
        else if (currentScreen == Screen.Intro)
        {
            playerName = userInput;
            ShowMainMenu(playerName);
        }

    }

    void RunMainMenu(string userInput)
    {
        bool isValidLevelNumber = (userInput == "1" || userInput == "2" || userInput == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(userInput);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please enter a valid response");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter the password to access " + levelName);
        Terminal.WriteLine("hint: " + password.Anagram());
        Terminal.WriteLine("");

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                levelName = "Local Police Station";
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                levelName = "FBI Field Office";
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                levelName = "The Pentagon";
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void CheckPassword(string userInput)
    {
        if (userInput == password)
        {
            DisplayWinScreeen();
        }
        else
        {
            Terminal.WriteLine("Wrong password, try again!");
            Terminal.WriteLine("hint: " + password.Anagram());
        }
    }

    void DisplayWinScreeen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You're in!");
                Terminal.WriteLine("Here are the local criminal records");
                Terminal.WriteLine(@"
 
    _________
   /        /
  / Crime  / 
 / Record /        
/________/                
"
                );
                break;
            case 2:
                Terminal.WriteLine("You're in!");
                Terminal.WriteLine("Here is the FBI's Most Wanted list");
                Terminal.WriteLine(@"
      _________  
     /        //    
    /  FBI   //     
   /  Most  //      
  / Wanted //
 /________//
(________(/                
"
                );
                break;
            case 3:
                Terminal.WriteLine("You're in!");
                Terminal.WriteLine("Here is the Terrorist Manifesto");
                Terminal.WriteLine(@"
       ____________
     //          //
    // Pentagon //  
   //Terrorist //    
  //  Guide   //    
 //_________ //     
((__________(/               
"
                );

                break;
            default:
                Debug.LogError("Level is invalid");
                break;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //gamestate
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Welcome, to the Hackertron 2000");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Please select the facility in which you wish to hack.");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("1. Local Police Station");
        Terminal.WriteLine("2. FBI Field Office - Springfield, IL");
        Terminal.WriteLine("3. The Pentagon - Washington, D.C.");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter Selection:");
    }

    void OnUserInput(string userInput)
    {
        print("The user typed " + userInput);

        if (userInput == "menu" || userInput == "Menu") // we can always go directly to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(userInput);
        }

    }

    void RunMainMenu(string userInput)
    {
        if (userInput == "1")
        {
            level = 1;
            StartGame();
        }
        else if (userInput == "2")
        {
            level = 2;
            StartGame();
        }
        else if (userInput == "007")
        {
            Terminal.WriteLine("Welcome Agent Bond.");
        }
        else if (userInput == "poop" || userInput == "shit" || userInput == "pussy" || userInput == "crap")
        {
            Terminal.WriteLine("Please be mature when using the Hacker-tron 2000");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid response");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password.");
    }
}

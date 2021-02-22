using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace FinchTalentShow
{

    // **************************************************
    //
    // Title: Finch Control Project
    // Description: Finch control menu with options to create a talent show.
    // Application Type: Console
    // Author: Wesenberg, Scott
    // Dated Created: 2/15/2021
    // Last Modified: 2/21/2021
    //
    // **************************************************

    class Program
    {

        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }


        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
        }

        /// 
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// 
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");


                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        ///
        /// ******************************************************
        /// *               Talent Show Menu                     *
        /// ******************************************************
        ///
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixItUp(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// 
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// 
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel = lightSoundLevel + 5)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
                finchRobot.noteOff();

            }
            finchRobot.noteOff();

            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel = lightSoundLevel - 5)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// 
        /// ******************************************************
        /// *               Talent Show > Dance                  *
        /// ******************************************************
        /// 

        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance!");

            Console.WriteLine("\tThe Finch robot will now show off its dancing talents!");
            DisplayContinuePrompt();


            finchRobot.setMotors(200, -200);
            finchRobot.wait(500);
            finchRobot.setMotors(-200, 200);
            finchRobot.wait(500);
            finchRobot.setMotors(200, -200);
            finchRobot.wait(500);
            finchRobot.setMotors(-200, 200);
            finchRobot.wait(500);
            finchRobot.setMotors(200, -200);
            finchRobot.wait(500);
            finchRobot.setMotors(-200, 200);
            finchRobot.wait(500);
            finchRobot.setMotors(200, -200);
            finchRobot.wait(500);
            finchRobot.setMotors(-200, 200);
            finchRobot.wait(500);

            finchRobot.setMotors(0, 0);



            DisplayMenuPrompt("Talent Show Menu");
        }

        /// 
        /// *************************************************************
        /// *               Talent Show > Mixing It Up                  *
        /// *************************************************************
        /// 

        static void TalentShowDisplayMixItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it up!");

            Console.WriteLine("\tThe Finch robot will now show off all of its talents!");
            DisplayContinuePrompt();

            finchRobot.noteOn(261);
            finchRobot.setLED(255, 0, 0);
            finchRobot.setMotors(200, 200);
            finchRobot.wait(500);

            finchRobot.noteOn(369);
            finchRobot.setLED(0, 255, 0);
            finchRobot.setMotors(-200, -200);
            finchRobot.wait(500);

            finchRobot.noteOn(220);
            finchRobot.setLED(0, 0, 255);
            finchRobot.setMotors(200, -200);
            finchRobot.wait(500);

            finchRobot.noteOn(369);
            finchRobot.setLED(255, 255, 255);
            finchRobot.setMotors(-200, 200);
            finchRobot.wait(500);

            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            DisplayMenuPrompt("Talent Show Menu");
        }



        /// 
        /// ********************************************************
        /// *               Disconnect Finch Robot                 *
        /// ********************************************************
        /// 
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        ///
        /// *************************************************************
        /// *                  Connect Finch Robot                      *
        /// *************************************************************
        /// 

        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Your Finch Robot");

            Console.WriteLine("\tConnecting to Finch robot. Please be sure the USB cable is connected to the robot and computer.");

            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            DisplayMenuPrompt("Main Menu");

 
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }



        ///
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        ///
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        ///
        /// *****************************************************************
        /// *                  Closing Screen & Prompting                   *
        /// *****************************************************************
        ///
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }


        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }


        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

    }
}

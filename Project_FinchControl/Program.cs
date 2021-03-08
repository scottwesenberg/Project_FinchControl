using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace FinchTalentShow
{

    // **************************************************
    //
    // Title: Finch Control Project
    // Description: Finch control menu with options to create a talent show and a data recorder.
    // Application Type: Console
    // Author: Wesenberg, Scott
    // Dated Created: 2/15/2021
    // Last Modified: 2/21/2021
    //
    // **************************************************

    public enum Command
    {   
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }


    class Program
    {


        #region SET THEME
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
        #endregion
        #region MAIN MENU
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
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
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



        #endregion
        #region TALENT SHOW 

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


        #endregion
        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;


            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecoredDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;
                    case "d":
                        DataRecorderDisplayGetData(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);


        }

        static void DataRecorderDisplayGetData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayTable(temperatures);


            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {

            //
            //diplsay table headers
            //
            Console.WriteLine(
                        "Recording #".PadLeft(15) +
                        "Temp".PadLeft(15)
                        );
            Console.WriteLine(
                "----------".PadLeft(15) +
                "----------".PadLeft(15)
                );
            //
            //display table data
            //
            for (int i = 0; i < temperatures.Length; i++)
            {

                Console.WriteLine(
                    (i + 1).ToString().PadLeft(15) +
                    temperatures[i].ToString("n2").PadLeft(15)
            );
            }

        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"Data Point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch robot is ready to begin recording the temperature data.");
            DisplayContinuePrompt();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {i + 1}: {temperatures[i].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);

            }

            DisplayContinuePrompt();
            return temperatures;

        }

        /// <summary>
        /// get frequency of data points from the user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            bool validResponse = false;

            DisplayScreenHeader("Data Point Frequency");



            //validate user input
            do
            {
                Console.Write("\tFrequency of Data Points:");

                if (double.TryParse(Console.ReadLine(), out dataPointFrequency))
                {
                    if (dataPointFrequency <= 0)
                    {
                        Console.WriteLine("\tPlease enter a number for frequency.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("\t\tIt appears you did not provide a number");
                }
            } while (!validResponse);

            return dataPointFrequency;
        }

        /// <summary>
        /// get number of data points from user
        /// </summary>
        /// <returns>number of date points</returns>
        static int DataRecoredDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool validResponse = false;

            DisplayScreenHeader("Number of Data Points");
            do
            {

                string userResponse;


                Console.Write("\tNumber of Data Points:");
                userResponse = Console.ReadLine();

                if (int.TryParse(userResponse, out numberOfDataPoints))
                {
                    if (numberOfDataPoints <= 0)
                    {

                        Console.WriteLine("\tPlease enter an integer.");

                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("\t\tIt appears you did not enter an integer.");
                }


            } while (!validResponse);


            //validate user input


            return numberOfDataPoints;
        }

        #endregion
        #region ALARM SYSTEM
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {


            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Thershold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                       minMaxThresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, finchRobot);
                        break;
                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor );
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);


        }

        static void LightAlarmSetAlarm(Finch finchRobot, 
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdValue,
            int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to monitor{sensorsToMonitor}");
            Console.WriteLine("\tRange Type: {0}",rangeType);
            Console.WriteLine("\tMinimum/maximum threshold value" + minMaxThresholdValue);
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {

                if (thresholdExceeded)
                {
                    Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}.");

                }
                else
                {
                    Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was not exceeded.");
                }



                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                    
                }
                finchRobot.wait(1000);
                secondsElapsed++;

            }


            DisplayMenuPrompt("Light Alarm");
        }

        static int LightAlarmSetTimeToMonitor()
        {
            int timeToMonitor;

            DisplayScreenHeader("Time to Monitor");

            //validate value

            Console.Write($"\tTime to Monitor:");
            int.TryParse(Console.ReadLine(), out timeToMonitor);

            //echo value

            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }
        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine($"Left light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"Right light sensor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();

          //validate value

            Console.Write("Enter the light sensor value:");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);

            //echo value

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;
            DisplayScreenHeader("Sensors To Monitor");

            Console.Write("\tSensors to Monitor [right, left, both]");
            sensorsToMonitor = Console.ReadLine().ToLower();

            while (sensorsToMonitor != "right" && sensorsToMonitor != "left" && sensorsToMonitor != "both") 
            {
                Console.Write("\tPlease Enter One Of the Following");
                Console.Write("\tSensors to Monitor [right, left, both]");
            }

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;

        }
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;
            DisplayScreenHeader("Range Type");


            Console.Write("\tRange Type [minimum, maximum]");
            rangeType = Console.ReadLine().ToLower();

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }

        #endregion
        //static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        //{
        //    Console.CursorVisible = true;

        //    bool quitTalentShowMenu = false;
        //    string menuChoice;
        //    (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
        //    List<Command> commands = new List<Command>();

        //    do
        //    {
        //        DisplayScreenHeader("User Programming");

        //        //
        //        // get menu choice
        //        //
        //        Console.WriteLine("\ta) Set Command Parameters");
        //        Console.WriteLine("\tb) Add Commands");
        //        Console.WriteLine("\tc) View Commands");
        //        Console.WriteLine("\td) Execute Commands");
        //        Console.WriteLine("\tq) Main Menu");
        //        Console.Write("\t\tEnter Choice:");
        //        menuChoice = Console.ReadLine().ToLower();


        //        switch (menuChoice)
        //        {
        //            case "a":
        //                ;
        //                break;

        //            case "b":
        //                ;
        //                break;

        //            case "c":
        //                ;
        //                break;
        //            case "d":
        //                ;
        //                break;

        //            case "q":
        //                quitTalentShowMenu = true;
        //                break;

        //            default:
        //                Console.WriteLine();
        //                Console.WriteLine("\tPlease enter a letter for the menu choice.");
        //                DisplayContinuePrompt();
        //                break;
        //        }

        //    } while (!quitTalentShowMenu);
        //}

        //static void UserProgrammingDisplayGetCommandParameters(List<Command> commands)
        //{
        //    DisplayScreenHeader("Command Parameters");

        //    (int motorSpeed, int ledBrightness, double waitSeconds)commandParameters;

        //    Console.WriteLine();



        //}

        //private static (int motorSpeed, int ledBrightness, double waitSeconds) GetCommands()
        //{
        //    (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
        //}
        #region ROBOT MANAGEMENT
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

        #endregion
        #region INTERFACE
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
        #endregion
    }
}

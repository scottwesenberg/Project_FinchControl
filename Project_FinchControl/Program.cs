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
    // Last Modified: 3/21/2021
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
          

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }


        //static void SetTheme()
        //{
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.BackgroundColor = ConsoleColor.DarkCyan;
        //}
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
                Console.WriteLine("\tg) Change Applications Theme");
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
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "g":
                        DisplaySetTheme();
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



            
            do
            {
                Console.Write("\tFrequency of Data Points:");

                if (double.TryParse(Console.ReadLine(), out dataPointFrequency))
                {
                    if (dataPointFrequency <= 0)
                    {
                        Console.WriteLine("\tPlease enter a integer for frequency.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("\t\tIt appears you did not provide a integer");
                }
            } while (!validResponse);

            Console.WriteLine($"Data Point Frequency has been set to {dataPointFrequency}");

            return dataPointFrequency;

        }

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

            Console.WriteLine($"Number of Data Points is: {numberOfDataPoints}");


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
            Console.WriteLine("\tMinimum/maximum threshold value: " + minMaxThresholdValue);
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {




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

                if (thresholdExceeded)
                {
                    Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}.");

                }
                else
                {
                    Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was not exceeded.");
                }


            DisplayMenuPrompt("Light Alarm");
        }

        static int LightAlarmSetTimeToMonitor()
        {
            DisplayScreenHeader("Time to Monitor");
            bool validResponse = false;
            int timeToMonitor;
            do
            {

                Console.Write($"\tTime to Monitor:");          

                if(int.TryParse(Console.ReadLine(), out timeToMonitor))
                {
                    if (timeToMonitor <= 0)
                    {
                        Console.WriteLine("\tPlease enter a positive integer.");
                        
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("\tIt appears you did not give a valid response. Please enter a positive number.");
                   // Console.WriteLine("It appears you did not enter a positive number");
                }
            } while (!validResponse);

            Console.WriteLine($"Time to monitor is {timeToMonitor}");


            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }

static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            bool validRespose = false;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();

            //validate value
         do
         {

            Console.Write($"\tEnter the {rangeType} light sensor value:");
            if (int.TryParse(Console.ReadLine(), out minMaxThresholdValue))
            {
                if (minMaxThresholdValue <= 0)
                {
                    Console.WriteLine("Please enter a positive integer");
                }
                else
                {
                    validRespose = true;
                }
            }
            else
            {
                Console.WriteLine("Please enter a positive integer");
            }
         } while (!validRespose);

            Console.WriteLine($"The Minimun/Maximum Threshold value has been set to {minMaxThresholdValue}");

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;
            bool validResponse = false;
            DisplayScreenHeader("Sensors To Monitor");
            do
            {
                
                Console.Write("\tSensors to Monitor [right, left, both]");
                sensorsToMonitor = Console.ReadLine().ToLower();

                if (sensorsToMonitor != "right" && sensorsToMonitor != "left" && sensorsToMonitor != "both")
                {
                    Console.Write("\tPlease Enter one of the following-");
                    Console.WriteLine();
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine($"Sensors to Monitor is set to {sensorsToMonitor}");

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;

        }
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;
            bool validResponse = false;
            DisplayScreenHeader("Range Type");
            do
            {

                Console.Write("\tRange Type [minimum, maximum]:");
                rangeType = Console.ReadLine().ToLower();

                if (rangeType != "minimum" && rangeType != "maximum")
                {
                    Console.Write("\tPlease enter one of the following-");
                    Console.WriteLine();
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine($"\tRange Type has been set to {rangeType}");

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }

        #endregion
        #region USER PROGRAMMING
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false;
            string menuChoice;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");



                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;
                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgrammingMenu);
        }

        static void UserProgrammingDisplayExecuteFinchCommands(
            Finch finchRobot,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("\tFinch is ready to execute your commands.");
            DisplayContinuePrompt();

            foreach(Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandFeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.DONE:
                        commandFeedback = Command.DONE.ToString();
                        break;

                }

                Console.WriteLine($"\t{commandFeedback}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds)commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;


            bool validResponseOne = false;
            bool validResponseTwo = false;
            bool validResponseThree = false;

            do
            {

                Console.Write($"\tMotor Speed. Please enter a number between 1-255:");

                if (int.TryParse(Console.ReadLine(), out commandParameters.motorSpeed))
                {
                    if (commandParameters.motorSpeed < 1 || commandParameters.motorSpeed > 255)
                    {
                        Console.WriteLine("\tPlease enter a number between 1-255.");

                    }
                    else
                    {
                        validResponseOne = true;
                    }
                }
                else
                {
                    Console.WriteLine("\tIt appears you did not give a valid response. Please enter a number between 1-255.");
                }
            } while (!validResponseOne);

            do
            {

                Console.Write($"\tLED Brightness. Please enter a number between 1-255:");

                if (int.TryParse(Console.ReadLine(), out commandParameters.ledBrightness))
                {
                    if (commandParameters.ledBrightness < 1 || commandParameters.ledBrightness > 255)
                    {
                        Console.WriteLine("\tPlease enter a number between 1-255.");

                    }
                    else
                    {
                        validResponseTwo = true;
                    }
                }
                else
                {
                    Console.WriteLine("\tIt appears you did not give a valid response. Please enter a number between 1-255.");
                }
            } while (!validResponseTwo);

            do
            {

                Console.Write($"\tWait In Seconds. Please enter a number of seconds:");

                if (double.TryParse(Console.ReadLine(), out commandParameters.waitSeconds))
                {
                    if (commandParameters.waitSeconds < 1 )
                    {
                        Console.WriteLine("\tPlease enter a positive number.");

                    }
                    else
                    {
                        validResponseThree = true;
                    }
                }
                else
                {
                    Console.WriteLine("\tIt appears you did not give a valid response. Please enter a positive number");
                }
            } while (!validResponseThree);


            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tMotor Speed: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tDuration of wait in seconds: {commandParameters.waitSeconds}");

            return commandParameters;

        }

        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.WriteLine("\t-");

            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.Write("-\n\t-");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter a Command: ");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }

                else
                {
                    Console.WriteLine("\tPlease enter a command From the list provided.");
                }
            }
            

            
        }
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach(Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }
        #endregion
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
#region SET THEME


        static void DisplaySetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;

            themeColors = ReadThemeData();

            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            Console.Clear();

            DisplayScreenHeader("Set Theme for Application");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();
            Console.WriteLine("Would you like to change the current theme of the application? [yes | no]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();

                    DisplayScreenHeader("Set Theme for Application");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");
                    Console.WriteLine();

                    Console.Write("\tIs this the theme you would like to use?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        WriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);

                    }
                } while (!themeChosen);

            }

            DisplayContinuePrompt();

        }

        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write($"Enter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\tPlease try again. Enter a valid console color.");
                }
                else
                {
                    validConsoleColor = true;
                }
            } while (!validConsoleColor);

            return consoleColor;
        }

        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeData()
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            themeColors = File.ReadAllLines(dataPath);

            Enum.TryParse(themeColors[0], true, out foregroundColor);

            Enum.TryParse(themeColors[1], true, out backgroundColor);

            return (foregroundColor, backgroundColor);

        }

        static void WriteThemeData(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";

            File.WriteAllText(dataPath, foreground.ToString() + "\n");
            File.WriteAllText(dataPath, background.ToString());
        }
        
        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeDataExceptions(out string fileIOStatusMessage)
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor = ConsoleColor.White;
            ConsoleColor backgroundColor = ConsoleColor.Black;

            try
            {
                themeColors = File.ReadAllLines(dataPath);
                if (Enum.TryParse(themeColors[0], true, out foregroundColor) &&
                    Enum.TryParse(themeColors[1], true, out backgroundColor))
                {
                    fileIOStatusMessage = "Complete";
                }

                else
                {
                    fileIOStatusMessage = "Data file was not formatted correctly.";
                }
            }
            catch(DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to read the data file.";
            }
            return (foregroundColor, backgroundColor);
        }
        static string WriteThemeDataExceptions(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";
            string  FileIOStatusMessage = "";

            try
            {
                File.WriteAllText(dataPath, foreground.ToString() + "\n");
                File.AppendAllText(dataPath, background.ToString());
                FileIOStatusMessage = "Complete";

            }

            catch(DirectoryNotFoundException)
            {
                FileIOStatusMessage = "Unable to to locate the folder for the data file.";
            }
            catch(Exception)
            {
                FileIOStatusMessage = "Unable to write to data file.";
            }
            return FileIOStatusMessage;
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


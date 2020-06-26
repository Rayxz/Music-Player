using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Music_Player
{
    class Program
    {
        // Sequence used to exit the Music Player.
        static void EscapeSequence()
        {
            SoundPlayer jeapordyTheme = new SoundPlayer();
            jeapordyTheme.SoundLocation = @"D:\JeapordyTheme.wav";
            
            Console.Clear();
            Thread.Sleep(1000);
            jeapordyTheme.PlayLooping();
            Console.WriteLine("\tAre you sure that you would like to exit?\n");
            Thread.Sleep(1000);
            Console.WriteLine("\tPress \"Y\" to quit.");
            Thread.Sleep(1000);
            Console.WriteLine("\tPress \"N\" to abort.");
            Thread.Sleep(1000);
            Console.WriteLine("\n\tYou may now press any key.");

            ConsoleKeyInfo userKeyInfo = Console.ReadKey(true);
            Thread.Sleep(500);
            jeapordyTheme.Stop();

            if (userKeyInfo.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.Write("\tExiting");

                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(" .");
                    Thread.Sleep(500);
                }
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                TitleScreen();
            }
        }

        // Choice from Customization.
        static void Manual()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.WriteLine("\tWrite the location of the file that you would like to play.");
            Thread.Sleep(1000);
            Console.CursorVisible = true;
            Console.Write("\n\tEnter here: ");
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;
            
            if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
            {
                Console.Clear();
                EscapeSequence();
            }

            SoundPlayer userAudio = new SoundPlayer(userInput);

            try
            {
                Console.Clear();
                userAudio.PlayLooping();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo userKey;
                Console.Write($"\tNow Playing: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(userInput);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(".\n");
                Console.WriteLine("\tPress \"M\" to go to Manual.");
                Console.WriteLine("\tPress \"A\" to go to Automatic.");
                Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                userKey = Console.ReadKey(true);
                switch (userKey.Key)
                {
                    case ConsoleKey.M:
                        Console.Clear();
                        Manual();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        Automation();
                        break;
                    case ConsoleKey.T:
                        Console.Clear();
                        TitleScreen();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        EscapeSequence();
                        break;
                    default:
                        Console.Clear();
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tIncorrect Key.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                        Manual();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tThe file location, {userInput}, was not found.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);

                Manual();

            }
        }

        // Choice from Customization.
        static void Automation()
        {
            string userSelectionProcess;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.WriteLine("\tWhat file path format is the file location in?");
            Thread.Sleep(1000);
            Console.WriteLine("\n\tPress \"C\" for C:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"D\" for D:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"E\" for E:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"F\" for F:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"G\" for G:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"H\" for H:\\.");
            Thread.Sleep(500);
            Console.WriteLine("\tPress \"I\" for I:\\.");
            Thread.Sleep(1000);

            Console.WriteLine("\n\tYou may now press any key.");

            ConsoleKeyInfo userKey = Console.ReadKey(true);

            if (userKey.Key == ConsoleKey.C)
            {
                Console.Clear();
                userSelectionProcess = @"C:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }

            }
            else if (userKey.Key == ConsoleKey.D)
            {
                Console.Clear();
                userSelectionProcess = @"D:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.E)
            {
                Console.Clear();
                userSelectionProcess = @"E:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.F)
            {
                Console.Clear();
                userSelectionProcess = @"F:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.G)
            {
                Console.Clear();
                userSelectionProcess = @"G:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                userSelectionProcess += userInput + ".wav";

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.H)
            {
                Console.Clear();
                userSelectionProcess = @"H:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.I)
            {
                Console.Clear();
                userSelectionProcess = @"I:\";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                       Write \"Esc\" or \"Escape\" in order to go to the Escape Sequence.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tSpecify the file location. ");
                Console.WriteLine(@"(Example: Folder\File)" + "\n");
                Thread.Sleep(1000);
                Console.Write("\tEnter here: ");
                Console.CursorVisible = true;

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                if ((userInput == "Esc") || (userInput == "Escape") || (userInput == "esc") || (userInput == "escape"))
                {
                    Console.Clear();
                    EscapeSequence();
                }

                userSelectionProcess += userInput + ".wav";

                SoundPlayer userSelectedMusic = new SoundPlayer(userSelectionProcess);

                try
                {
                    Console.Clear();
                    userSelectedMusic.PlayLooping();
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\tNow Playing: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(userInput + ".wav");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(".\n");
                    Console.WriteLine("\tPress \"M\" to go to Manual.");
                    Console.WriteLine("\tPress \"A\" to go to Automatic.");
                    Console.WriteLine("\tPress \"T\" to return to the Title Screen.");

                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.M:
                            Console.Clear();
                            Manual();
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            Automation();
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            TitleScreen();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            EscapeSequence();
                            break;
                        default:
                            Console.Clear();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tIncorrect Key.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(2000);
                            Automation();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tThe file location, {userSelectionProcess}, was not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);

                    Automation();

                }
            }
            else if (userKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                EscapeSequence();
            }
            else
            {
                Console.Clear();
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tIncorrect Key.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);

                Automation();
            }
            
        }

        // After the Title Screen, this allows the user to customize between Manual and Automatic.
        static void Customization()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.WriteLine("\tWould you like to enter the file in Automatically or Manually?");
            Thread.Sleep(1000);
            Console.WriteLine("\n\tPress \"A\" to enter in a file automatically. (7 File Paths Only!)");
            Thread.Sleep(1000);
            Console.WriteLine("\tPress \"M\" to enter in a file manually.");
            Thread.Sleep(1000);
            Console.WriteLine("\n\tYou may now press any key.");

            ConsoleKeyInfo userKey = Console.ReadKey(true);

            if (userKey.Key == ConsoleKey.A) // If the user presses A, they will be taken to the Automatic screen.
            {
                Automation();

            }
            else if (userKey.Key == ConsoleKey.M) // If the user presses M, they will be taken to the Manual screen.
            {
                Manual();

            }
            else if (userKey.Key == ConsoleKey.Escape) // Takes the player to the Escape Sequence if they hit "Esc".
            {
                EscapeSequence();

            }
            else // If the user hits an unregonizable keypress, the process of the Customization screen will loop.
            {
                Console.Clear();
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tIncorrect Key.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);

                Customization();

            }
            
        }

        // After the Main method has been read by the compiler.
        static void TitleScreen()
        {
            // Stops the cursor from blinking in Console.
            Console.CursorVisible = false;

            // Creating a new Random object to play random music.
            Random randomNumberGenerator = new Random();
            int randomMusicPlayer = randomNumberGenerator.Next(3);

            // Music selection.
            SoundPlayer elevatorMusic = new SoundPlayer();
            elevatorMusic.SoundLocation = @"D:\ElevatorMusic.wav";
            SoundPlayer meleeTheme = new SoundPlayer();
            meleeTheme.SoundLocation = @"D:\SBMMMenu1.wav";
            SoundPlayer meleeThemeTwo = new SoundPlayer();
            meleeThemeTwo.SoundLocation = @"D:\SBMMMenu2.wav";

            if (randomMusicPlayer == 0)
            {
                try
                {
                    elevatorMusic.PlayLooping();
                }
                catch
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file, ElevatorMusic.wav, could not be found.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (randomMusicPlayer == 1)
            {
                try
                {
                    meleeTheme.PlayLooping();
                }
                catch
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file, SBMMMenu1.wav, could not be found.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (randomMusicPlayer == 2)
            {
                try
                {
                    meleeThemeTwo.PlayLooping();
                }
                catch
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file, SBMMMenu2.wav, could not be found.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // You'll see this quite a bit.
            // This quickly changes the foreground color of the console to red and then white.
            // This reminds the user that they can hit the "Esc" button in order to stop the Music Player.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                               Press \"Esc\" to leave the Music Player.\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Credentials here.
            Console.WriteLine("\tProject: Music Player");
            Console.Write("\tAuthor: Rayxz\n\n\n\n\n\n\n\n");

            // Logo which uses ASCII art.
            Console.WriteLine(@"                                __  __           _        _____  _                       
                               |  \/  |         (_)      |  __ \| |                      
                               | \  / |_   _ ___ _  ___  | |__) | | __ _ _   _  ___ _ __ 
                               | |\/| | | | / __| |/ __| |  ___/| |/ _` | | | |/ _ \ '__|
                               | |  | | |_| \__ \ | (__  | |    | | (_| | |_| |  __/ |   
                               |_|  |_|\__,_|___/_|\___| |_|    |_|\__,_|\__, |\___|_|   
                                                                          __/ |          
                                                                         |___/         ");
            Console.WriteLine("\n");
            Console.WriteLine("                                               Press any key to start!");

            // When the user presses any key that does not involve "Esc", 
            // they will be placed into the Customization screen.
            ConsoleKeyInfo userKeyInput;
            userKeyInput = Console.ReadKey(true);

            if (userKeyInput.Key == ConsoleKey.Escape) // If escape is hit, the user will be transported to the Escape Sequence.
            {
                EscapeSequence();
                elevatorMusic.Stop();

            }
            else
            {
                Customization();

            }

        }

        // Compiler starts here.
        static void Main(string[] args)
        {
            TitleScreen();

            Console.ReadLine();

        }
    }
}

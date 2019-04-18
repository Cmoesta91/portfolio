using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {

        //declared varibles to track STATS 
        static int winCounter = 0;
        static int loseCounter = 0;
        static int tieCounter = 0;


        static void Main(string[] args)
        {
            string playerInput;
            

            Console.WriteLine("Welcome to ROCK, PAPER SCISORS!!!");
            Console.WriteLine("XxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxX");
            //Rock
            Console.Write(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");

            //Paper
            Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");
            //Scisors
            Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

            Console.WriteLine("XxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxX");

            do
            {
                //getting number of Rounds from Player
                var numberOfRounds = NumRounds();

                //Running the game
                TheGame(numberOfRounds);

                //once number of Rounds are complete
                Console.WriteLine("Thanks for Playing! Here's how you did:");
                Console.WriteLine("XxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXxX");

                //STATS
                Console.WriteLine($"Number of Rounds: {numberOfRounds}");
                Console.WriteLine($"Wins: { winCounter}");
                Console.WriteLine($"Loses: {loseCounter}");
                Console.WriteLine($"Ties: {tieCounter}");

                //declaring an overall winner 
                if (winCounter > loseCounter)
                {
                    Console.WriteLine(@"
 /$$      /$$ /$$$$$$ /$$   /$$ /$$   /$$ /$$$$$$$$ /$$$$$$$  /$$
| $$  /$ | $$|_  $$_/| $$$ | $$| $$$ | $$| $$_____/| $$__  $$| $$
| $$ /$$$| $$  | $$  | $$$$| $$| $$$$| $$| $$      | $$  \ $$| $$
| $$/$$ $$ $$  | $$  | $$ $$ $$| $$ $$ $$| $$$$$   | $$$$$$$/| $$
| $$$$_  $$$$  | $$  | $$  $$$$| $$  $$$$| $$__/   | $$__  $$|__/
| $$$/ \  $$$  | $$  | $$\  $$$| $$\  $$$| $$      | $$  \ $$    
| $$/   \  $$ /$$$$$$| $$ \  $$| $$ \  $$| $$$$$$$$| $$  | $$ /$$
|__/     \__/|______/|__/  \__/|__/  \__/|________/|__/  |__/|__/
                                                                 
                                                                 
                                                                 
");
                }

                else if (winCounter < loseCounter)
                {
                    Console.WriteLine(@"
 /$$        /$$$$$$   /$$$$$$  /$$$$$$$$ /$$$$$$$  /$$
| $$       /$$__  $$ /$$__  $$| $$_____/| $$__  $$| $$
| $$      | $$  \ $$| $$  \__/| $$      | $$  \ $$| $$
| $$      | $$  | $$|  $$$$$$ | $$$$$   | $$$$$$$/| $$
| $$      | $$  | $$ \____  $$| $$__/   | $$__  $$|__/
| $$      | $$  | $$ /$$  \ $$| $$      | $$  \ $$    
| $$$$$$$$|  $$$$$$/|  $$$$$$/| $$$$$$$$| $$  | $$ /$$
|________/ \______/  \______/ |________/|__/  |__/|__/
                                                      
                                                      
                                                      
");
                }

                else
                {
                    Console.WriteLine(@"
 /$$$$$$$$ /$$           /$$$$ 
|__  $$__/|__/          /$$  $$
   | $$    /$$  /$$$$$$|__/\ $$
   | $$   | $$ /$$__  $$   /$$/
   | $$   | $$| $$$$$$$$  /$$/ 
   | $$   | $$| $$_____/ |__/  
   | $$   | $$|  $$$$$$$  /$$  
   |__/   |__/ \_______/ |__/  
                               
                               
                               
");
                    Console.WriteLine("Well that's anti-climactic...");
                }

                //Askes Player if they would like to play agian
                Console.WriteLine("Would you like to play again? (Y = Yes / N = No");
                playerInput = Console.ReadLine();


                if (playerInput == "y" || playerInput == "Y")
                {
                    Console.WriteLine(@"
 /$$   /$$ /$$$$$$$$ /$$      /$$        /$$$$$$   /$$$$$$  /$$      /$$ /$$$$$$$$
| $$$ | $$| $$_____/| $$  /$ | $$       /$$__  $$ /$$__  $$| $$$    /$$$| $$_____/
| $$$$| $$| $$      | $$ /$$$| $$      | $$  \__/| $$  \ $$| $$$$  /$$$$| $$      
| $$ $$ $$| $$$$$   | $$/$$ $$ $$      | $$ /$$$$| $$$$$$$$| $$ $$/$$ $$| $$$$$   
| $$  $$$$| $$__/   | $$$$_  $$$$      | $$|_  $$| $$__  $$| $$  $$$| $$| $$__/   
| $$\  $$$| $$      | $$$/ \  $$$      | $$  \ $$| $$  | $$| $$\  $ | $$| $$      
| $$ \  $$| $$$$$$$$| $$/   \  $$      |  $$$$$$/| $$  | $$| $$ \/  | $$| $$$$$$$$
|__/  \__/|________/|__/     \__/       \______/ |__/  |__/|__/     |__/|________/
                                                                                  
                                                                                  
                                                                                  
");

                }

                else if (playerInput == "n" || playerInput == "N")
                {
                    Console.WriteLine(@"
 /$$$$$$$$ /$$                           /$$                       /$$$$$$$$                        /$$$$$$$  /$$                     /$$                     /$$
|__  $$__/| $$                          | $$                      | $$_____/                       | $$__  $$| $$                    |__/                    | $$
   | $$   | $$$$$$$   /$$$$$$  /$$$$$$$ | $$   /$$  /$$$$$$$      | $$     /$$$$$$   /$$$$$$       | $$  \ $$| $$  /$$$$$$  /$$   /$$ /$$ /$$$$$$$   /$$$$$$ | $$
   | $$   | $$__  $$ |____  $$| $$__  $$| $$  /$$/ /$$_____/      | $$$$$ /$$__  $$ /$$__  $$      | $$$$$$$/| $$ |____  $$| $$  | $$| $$| $$__  $$ /$$__  $$| $$
   | $$   | $$  \ $$  /$$$$$$$| $$  \ $$| $$$$$$/ |  $$$$$$       | $$__/| $$  \ $$| $$  \__/      | $$____/ | $$  /$$$$$$$| $$  | $$| $$| $$  \ $$| $$  \ $$|__/
   | $$   | $$  | $$ /$$__  $$| $$  | $$| $$_  $$  \____  $$      | $$   | $$  | $$| $$            | $$      | $$ /$$__  $$| $$  | $$| $$| $$  | $$| $$  | $$    
   | $$   | $$  | $$|  $$$$$$$| $$  | $$| $$ \  $$ /$$$$$$$/      | $$   |  $$$$$$/| $$            | $$      | $$|  $$$$$$$|  $$$$$$$| $$| $$  | $$|  $$$$$$$ /$$
   |__/   |__/  |__/ \_______/|__/  |__/|__/  \__/|_______/       |__/    \______/ |__/            |__/      |__/ \_______/ \____  $$|__/|__/  |__/ \____  $$|__/
                                                                                                                            /$$  | $$               /$$  \ $$    
                                                                                                                           |  $$$$$$/              |  $$$$$$/    
                                                                                                                            \______/                \______/     
");
                    System.Environment.Exit(0);
                }


            } while (true);
        }


        //meathod for getting number of ROUNDS
        static int NumRounds()
        {
            int numRounds;

            do
            {
                Console.WriteLine("How many rounds would you like to play? (1-10)");
                int.TryParse(Console.ReadLine(), out numRounds);

                if (numRounds < 1)
                {
                    Console.WriteLine("That's too low! Try again!");

                }

                else if (numRounds > 10)
                {
                    Console.WriteLine("That's too many rounds for me! Try Again!");

                }

                else
                {
                    return numRounds;

                }

            } while (true);
        }

        //meathod for the actual GAME
        static void TheGame(int numberOfRounds)
        {

            int userGesture;

            //for loop to create rounds
            for (var i = 0; i < numberOfRounds; i++)
            {
                Console.WriteLine("Choose your weapon:");
                Console.WriteLine("Rock (= 1), Paper (= 2), or Scissors (= 3) ");
                int.TryParse(Console.ReadLine(), out userGesture);

                //Player chooses Rock
                if (userGesture == 1)
                {
                    UserRock();

                }
                //Player chooses Paper
                else if (userGesture == 2)
                {
                    UserPaper();
                }
                //Player chooses Scissors
                else if (userGesture == 3)
                {
                    UserScissors();
                }
                //Error Message
                else
                {
                    Console.WriteLine(@"
 /$$   /$$                              
| $$$ | $$                              
| $$$$| $$  /$$$$$$   /$$$$$$   /$$$$$$ 
| $$ $$ $$ /$$__  $$ /$$__  $$ /$$__  $$
| $$  $$$$| $$  \ $$| $$  \ $$| $$$$$$$$
| $$\  $$$| $$  | $$| $$  | $$| $$_____/
| $$ \  $$|  $$$$$$/| $$$$$$$/|  $$$$$$$
|__/  \__/ \______/ | $$____/  \_______/
                    | $$                
                    | $$                
                    |__/                
");
                    Console.WriteLine("That's not a weapon! Try again!");
                }

            }


        }

        //method if Player is ROCK
        static void UserRock()
        {
           

            //Computer and Player chose Rock
            if (ComGesture() == 1)
            {
                //Tie
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");
                tieCounter++;
                Console.WriteLine("A TIE?!? Mediocre.");
                
                
            }
            //Computer chose Paper and Player chose Rock
            else if (ComGesture() == 2)
            {
                //Computer Wins
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");
                loseCounter++;
                Console.WriteLine("You LOST?!? Gotta git gud scrub.");
               
             
            }
            //Computer chose Scissors and Player chose Rock
            else
            {
                //Player Wins
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

                winCounter++;
                Console.WriteLine("You WON!! CONGRADULATIONS!!");
                

            }
        }

        //method if Player is PAPER
        static void UserPaper()
        {
            

            //Computer chose Rock and Player chose Paper
            if (ComGesture() == 1)
            {

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");
                winCounter++;
                Console.WriteLine("You WON!! CONGRADULATIONS!!");
                

            }
            //Computer chose Paper and Player chose Paper
            else if (ComGesture() == 2)
            {

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");
                tieCounter++;
                Console.WriteLine("A TIE?!? Mediocre.");
                
            }
            //Computer chose Scissors and Player chose Paper
            else
            {

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

                loseCounter++;
                Console.WriteLine("You LOST?!? Gotta git gud scrub.");
                

            }
        }

        //method if Player is SCISSORS
        static void UserScissors()
        {
           

            //Computer chose Rock
            if (ComGesture() == 1)
            {

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");
                Console.WriteLine(@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
");
                loseCounter++;
                Console.WriteLine("You LOST?!? Gotta git gud scrub.");
              

            }
            //Computer chose Paper
            else if (ComGesture() == 2)
            {

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

                Console.Write(@"    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
");
                winCounter++;
                Console.WriteLine("You WON!! CONGRADULATIONS!!");
               
            }
            //Computer chose Scissors
            else
            {

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

                Console.WriteLine(@"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");

                tieCounter++;
                Console.WriteLine("A TIE?!? Mediocre.");
                

            }
        }

        //Computer Random Generator
        static int ComGesture()
        {
            int comGesture;

            Random r = new Random();
            comGesture = r.Next(1, 4);

            return comGesture;
        }




    }
}

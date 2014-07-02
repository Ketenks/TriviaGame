using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trivia game function goes here

            //begin game and welcome user
            Console.WriteLine("TRIVIA GAME");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Trivia Game of YOUR LIFE!!!\n");
            Console.WriteLine("\n");
            Console.WriteLine("What is your name?\n");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine(name + "!!! Welcome...\n");

            
            Random rNG = new Random();
            int randNum = rNG.Next(0, 5000);

            //establish game "parameters"
            
            
            int correct = 0;
            

            while (correct < 50)
            {

                //get random quesion and associated answer
                var Trivia = GetTriviaList()[randNum];
                Console.WriteLine(Trivia.Question);
                Console.WriteLine();
                string input = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (input == Trivia.Answer)
                {
                    correct++;
                    Console.WriteLine("Excellent. You only have " + (50 - correct) + " more...BWAH HAHAHAHAHAH!!!");
                    Console.WriteLine("Score: " + correct);
                    Console.WriteLine("\n");
                    randNum = rNG.Next(0, 5000);

                }
                else
                {
                                        
                    correct--;
                    Console.WriteLine("Oooh too bad! Better luck next time...");
                    Console.WriteLine("Score: " + correct);
                    Console.WriteLine("\n");
                    randNum = rNG.Next(0, 5000);
                }

            }





            Console.ReadKey();
        }


        //This function gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //split up the contents into separate categories
            List<string> geography = contents.Where(x => x.Contains("Geography:")).ToList();
            List<string> entertainment = contents.Where(x => x.Contains("Entertainment:")).ToList();
            List<string> history = contents.Where(x => x.Contains("History:") || x.Contains("199")).ToList();
            List<string> arts = contents.Where(x => x.Contains("Arts:")).ToList();
            List<string> science = contents.Where(x => x.Contains("Science:")).ToList();
            List<string> sports = contents.Where(x => x.Contains("Sports:") || x.Contains("Basketball") || x.Contains("Baseball")).ToList();
            List<string> music = contents.Where(x => x.Contains("Music:") || x.Contains("Lyrics:") || x.Contains("Name the Artist:") || x.Contains("90's Name the Artist:") || x.Contains("80's Name the Artist:") || x.Contains("70's Name the Artist:")).ToList();
            List<string> smarty = contents.Where(x => x.Contains("What is the") || x.Contains("Name the") || x.Contains("What") || x.Contains("How did") || x.Contains("Common") || x.Contains("In") || x.Contains("Useless Info") || x.Contains("Where") || x.Contains("Which") || x.Contains("Who") || x.Contains("As") || x.Contains("At")).ToList();
            List<string> films = contents.Where(x => x.Contains("80's Films") || x.Contains("Films Quotes:")).ToList();
            List<string> videoGames = contents.Where(x => x.Contains("Video Games:")).ToList();
            List<string> miscellaneous = contents.Where(x => x.Contains("Novelty Songs:") || x.Contains("Hobbies & Liesure:")  || x.Contains("DC Comics:")  || x.Contains("Literary Characters:")  || x.Contains("Misc Games:")  || x.Contains("Couples:")  || x.Contains("Food:")  || x.Contains("Math")  || x.Contains("Ad Slogans")  || x.Contains("Alcohol and Games:")  || x.Contains("Dr Suess:")  || x.Contains("Toys")  || x.Contains("Junk")  || x.Contains("Food:")).ToList();
            
            //Each item in list "contents" is now one line of the Trivia.txt document.
            
            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            //Trivia Question1 = Trivia(
            List<string> temp = new List<string> {};
            foreach (string item in contents) 
            { 
                
                Trivia myTriv = new Trivia(item); 
                returnList.Add(myTriv); 
            }
            
            
            
            //Return the full list of trivia objects
            return returnList;
        }
    }
}

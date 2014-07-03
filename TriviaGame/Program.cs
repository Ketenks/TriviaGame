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
        //set global variables to make changes across the game
        //each list is the initialization of objects by category
        //the last is the "temp" object for calling the specific question chosen
        public static List<Trivia> geoList = new List<Trivia>();
        public static List<Trivia> enterList = new List<Trivia>();
        public static List<Trivia> histList = new List<Trivia>();
        public static List<Trivia> artList = new List<Trivia>();
        public static List<Trivia> sciList = new List<Trivia>();
        public static List<Trivia> sportList = new List<Trivia>();
        public static List<Trivia> musList = new List<Trivia>();
        public static List<Trivia> smartList = new List<Trivia>();
        public static List<Trivia> filmList = new List<Trivia>();
        public static List<Trivia> vidList = new List<Trivia>();
        public static List<Trivia> miscList = new List<Trivia>();
        //"temp" object
        public static Trivia Trivias = null;


        static void Main(string[] args)
        {
            //Trivia game function goes here

            //begin game and welcome users           
            Console.WriteLine("TRIVIA GAME");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Trivia Game of YOUR LIFE!!!\n");
            Console.WriteLine("\n");
            Console.WriteLine("What is your name?\n");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine(name + "!!! Welcome...\n");

            //establish game "parameter"                        
            int correct = 0;

            while (correct < 50)
            {
                //indicate to the user what options they have
                //receive the selection from the user
                Console.WriteLine("\nYou have these selections:\n-------------------------\nGeography\tEntertainment\tHistory\nArts\t\tScience\t\tSports\nMusic\t\tFilms\t\tSmarty\nVideo Games\tMiscellaneous\n\nChoose whichever topic you would like");
                string topic = Console.ReadLine().ToLower();
                Console.WriteLine();

                //begin random generator
            Random rNG = new Random();

                //conditions for user choice
                //create instance of the random generator for the category chosen
                //set the trivia object to the category list for the random number
            if (topic == "geography")
            {
                int randNum1 = rNG.Next(0, geoList.Count);
                 Trivias = geoList[randNum1];
            }
            else if (topic == "entertainment")
            {
                int randNum1 = rNG.Next(0, enterList.Count);
                 Trivias = enterList[randNum1];
            }
            else if (topic == "history")
            {
                int randNum1 = rNG.Next(0, histList.Count);
                Trivias = histList[randNum1];
            }
            else if (topic == "arts")
            {
                int randNum1 = rNG.Next(0, artList.Count);
                Trivias = artList[randNum1];
            }
            else if (topic == "science")
            {
                int randNum1 = rNG.Next(0, sciList.Count);
                Trivias = sciList[randNum1];
            }
            else if (topic == "sports")
            {
                int randNum1 = rNG.Next(0, sportList.Count);
                Trivias = sportList[randNum1];
            }
            else if (topic == "miscellaneous")
            {
                int randNum1 = rNG.Next(0, miscList.Count);
                Trivias = miscList[randNum1];
            }
            else if (topic == "video games")
            {
                int randNum1 = rNG.Next(0, vidList.Count);
                Trivias = vidList[randNum1];
            }
            else if (topic == "music")
            {
                int randNum1 = rNG.Next(0, musList.Count);
                Trivias = musList[randNum1];
            }
            else if (topic == "smarty")
            {
                int randNum1 = rNG.Next(0, smartList.Count);
                Trivias = smartList[randNum1];
            }
            else if (topic == "films")
            {
                int randNum1 = rNG.Next(0, filmList.Count);
                Trivias = filmList[randNum1];
            }
            else //set the default question maker if no choice is made
            {                
                int randNum = rNG.Next(0, 4592);
                Trivias = GetTriviaList()[randNum];

                //indicate to the user that it is no use trying to escape
                Console.WriteLine("Is that so? Then we have selected one for you...BWAH AHHAHAHHAHAHA!!");
                Console.WriteLine("--------------------------------------------------------------------");
                
            }
                          
                 //write question
                Console.WriteLine(Trivias.Question);
                Console.WriteLine();

                //get user answer
                string input = Console.ReadLine().ToLower();
                Console.WriteLine();

                //indicate to the user their futile attempts to get out are...amusing
                if (input == Trivias.Answer)
                {
                    correct++;
                    Console.WriteLine("________________________________________________________________________________");
                    Console.WriteLine("Excellent. You only have " + (50 - correct) + " more...BWAH HAHAHAHAHAH!!!");
                    Console.WriteLine("Score: " + correct);
                    Console.WriteLine("________________________________________________________________________________");
                    
                    

                }
                else //never let them out!!
                {
                                        
                    correct--;
                    Console.WriteLine("________________________________________________________________________________");
                    Console.WriteLine("Oooh too bad! Better luck next time...HEH HEHE HAHAHAHAHAHAH AHHAHA...HAAaaa...");
                    Console.WriteLine("Score: " + correct);
                    Console.WriteLine("________________________________________________________________________________");
                    
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
            
            
            //run a loop and make a full list of all questions and a list for each category
            //initialize the individual object by category
            //add to the full list
            //add to the category list
            foreach (string item in geography) 
            { 
                
                Trivia geoTriv = new Trivia(item); 
                returnList.Add(geoTriv);
                geoList.Add(geoTriv);
            }
            foreach (string item in entertainment)
            {

                Trivia enterTriv = new Trivia(item);
                returnList.Add(enterTriv);
                enterList.Add(enterTriv);
            }
            foreach (string item in history)
            {

                Trivia histTriv = new Trivia(item);
                returnList.Add(histTriv);
                histList.Add(histTriv);
            }
            foreach (string item in arts)
            {

                Trivia artTriv = new Trivia(item);
                returnList.Add(artTriv);
                artList.Add(artTriv);
            }
            foreach (string item in science)
            {

                Trivia sciTriv = new Trivia(item);
                returnList.Add(sciTriv);
                sciList.Add(sciTriv);
            }
            foreach (string item in sports)
            {

                Trivia sportTriv = new Trivia(item);
                returnList.Add(sportTriv);
                sportList.Add(sportTriv);
            }
            foreach (string item in music)
            {

                Trivia musTriv = new Trivia(item);
                returnList.Add(musTriv);
                musList.Add(musTriv);
            }
            foreach (string item in films)
            {

                Trivia filmTriv = new Trivia(item);
                returnList.Add(filmTriv);
                filmList.Add(filmTriv);
            }
            foreach (string item in smarty)
            {

                Trivia smartTriv = new Trivia(item);
                returnList.Add(smartTriv);
                smartList.Add(smartTriv);
            }
            foreach (string item in videoGames)
            {

                Trivia vidTriv = new Trivia(item);
                returnList.Add(vidTriv);
                vidList.Add(vidTriv);
            }
            foreach (string item in miscellaneous)
            {

                Trivia miscTriv = new Trivia(item);
                returnList.Add(miscTriv);
                miscList.Add(miscTriv);
            }
            
            
            
            //Return the full list of trivia objects
            return returnList;
        }
    }
}

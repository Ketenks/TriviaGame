using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Trivia
    {
        //define the properties for the game
        public string Question  {get; set;}
        public string Answer { get; set; } 

        //TODO: Fill out the Trivia Object
        public Trivia(string content)
        {
            List<string> temp = new List<string> { };
           temp = content.Split('*').ToList();
           this.Question = temp[0];
           this.Answer = temp[1];
        }

        //default constructor
        public Trivia()
        {
            this.Question = "undefined"; this.Answer = "undefined";
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }

    public class ChoiceQuestion
    {
        public List<string> choices;

        public ChoiceQuestion()
        {

            choices = new List<string>();
        }

        public void addChoice(String choice, Boolean correct)
        {
            
            choices.Add(choice);
            
            if (correct)
            {
                String choiceString = "" + choices.Count;
                setAnswer(choiceString);
            }
        }

        public void display()
        {
            display();
            for(int i= 0; i <choices.Count; i++)
            {
             
                int choiceNumber = i + 1;
                Console.WriteLine($"{choiceNumber}: {choices.ElementAt(i)}");
            }
        }

        public class Question
        {
            public String text;
            public String answer;

            public Question()
            {
                text = "";
                answer = "";
            }

            public void setText(String questionText)
            {
                text = questionText;
            }

            public void setAnswer(String correctResponse)
            {

            }
        }
    }

}

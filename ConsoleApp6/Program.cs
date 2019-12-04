﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IQuestion> questions = new List<IQuestion>(); 

            Question first = new Question();
            first.difficulty = 3;
            first.setText($"Who was the inventor of Java?");
            first.setAnswer("James Gosling");
            questions.Add(first);


            ChoiceQuestion second = new ChoiceQuestion();
            second.difficulty = 1;
            second.setText("In which country was the inventor of Java born?");
            second.addChoice("Australia", false);
            second.addChoice("Canada", true);
            second.addChoice("Denmark", false);
            second.addChoice("United States", false);
            questions.Add(second);
                       
        }


       
        public static void questionOrderer(List<IQuestion> questions)
        {
            var orderedQuestions = from q in questions
                                   orderby q.difficulty
                                   select q;

            foreach (IQuestion q in orderedQuestions)
            {
                presentQuestion(q);
            }
        }

        public static void presentQuestion(IQuestion q)
        {
            Console.WriteLine($"Difficulty: {q.difficulty}");
            q.display();
            Console.Write("Your answer: ");
            string response = Console.ReadLine();
            Console.WriteLine(q.checkAnswer(response));
            Console.WriteLine();
        }
    }

    public interface IQuestion
    {
        int difficulty { get; set; }
        void setText(String questionText);
        void setAnswer(String correctResponse);
        Boolean checkAnswer(String response);
        void display();

    }

    public class Question : IQuestion
    {
        public String text;
        public String answer;
        public int _difficulty;
        public int difficulty
        {
            get => _difficulty;
            set
            {
                if (value < 4)
                {
                    _difficulty = value;
                }
                else
                {
                    _difficulty = -1;
                }

            }
        }


        public Question()
        {
            text = "";
            answer = "";
            _difficulty = 0;
        }

        

        public void setText(String questionText)
        {
            text = questionText;
        }

        public void setAnswer(String correctResponse)
        {
            answer = correctResponse;
        }

        public Boolean checkAnswer(String response)
        {
            return response.Equals(answer);
        }

        public void display()
        {
            Console.WriteLine(text);
        }

    }

    public class ChoiceQuestion : IQuestion
    {
        public List<string> choices;
        public String text;
        public String answer;
        public int _difficulty;
        public int difficulty
        {
            get => _difficulty;
            set
            {
                if (value < 4)
                {
                    _difficulty = value;
                }
                else
                {
                    _difficulty = -1;
                }
            }
        }

        public ChoiceQuestion()
        {
            choices = new List<string>();
            text = "";
            answer = "";
            _difficulty = 0;
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

        public void setDifficulty(int graad)
        {

        }

        public void setText(String questionText)
        {
            text = questionText;
        }

        public void setAnswer(String correctResponse)
        {
            answer = correctResponse;
        }

        public Boolean checkAnswer(String response)
        {
            return response.Equals(answer);
        }

        public void display()
        {
            Console.WriteLine(this.text);
            for (int i = 0; i < choices.Count; i++)
            {
                int choiceNumber = i + 1;
                Console.WriteLine($"{choiceNumber}: {choices.ElementAt(i)}");
            }
        }
    }

    

   

}

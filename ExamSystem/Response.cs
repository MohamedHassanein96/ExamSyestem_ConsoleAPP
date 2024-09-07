using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    partial class Response : QuestionForm
    {
        static public List<int> StudentMark = new List<int>();
        static public List<string> StudentResponse = new List<string>();

        static DateTime now = DateTime.Now;

        public static void SetResponse()
        {
            if (Questions.Count == 0)
            {
                Console.WriteLine("Sorry, there is no exam yet");
                Environment.Exit(0);
            }
            else
            {

                string studentResponse;
                Console.WriteLine($"\nTime now is {now}.");
                var count = Questions.Count();
                Console.WriteLine($"the count of the Questions is {count}.");
                Console.WriteLine($"you have 30 seconds only for every Question.");
                for (int i = 0; i < Questions.Count; i++)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

              

                    if (TypeOfQuestions[i] == "MultipleChoice Responses")
                    {
                        Console.WriteLine($"\nType Of Question: {TypeOfQuestions[i]} \nlevel:{Levels[i]}     \nMark: {Marks[i]}     \nQuestion is: {Questions[i]}");
                        Console.WriteLine("\npotential responses. ");
                        Display(MultipleChoicePotentialResponses);
                        Console.WriteLine($"\nchoose between.");
                        Display(MultipleChoicePotentialResponsesList);
                    }

                    if (TypeOfQuestions[i] == "Choose One Response")
                    {
                        Console.WriteLine($"\nType Of Question: {TypeOfQuestions[i]} \nlevel:{Levels[i]}     \nMark: {Marks[i]}     \nQuestion is: {Questions[i]}");
                        Console.WriteLine("\npotential responses. ");
                        Display(ChooseOnePotentialResponses);
                        Console.WriteLine($"\nchoose between. ");
                        Display(ChooseOnePotentialResponsesList);

                    }

                    if (TypeOfQuestions[i] == "True or False Question")
                    {
                        Console.WriteLine($"\nType Of Question: {TypeOfQuestions[i]} \nlevel:{Levels[i]}     \nMark: {Marks[i]}     \nQuestion is: {Questions[i]}");
                        Console.WriteLine("True or False.");
                    }

                    Console.Write($"Enter a response you have {30} seconds). ");
                    Console.WriteLine("\nCopy and paste one of them.");
                    studentResponse = "";

                    while (stopwatch.ElapsedMilliseconds < 30000 && string.IsNullOrEmpty(studentResponse))
                    {
                        if (Console.KeyAvailable) // in case of entering an input from the user 
                        {
                            studentResponse = Console.ReadLine();

                        }
                    }
                    stopwatch.Stop();

                    if (string.IsNullOrEmpty(studentResponse))  // in case of  not entering an input from the user 
                    {
                        Console.WriteLine("\nTime's up! Moving to the next question.");
                        StudentMark.Add(0);
                    }
                    else
                    {
                        if (Responses[i] == studentResponse.Trim().ToLower())
                        {
                            StudentMark.Add(Marks[i]);

                            Console.WriteLine($"Correct, your mark is {StudentMark[i]}");
                            Console.WriteLine("\n(------------)");
                        }
                        else
                        {
                            StudentMark.Add(0);
                            Console.WriteLine($"Incorrect, your mark is = 0 ");
                            Console.WriteLine("\n(------------)");
                        }
                    }
                }

            }
        }

        public static void GetQuestionsByLevel()
        {
            string input;

            Console.WriteLine("Which level do you want? (Easy, Medium, Hard)");
            input = Console.ReadLine();


            for (int i = 0; i < Levels.Count; i++)
            {
                if (input == Levels[i])
                {

                    Console.WriteLine($"the Question is {Questions[i]}");
                }

            }

        }
        static public void FinalResult()

        {
            double examPoints = 0;
            double studentResult = 0;

            foreach (var item in Marks)
            {
                examPoints += item;
            }

            foreach (var item in StudentMark)
            {
                studentResult += item;
            }

            if (studentResult >= (examPoints/2))
            {

                Console.WriteLine($"Exam Points is {examPoints}.");
                Console.WriteLine($"your final result is {studentResult}.");
                Console.WriteLine("you passed the exam.");
            }
            else
            {
                Console.WriteLine($"Exam Points is {examPoints}.");
                Console.WriteLine($"your final result is {studentResult}.");
                Console.WriteLine("you haven't passed the exam.");
            }
          
            Environment.Exit(0);
        }
      
    }
}


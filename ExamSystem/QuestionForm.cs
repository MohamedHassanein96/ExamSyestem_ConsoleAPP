using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{


    public class QuestionForm
    {


        static public List<string> Questions = new List<string>();          // to store the Questions
        static public List<string> TypeOfQuestions = new List<string>();    // to store the TypeOfQuestions
        static public List<string> Levels = new List<string>();             // to store the LevelOfQuestions
        static public List<string> Responses = new List<string>();          // to store the Responses
        static public List<int> Marks = new List<int>();                    // to store Marks


        static public string response;
        static public List<string> TrueFalseOptions = new List<string> { "true", "false" };


        static public List<string> ChooseOnePotentialResponses = new List<string> ();                            // to fill by the doctor
        static public List<string> ChooseOnePotentialResponsesList = new List<string> { "1", "2", "3" };          
        


        static public List<string> MultipleChoicePotentialResponses = new List<string>();                         // to fill by the doctor  
        static public List<string> MultipleChoicePotentialResponsesList = new List<string> { "1 2", "2 3", "3 1" };



        // Method to Display a Generic list
        static public void Display<T>(List<T> t)
        {
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
        }

        // Method takes a custom string as question and takes a list of string to make ensure that the response is one of the list
        static public string CheckTheInput(string message, List<string> options)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (!options.Contains(input.Trim(), StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                }
            } while (!options.Contains(input.Trim(), StringComparer.OrdinalIgnoreCase));
            return input;
        }



        static public void SetQuestions()
        {
 
            Console.Write("How Many Questions you Want ? ");
            if (int.TryParse(Console.ReadLine(), out int numOfQuestions))
            {
                if (numOfQuestions <= 0)
                {
                    Console.WriteLine("The number must be greater than zero.");

                }
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                return;
            }



            var levelOptions = new List<string> { "Easy", "Medium", "Hard" };
            for (int i = 0; i < numOfQuestions; i++)

            {

                string level = CheckTheInput("\nChoose the level of Question \n" +
                    "Easy, Medium, Hard " +
                    "\nCopy and paste one of them: ", levelOptions);
                Levels.Add(level);


                var QuestionTypes = new List<string> { "True or False Question", "Choose One Response", "MultipleChoice Responses" };
                string questiontype = CheckTheInput("\nChoose the type of Question  \n1- True or False Question  \n2- Choose One Response  \n3- MultipleChoice Responses \nCopy and paste one of them: ", QuestionTypes);
                TypeOfQuestions.Add(questiontype);



                int mark;
                do
                {
                    Console.Write($"\nQuestion Mark: ");
                }
                while (!int.TryParse(Console.ReadLine(), out mark));
                Marks.Add(mark);



                Console.Write("\nEnter the Question: ");
                Questions.Add(Console.ReadLine());


                switch (questiontype)
                {
                    case "True or False Question":
                        
                        response = CheckTheInput("\n(True/False?)", TrueFalseOptions);
                        Responses.Add(response.Trim().ToLower());
                        Console.WriteLine("\n(------------)");
                        break;


                    case "Choose One Response": 
                        for (int j = 0; j <= 2; j++)
                        {
                            Console.Write($"Enter potential Response  {j+1} ");
                            ChooseOnePotentialResponses.Add(Console.ReadLine());
                        }
                        response = CheckTheInput("\nEnter Correct Option { \"1\", \"2\", \"3\"} ", ChooseOnePotentialResponsesList);
                        Responses.Add(response.Trim().ToLower());
                        Console.WriteLine("\n(------------)");
                        break;


                    case "MultipleChoice Responses":
                        for (int j = 0; j <= 2; j++)
                        {
                            Console.Write($"Enter Option {j+1} : ");
                            MultipleChoicePotentialResponses.Add(Console.ReadLine());
                        }
                        Console.WriteLine("choose between ");
                        Console.WriteLine("1 2");
                        Console.WriteLine("2 3");
                        Console.WriteLine("3 1");

                        do
                        {
                            Console.WriteLine("enter the correct option ");
                            response = Console.ReadLine();
                            if (MultipleChoicePotentialResponsesList.Contains(response.Trim().ToLower()))
                            {
                                Responses.Add(response.ToLower().Trim());
                                Console.WriteLine("\n(------------)");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input. Please try again.");
                            }
                        } while (!MultipleChoicePotentialResponsesList.Contains(response.Trim().ToLower()));
                        break;

                }


            }
        }
    }
}

        
    


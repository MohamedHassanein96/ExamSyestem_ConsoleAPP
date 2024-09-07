namespace ExamSystem
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                string input;
                Console.Write("Doctor Or Student ? ");
                input = Console.ReadLine();

               

                switch (input.Trim())
                {
                    case "Doctor":
                    case "doctor":
                        QuestionForm.SetQuestions();
                        break;
                    case "Student":
                    case "student":
                        Response.SetResponse();
                        Response.FinalResult();
                        //Response.GetQuestionsByLevel(); method to get the QS by its level
                        break;

                    default:
                        Console.WriteLine("invalid input");
                        break;

                }
            }
        }
    }
}

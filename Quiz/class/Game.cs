using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
        internal class Game
    {
        public int point { get; set; }
        public List<Question> questions { get; set; }
        public List<Answer> answers { get; set; }
        public Game(List<Question> questionsList, List<Answer> answerList)
        {
            point = 0;
            questions = questionsList;
            answers = answerList;
        }
        public void IncrementsScore()
        {
            point++;
        }
        public void ShowAnswers()
        {
            Console.WriteLine("Voici vos réponses : ");
            foreach (Answer answer in answers)
            {
                Console.WriteLine($"{answer.question} : ");
                if(answer.answer== answer.correctAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"Votre réponse : {answer.answer}");
                    Console.WriteLine($"La bonne réponse : {answer.correctAnswer}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Faux!");
                    Console.WriteLine($"Votre réponse : {answer.answer}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"La bonne réponse : {answer.correctAnswer}");
                }           
            }
        }
    }
}

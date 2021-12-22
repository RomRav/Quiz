using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            string stringInAnswer = "";
            Regex inputCheck = new Regex(@"^[1]?[0 - 9] ?");
            while (play)
            {
                Console.WriteLine("Capital Quiz:");
                Game game = GameCreator();
                foreach(var item in game.questions)
                {
                    do
                    {
                        Console.WriteLine(item.question);
                        Console.WriteLine(("Faite votre choix en tapant le numéro de la réponse : (1,2,3,4,5)"));
                        stringInAnswer = Console.ReadLine();
                    } while (inputCheck.IsMatch(stringInAnswer));
                    
                    
                }

            }
            
           
        }
        public static Game GameCreator()
        {
            List<Question> questionList = new List<Question>()
            {
            new Question()
                {
                    question = "Quel est la capitale de la Chine?",
                    choice = new Dictionary<string, bool>() { { "Pekin", true }, { "Shanghai", false }, { "Bejin", false }, { "phnom penh", false }, { "Nepido", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de la Birmanie?",
                    choice = new Dictionary<string, bool>() { { "Nepido", true }, { "Sri Jayawardenapura Kotte", false }, { "Vientiane", false }, { "Oman", false }, { "Sanaa", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de l'Australie?",
                    choice = new Dictionary<string, bool>() { { "Sydney", false }, { "Johannesburg", false }, { "Canberra", true }, { "Doha", false }, { "Bridgetown", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de la Hongrie?",
                    choice = new Dictionary<string, bool>() { { "KingTown", false }, { "Berne", false }, { "Minsk", false }, { "Vilnius", false }, { "Budapest", true } }
                },
                new Question()
                {
                    question = "Quel est la capitale du Maroc?",
                    choice = new Dictionary<string, bool>() { { "Ouarzazate", false }, { "Rabat", true }, { "Buenos Aires", false }, { "Marrakech", false }, { "Le Cap", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale du Brezil?",
                    choice = new Dictionary<string, bool>() { { "Brazzaville", false }, { "São Paulo", false }, { "Buenos Aires", false }, { "Brasília", true }, { "Rio de Janeiro", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale du Sri Lanka?",
                    choice = new Dictionary<string, bool>() { { "Sri Jayawardenapura Kotte", true }, { "Dar es Salam", false }, { "Djouba", false }, { "Bahia", false }, { "Noursoultan", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de la Finland?",
                    choice = new Dictionary<string, bool>() { { "Vantaa", false }, { "Helsinki", true }, { "Munkkiranta", false }, { "Espoo", false }, { "Jyväskylä", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de la Finland?",
                    choice = new Dictionary<string, bool>() { { "Vantaa", false }, { "Helsinki", true }, { "Munkkiranta", false }, { "Espoo", false }, { "Jyväskylä", false } }
                },
                new Question()
                {
                    question = "Quel est la capitale de la Turkménistan?",
                    choice = new Dictionary<string, bool>() { { "Ankara", false }, { "Konya", false }, { "Khartoum", false }, { "Achgabat", true }, { "Nairobi", false } }
                }
            };
            Game game = new Game(questionList);
            return game;
        }
        public static bool InputCheck(string input)
        {
            bool inputIsOK = false;
            
            if (inputCheck.IsMatch(input))
            {
                inputIsOK = true;
            }
            return inputIsOK;
        }
    }
}

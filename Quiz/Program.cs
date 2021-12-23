using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        public static Game game = GameCreator();
        static void Main(string[] args)
        {
            bool play = true;
            string stringInAnswer = "";
            Regex inputCheck = new Regex(@"^[1 - 5]");
            string playAgain = "";
            int inpuInInt;
            while (play)
            {
                Console.WriteLine("Capital Quiz:");             
                foreach(var item in game.questions)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int choiceNumber = 1;
                    Console.WriteLine("Quelle est la capitale du pays suivant? : ");
                    Console.WriteLine($"----------{item.question}----------");
                    foreach(var choice in item.choices)
                    {
                        Console.WriteLine($"{choiceNumber} - {choice.Key}");
                        choiceNumber++; 
                    }
                    do 
                    { 
                        Console.WriteLine(("Faite votre choix en tapant le numéro de la réponse : (1,2,3,4,5)"));
                        Console.ForegroundColor = ConsoleColor.Black;
                        stringInAnswer = Console.ReadLine();   
                        if(int.TryParse(stringInAnswer, out inpuInInt))
                        {
                            if (inpuInInt > 0 && inpuInInt < 6)
                            {
                                answerManager(item,inpuInInt);
                                   
                            break;
                            }
                            else
                            {
                                Console.WriteLine("Saisie incorrect, merci de saisir un numéro entre 1 et 5");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Saisie n'est pas un nombre, merci de saisir un numéro entre 1 et 5");
                        }
                    } while (true);
                        
                }
                game.ShowAnswers();
                Console.WriteLine($"Votre score est de {game.point}/ {game.questions.Count}.");
                do
                {
                    Console.WriteLine($"Voulez vous refaire le quiz? : (oui/non)");
                    playAgain = Console.ReadLine();
                    if (playAgain == "oui")
                    {
                        play = true;
                        break;
                    }
                    else if (playAgain == "non")
                    {
                        play = false;
                        Console.WriteLine("Fin");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Saisie incorect, merci de saisir oui ou non : ");
                    }
                } while (true);               
            }         
        }
        public static Game GameCreator()
        {
            string[] capitalCountryTab;
            Random random = new Random();
            var currentDirectory = Directory.GetCurrentDirectory();
            var capitalDirectory = Path.Combine(currentDirectory, "capitale.txt");
            var capitalFile = System.IO.File.ReadAllText($"{currentDirectory}{Path.DirectorySeparatorChar}capitale.txt");
            List<string> capitalCountryList = capitalFile.Split('\n').ToList();
            List<Question> questionList = new List<Question>();
            //Crée la liste de toutes les capitale.
            List<string> capitalList = new List<string>();          
            Question question = new Question();
            foreach (var capitalCountry in capitalCountryList)
            {
                capitalCountryTab = capitalCountry.Split(',');

                if (capitalCountryTab[0] != "" && capitalCountryTab[1] != "Capitale")
                {
                    capitalList.Add(capitalCountryTab[1]);
                }
            }
            //Boucle sur les pays et récupére la capitale et le pays dans une class Question.
            foreach(string capitalCountry in capitalCountryList)
            {
                question = new Question();
                if (questionList.Count >= 10)
                {
                    break;
                }
                string[] capitalTab = capitalCountry.Split(',');
                question.question = capitalTab[2];
                question.choices= new Dictionary<string, bool>() { { capitalTab[1], true } };
                //Ajoute aux choix de réponse 4 autres capital au hasard.
                
                string[] capitalInArray = capitalList.ToArray();
                while (question.choices.Count < 5)
                {
                    int randNumber = random.Next(0, capitalInArray.Length);
                    if (question.choices.ContainsKey(capitalInArray[randNumber]) == false)
                    {
                        question.choices.Add(capitalInArray[randNumber], false);
                    }                 
                }
                questionList.Add(question);
            }
            

            List<Answer> answerList = new List<Answer>();
            Game game = new Game(questionList, answerList);
            return game;

            //List<Question> questionList = new List<Question>()
            //{
            //new Question()
            //    {
            //        question = "Quelle est la capitale de la Chine?",
            //        choices = new Dictionary<string, bool>() { { "Pekin", true }, { "Shanghai", false }, { "Bejin", false }, { "phnom penh", false }, { "Nepido", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de la Birmanie?",
            //        choices = new Dictionary<string, bool>() { { "Nepido", true }, { "Sri Jayawardenapura Kotte", false }, { "Vientiane", false }, { "Oman", false }, { "Sanaa", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de l'Australie?",
            //        choices = new Dictionary<string, bool>() { { "Sydney", false }, { "Johannesburg", false }, { "Canberra", true }, { "Doha", false }, { "Bridgetown", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de la Hongrie?",
            //        choices = new Dictionary<string, bool>() { { "KingTown", false }, { "Berne", false }, { "Minsk", false }, { "Vilnius", false }, { "Budapest", true } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale du Maroc?",
            //        choices = new Dictionary<string, bool>() { { "Ouarzazate", false }, { "Rabat", true }, { "Buenos Aires", false }, { "Marrakech", false }, { "Le Cap", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale du Brezil?",
            //        choices = new Dictionary<string, bool>() { { "Brazzaville", false }, { "São Paulo", false }, { "Buenos Aires", false }, { "Brasília", true }, { "Rio de Janeiro", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale du Sri Lanka?",
            //        choices = new Dictionary<string, bool>() { { "Sri Jayawardenapura Kotte", true }, { "Dar es Salam", false }, { "Djouba", false }, { "Bahia", false }, { "Noursoultan", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de la Finland?",
            //        choices = new Dictionary<string, bool>() { { "Vantaa", false }, { "Helsinki", true }, { "Munkkiranta", false }, { "Espoo", false }, { "Jyväskylä", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de la Samoa?",
            //        choices = new Dictionary<string, bool>() { { "Vaega", false }, { "Malua", false }, { "Apia", true }, { "Espoo", false }, { "Satapuala", false } }
            //    },
            //    new Question()
            //    {
            //        question = "Quelle est la capitale de la Turkménistan?",
            //        choices = new Dictionary<string, bool>() { { "Ankara", false }, { "Konya", false }, { "Khartoum", false }, { "Achgabat", true }, { "Nairobi", false } }
            //    }
            //};
            return game;
        }
        public static void answerManager(Question question, int input)
        {
            Answer answer = new Answer();
            answer.question = question.question;
            int i = 1;
            foreach (var choice in question.choices)
            {
                if (choice.Value == true)
                    answer.correctAnswer = choice.Key;
                if (i == input)
                {
                    answer.answer = choice.Key;
                    if (choice.Value == true)
                    {
                        
                        game.IncrementsScore();
                    }
                }
                i++;
            }
            game.answers.Add(answer);
        }
    }
}

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

        public Game(List<Question>questionsList)
        {
            point = 0;
            questions = questionsList;
        }

        public void IncrementsScore()
        {
            point++;
        }
    }

}

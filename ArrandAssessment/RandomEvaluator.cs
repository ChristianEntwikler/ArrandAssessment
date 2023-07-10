using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrandAssessment
{
    public class RandomEvaluator
    {
        //Method for generating random numbers
        public int RandomGenerator(int firstVal, int lastVal)
        {
            int response = 0;
            Random rand = new Random();
            response = rand.Next(firstVal, lastVal);
            return response;
        }
    }
}

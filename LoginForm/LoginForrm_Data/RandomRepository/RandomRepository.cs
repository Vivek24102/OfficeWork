using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Data.RandomRepository
{
    public class RandomRepository : IRandomRepository
    {
        public int randomNumber()
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            return r;
        }
    }
}

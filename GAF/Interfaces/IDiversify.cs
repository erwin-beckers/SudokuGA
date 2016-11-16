using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAF
{
    public interface IDiversify
    {
        /// <summary>
        /// Adds new random chromosone to the next population to make sure the population is diversified enough.
        /// </summary>
        /// <param name="nextPopulation">The next population.</param>
        /// <param name="populationSize">Size of the population.</param>
        void Process( Population nextPopulation, int populationSize);
    }
}

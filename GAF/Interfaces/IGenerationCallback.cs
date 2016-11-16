using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAF
{
    public interface IGenerationCallback
    {
        void OnStart(int generation);

        void OnEnd(int generation, double bestFitness);
    }
}

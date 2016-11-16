using System;

namespace GAF
{
    /// <summary>
    /// A basic implementation of a gene
    /// This gene holds an integer
    /// </summary>
    /// <seealso cref="GAF.IGene" />
    public class Gene : IGene
    {
        static Random _rnd = new Random();

        public int Value;
        public int Min;
        public int Max;

        public Gene(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public IGene Clone()
        {
            var gene = new Gene(Min, Max);
            gene.Value = Value;
            return gene;
        }

        public virtual void Mutate()
        {
            Value = _rnd.Next(Max) + Min;
        }
    }
}
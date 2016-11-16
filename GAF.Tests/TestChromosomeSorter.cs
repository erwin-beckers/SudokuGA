using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NSubstitute;
using FluentAssertions;

namespace GAF.Tests
{
    [TestClass]
    public class TestChromosomeSorter
    {
        [TestMethod]
        public void TestSort()
        {
            var chromosomes = new List<IChromosome>();
            chromosomes.Add(CreateChromosomeWithFitness(3));
            chromosomes.Add(CreateChromosomeWithFitness(1));
            chromosomes.Add(CreateChromosomeWithFitness(5));
            chromosomes.Add(CreateChromosomeWithFitness(2));
            chromosomes.Add(CreateChromosomeWithFitness(4));
            chromosomes.Add(CreateChromosomeWithFitness(8));
            chromosomes.Sort(new ChromosomeSorter());

            chromosomes[0].Fitness.ShouldBeEquivalentTo<double>(8);
            chromosomes[1].Fitness.ShouldBeEquivalentTo<double>(5);
            chromosomes[2].Fitness.ShouldBeEquivalentTo<double>(4);
            chromosomes[3].Fitness.ShouldBeEquivalentTo<double>(3);
            chromosomes[4].Fitness.ShouldBeEquivalentTo<double>(2);
            chromosomes[5].Fitness.ShouldBeEquivalentTo<double>(1);
        }

        private IChromosome CreateChromosomeWithFitness(double fitness)
        {
            var chromosome = Substitute.For<IChromosome>();
            chromosome.Fitness.Returns<double>(fitness);
            return chromosome;
        }
    }
}

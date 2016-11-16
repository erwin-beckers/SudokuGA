using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NSubstitute;
using FluentAssertions;

namespace GAF.Tests
{
    [TestClass]
    public class TestMutate
    {
        public void TestMutation()
        {
            var mutate = new Mutate(1);
            var chromosome = Substitute.For<IChromosome>();

            List<IGene> genes = new List<IGene>();
            for (var i = 0; i < 10; ++i)
            {
                var gene = Substitute.For<IGene>();
                gene.Received().Mutate();
                genes.Add(gene);
            }
            chromosome.Genes.Returns<List<IGene>>(genes);

            mutate.Process(chromosome);
        }
    }
}

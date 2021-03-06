﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryAnything.UnitTests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void SelectProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this");
            Assert.IsTrue(result.SequenceEqual(source.Select(p => p.Age)));
        }

        [TestMethod]
        public void SelectPropertyWhereOtherProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this WHERE name = 'Frank'");
            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Name == "Frank").Select(p => p.Age)));
        }

        [TestMethod]
        public void SelectPropertyWhereWithAddition()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this WHERE age = 39 + 1");

            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Age == 39 + 1).Select(p => p.Age)));
        }
    }
}

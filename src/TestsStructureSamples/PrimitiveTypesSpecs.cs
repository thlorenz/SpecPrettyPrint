using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsStructureSamples.SpecUtils;

namespace TestsStructureSamples
{
    [TestClass]
    public class PrimitiveTypesSpecs : SpecsBase
    {
        int unInitializedInt;
        double unInitializedDouble;
        bool unInitializedBool;
        string unInitializedString;

        int initializedInt;
        double initializedDouble;
        bool initializedBool;
        string initializedString;

        protected override void Context()
        {
            initializedInt = 1;
            initializedDouble = 1.2;
            initializedBool = true;
            initializedString = "Hello World";
        }

        [TestMethod]
        public void an_uninitialized_int_should_be_0()
        {
            unInitializedInt.ShouldEqual(0);
        }

        [TestMethod]
        public void an_uninitialized_double_should_be_0p0()
        {
            unInitializedDouble.ShouldEqual(0.0);
        }

        [TestMethod]
        public void an_uninitialized_bool_should_be_false()
        {
            unInitializedBool.ShouldEqual(false);
        }

        [TestMethod]
        public void an_int_that_was_initialized_to_1_should_be_1()
        {
            initializedInt.ShouldEqual(1);
        }

        [TestMethod]
        public void a_double_that_was_initialized_to_1p2_should_be_1p2()
        {
            initializedDouble.ShouldEqual(1.2);
        }

        [TestMethod]
        public void a_bool_that_was_initialized_to_true_should_be_true()
        {
            initializedBool.ShouldEqual(true);
        }

        [TestMethod]
        public void an_uninitialized_string_should_be_null()
        {
            unInitializedString.ShouldBeNull();
        }

        [TestMethod]
        public void a_string_that_was_initialized_with__Hello_World__should_be__Hello_World__()
        {
            initializedString.ShouldEqual("Hello World");
        }
    }
}

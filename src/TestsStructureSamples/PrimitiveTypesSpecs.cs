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
        bool unInitializedBool;
        string unInitializedString;

        int initializedInt;
        bool initializedBool;
        string initializedString;

        protected override void Context()
        {
            initializedInt = 1;
            initializedBool = true;
            initializedString = "Hello World";
        }

        [TestMethod]
        public void an_uninitialized_int_should_be_0()
        {
            unInitializedInt.ShouldEqual(0);
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
        public void an_bool_that_was_initialized_to_true_should_be_true()
        {
            initializedBool.ShouldEqual(true);
        }

        [TestMethod]
        public void an_uninitialized_string_should_be_null()
        {
            unInitializedString.ShouldBeNull();
        }

        [TestMethod]
        public void an_initialized_string_should_be__Hello_World__()
        {
            initializedString.ShouldEqual("Hello World");
        }

    }
}

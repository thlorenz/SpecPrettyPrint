using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsStructureSamples.SpecUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsStructureSamples
{
    public class PrimitiveTypesWithSeveralContextsSpecs : SpecsBase
    {
        protected int anInt;
        protected double aDouble;
        protected bool aBool;
        protected string aString;

        [TestClass]
        public class when_primitives_have_not_been_initialized : PrimitiveTypesWithSeveralContextsSpecs
        {
            [TestMethod]
            public void an_int_should_be_0()
            {
                anInt.ShouldEqual(0);
            }

            [TestMethod]
            public void a_bool_should_be_false()
            {
                aBool.ShouldEqual(false);
            }

            [TestMethod]
            public void a_double_should_be_0p0()
            {
                aDouble.ShouldEqual(0.0);
            }

            [TestMethod]
            public void a_string_should_be_null()
            {
                aString.ShouldBeNull();
            }
        }

        public class Ctx_PrimitivesInitialized : PrimitiveTypesWithSeveralContextsSpecs
        {
            protected override void Context()
            {
                base.Context();

                anInt = 1;
                aDouble = 1.2;
                aBool = true;
                aString = "Hello World";
            }
        }

        [TestClass]
        public class when_primitives_were_set_to_int_1_double_1p2_bool_true_string__Hello_World__ : Ctx_PrimitivesInitialized
        {
            [TestMethod]
            public void an_int_should_be_1()
            {
                anInt.ShouldEqual(1);
            }

            [TestMethod]
            public void a_double_should_be_1p2()
            {
                aDouble.ShouldEqual(1.2);
            }

            [TestMethod]
            public void a_bool_should_be_true()
            {
                aBool.ShouldEqual(true);
            }

            [TestMethod]
            public void a_string_should_be__Hello_World__()
            {
                aString.ShouldEqual("Hello World");
            }
        }

    }
}

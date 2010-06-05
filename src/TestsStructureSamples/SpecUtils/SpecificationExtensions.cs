using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsStructureSamples.SpecUtils
{
    public static class SpecificationExtensions
    {
        public static T ShouldEqual<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }

        public static T ShouldBeNull<T>(this T actual) where T : class
        {
            Assert.IsNull(actual);
            return actual;
        }

        public static T ShouldNotBeNull<T>(this T actual) where T : class
        {
            Assert.IsNotNull(actual);
            return actual;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsStructureSamples.SpecUtils
{
    public abstract class SpecsBase
    {
        public SpecsBase()
        {
            Context();
            Because();
        }

        protected virtual void Context()
        { }
        
        protected virtual void Because()
        { }
    }
}

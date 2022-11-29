using System;
using System.Collections.Generic;
using System.Text;

namespace Beware.Inputs {
    abstract class MappingModel<T> {
        public abstract string Heading { get; }
        public abstract T Name { get; set; }
    }
}

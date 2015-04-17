using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Interface
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InterfaceImplementationAttribute : Attribute
    {
        public InterfaceImplementationAttribute() { }
        public string Name { get; set; }
        public string Scheme { get; set; }
        public Type ConfigPanel { get; set; }
    }
}

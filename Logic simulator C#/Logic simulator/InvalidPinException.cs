using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class InvalidPinException : LogicSimulatorException
    {
        public InvalidPinException() : base("Invalid pin selected") { }
        
        public InvalidPinException(string message) : base(message) { }
        public InvalidPinException(string message, Exception inner) : base(message, inner) { }
        
    }
}

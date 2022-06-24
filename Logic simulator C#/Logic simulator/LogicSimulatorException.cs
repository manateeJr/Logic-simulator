using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class LogicSimulatorException : Exception
    {
        public LogicSimulatorException() : base("Error detected in the logic circuit") { }

        public LogicSimulatorException(string message) : base(message) { }
        public LogicSimulatorException(string message, Exception inner) : base(message, inner) { }
    }
}

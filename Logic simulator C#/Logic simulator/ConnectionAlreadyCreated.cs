using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class ConnectionAlreadyCreated : LogicSimulatorException
    {
        public ConnectionAlreadyCreated() : base("Connection already created") { }
        public ConnectionAlreadyCreated(string message) : base(message) { }
        public ConnectionAlreadyCreated(string message, Exception inner) : base(message, inner) { }
    }
}

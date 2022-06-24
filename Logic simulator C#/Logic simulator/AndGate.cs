using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class AndGate : BaseGate, ILogicInterface
    {
        /// <summary>
        /// Initializes an And gate
        /// </summary>
        /// <param name="pin0">Pin number 0</param>
        /// <param name="pin1">Pin number 1</param>
        public AndGate(bool pin0, bool pin1) 
            :base(pin0, pin1) { }
        /// <summary>
        /// Returns the output 
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns output for the component</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid pin for AND"); }
            return base.GetPin0 & base.GetPin1;
        }
    }
}

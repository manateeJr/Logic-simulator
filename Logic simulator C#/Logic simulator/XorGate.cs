using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class XorGate :  BaseGate, ILogicInterface
    {
        /// <summary>
        /// Initializes an Xor gate
        /// </summary>
        /// <param name="pin0">Value stored in pin0</param>
        /// <param name="pin1">Value stored in pin0</param>
        public XorGate(bool pin0, bool pin1)
            :base(pin0, pin1) { }

        /// <summary>
        /// Returns the output of the Xor gate 
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns output for the OR gate</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid pin for XOR"); }
            return base.GetPin0 ^ base.GetPin1;
        }


    }
}

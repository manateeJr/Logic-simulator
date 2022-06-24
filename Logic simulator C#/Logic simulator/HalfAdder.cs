using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class HalfAdder: BaseGate, ILogicInterface
    {
        AndGate andHalfAdder;
        XorGate xorHalfAdder;

        public HalfAdder(bool pin0, bool pin1)
            : base(pin0, pin1) 
        {
            andHalfAdder = new AndGate(pin0, pin1);
            xorHalfAdder = new XorGate(pin0, pin1);
        }

        /// <summary>
        /// Sets the input pin values
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <param name="value">Value for the selected pin</param>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override void SetInput(int pin, bool value)
        {
            if ((pin < 0) || (pin > 1)) { throw new InvalidPinException(pin + " is not a valid pin for Half-Adder"); }
            if (pin == 0) 
            { 
                xorHalfAdder.SetInput(pin, value);
                andHalfAdder.SetInput(pin, value);
            }
            else if (pin == 1)
            {
                xorHalfAdder.SetInput(pin, value);
                andHalfAdder.SetInput(pin, value);
            }

            base.UpdateConnections(pin);
        }

        /// <summary>
        /// Gets the output of a half adder
        /// </summary>
        /// <param name="pin">Pin number 0 to get the sum, pin number 1 to get the carry</param>
        /// <returns>Returns the sum or carry depending on the pin number</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetOutput(int pin)
        {
            if ((pin < 0) || (pin > 1)) { throw new InvalidPinException(pin + " is not a valid pin for Half-Adder"); }
            bool value = false;
            if (pin == 1) { 
                value = andHalfAdder.GetOutput(0); 
            }
            else if (pin == 0) { value = xorHalfAdder.GetOutput(0); }

            return value;
        }
        
    }
}

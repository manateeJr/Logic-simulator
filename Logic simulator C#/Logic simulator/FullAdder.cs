using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class FullAdder: BaseGate, ILogicInterface
    {
        HalfAdder halfAdder0;
        HalfAdder halfAdder1;
        /// <summary>
        /// Initializes a full adder
        /// </summary>
        /// <param name="pin0">Value stored in pin0</param>
        /// <param name="pin1">Value stored in pin1</param>
        /// <param name="pin2">Value stored in pin2</param>
        public FullAdder(bool pin0, bool pin1, bool pin2)
            :base(pin0, pin1, pin2) 
        {
            halfAdder0 = new HalfAdder(false, false);
            halfAdder1 = new HalfAdder(false, false);
        }



        /// <summary>
        /// Method to return the input.
        /// </summary>
        /// <param name="Pin ">Pin number</param>
        /// <returns>Returns the input</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetInput(int pin)
        {
            if ((pin < 0) || (pin > 2)) { throw new InvalidPinException(pin + " is not a valid pin for Full-Adder"); }
            
            bool value = false;

            if (pin == 0) { value = base.GetPin0; }
            else if (pin == 1) { value = base.GetPin1; }
            else if (pin == 2) { value = base.GetPin2; }

            return value;
        }
        /// <summary>
        /// Sets the input pin values
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <param name="value">Value for the selected pin</param>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override void SetInput(int pin, bool value)
        {
            if ((pin < 0) || (pin > 2)) { throw new InvalidPinException(pin + " is not a valid pin for Full-Adder"); }
            
            if (pin == 0)
            {
                halfAdder0.SetInput(pin, value);
            }
            else if (pin == 1)
            {
                halfAdder0.SetInput(pin, value);
            }
            else if (pin == 2)
            {
                halfAdder1.SetInput(0, halfAdder0.GetOutput(0));
                halfAdder1.SetInput(1, value);
            }

            base.UpdateConnections(pin);
        }

        /// <summary>
        /// Gets the output of a half adder
        /// </summary>
        /// <param name="pin">Pin number 0 to get the carry, pin number 1 to get the sum</param>
        /// <returns>Returns the sum or carry depending on the pin number</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetOutput(int pin)
        {
            if ((pin < 0) || (pin > 1)) { throw new InvalidPinException(pin + " is not a valid pin for Full-Adder"); }
            bool value = false;
            if (pin == 0) { value = halfAdder1.GetOutput(0); }
            else if (pin == 1) { value = halfAdder1.GetOutput(1) || halfAdder0.GetOutput(1); }

            return value;
        }
       
    }
}

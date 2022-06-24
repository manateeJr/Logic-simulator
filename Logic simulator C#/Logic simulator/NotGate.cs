using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class NotGate : BaseGate, ILogicInterface
    {
        /// <summary>
        /// Initializes a Not gate
        /// </summary>
        /// <param name="pin0">Value stored in pin0</param>
        public NotGate(bool pin0)
            : base(pin0) { }
        /// <summary>
        /// Gets the input of a not gate
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns the input of a not gate</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetInput(int pin)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid input pin for NOT"); }
            return base.GetPin0;
        }
        /// <summary>
        /// Returns the output 
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns output for the component</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override bool GetOutput(int pin)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid output pin for NOT"); }
            return !base.GetPin0;
        }

        /// <summary>
        /// Sets the input pin value
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <param name="value">Value for the selected pin</param>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public override void SetInput(int pin, bool value)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid output pin for NOT"); }

            SetPin0 = value;

            base.UpdateConnections(pin);
        }


    }
}

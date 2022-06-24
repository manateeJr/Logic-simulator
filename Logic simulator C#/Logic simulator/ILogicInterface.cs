using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    public interface ILogicInterface
    {

        
        // Returns the state of an input pin
        bool GetInput(int pin);

        // Returns the state of an output pin
        bool GetOutput(int pin);
        
        
        // Sets the state of an input pin
        void SetInput(int pin, bool value);

        // Connect an output of this component to an input of another component.
        // Allows multiple connections from the same output to other output pins
        void ConnectOutput(int outputPin, ILogicInterface other, int inputPin);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    class Connections
    {
        private int outputPin, inputPin;
        private ILogicInterface component;

        /// <summary>
        /// Creates an object with an output pin, component to which we are connecting the output, and input pin of component
        /// </summary>
        /// <param name="outputPin">Output pin number</param>
        /// <param name="other">Component that we are connecting the pin to</param>
        /// <param name="inputPin">Input pin number</param>
        public Connections(int outputPin, ILogicInterface other, int inputPin)
        {
            this.outputPin = outputPin;
            this.inputPin = inputPin;
            this.component = other;
        }
        /// <summary>
        /// Returns the connected component type
        /// </summary>
        public ILogicInterface GetComponent
        {
            get { return component; }
        }
        /// <summary>
        /// Returns true if the input is already connected to an output.
        /// </summary>
        public int GetInputPin
        {
            get { return inputPin; }
        }
      
    }
}

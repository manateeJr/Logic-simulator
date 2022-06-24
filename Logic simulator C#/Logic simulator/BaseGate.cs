using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_simulator
{
    abstract class BaseGate : ILogicInterface
    {
        private List<Connections> connections = new List<Connections>();

        private bool pin0, pin1, pin2;
        /// <summary>
        /// Constructor to re-use in the NOT gate class
        /// </summary>
        /// <param name="pin0">Value stored in pin0</param>
        public BaseGate(bool pin0)
        {
            this.pin0 = pin0;
        }
        /// <summary>
        /// Constructor to re-use in AND, XOR and OR gates as well as half-adder
        /// </summary>
        /// <param name="pin0">Value stored in pin0</param>
        /// <param name="pin1">Value stored in pin1</param>
        public BaseGate(bool pin0, bool pin1)
        {
            this.pin0 = pin0;
            this.pin1 = pin1;
        }
        /// <summary>
        /// Constructor to re-use in the full-adder class
        /// </summary>
        /// <param name="pin0"></param>
        /// <param name="pin1"></param>
        /// <param name="pin2"></param>
        public BaseGate(bool pin0, bool pin1, bool pin2)
        {
            this.pin0 = pin0;
            this.pin1 = pin1;
            this.pin2 = pin2;
        }
        /// <summary>
        /// Returns the value stored in pin0
        /// </summary>
        public bool GetPin0
        {
            get { return pin0; }
        }
        /// <summary>
        /// value stored in pin1
        /// </summary>
        public bool GetPin1
        {
            get { return pin1; }
        }
        /// <summary>
        /// value stored in pin2
        /// </summary>
        public bool GetPin2
        {
            get { return pin2; }
        }
        /// <summary>
        /// Property to set the value of pin0
        /// </summary>
        public bool SetPin0
        {
            set { pin0 = value; }
        }
        /// <summary>
        /// Returns the value stored in pin number
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns the input</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public virtual bool GetInput(int pin)
        {
            if ((pin < 0) || (pin > 1)) { throw new InvalidPinException(pin + " is not a valid input pin"); }

            if (pin == 0) { return pin0; }
            else { return pin1; }
        }
        /// <summary>
        /// Sets the value for the selected pin
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <param name="value">Value stored in the pin number</param>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public virtual void SetInput(int pin, bool value)
        {
            if ((pin < 0) || (pin > 1)) { throw new InvalidPinException(pin + " is not a valid input pin"); }

            foreach (Connections connection in connections)
            {
                connection.GetComponent.SetInput(connection.GetInputPin, value);
            }

            if (pin == 0) { pin0 = value; }
            else { pin1 = value; }

            
        }
        /// <summary>
        /// Method that updates all current connections
        /// </summary>
        /// <param name="pin">Output pin number</param>
        public void UpdateConnections(int pin)
        {
            foreach (Connections connection in connections)
            {
                connection.GetComponent.SetInput(connection.GetInputPin, GetOutput(pin));
            }
        }

        /// <summary>
        /// Returns the output for the selected pin number
        /// </summary>
        /// <param name="pin">Pin number</param>
        /// <returns>Returns the output of the component</returns>
        /// <exception cref="InvalidPinException">Throws an exception when an invalid pin is selected</exception>
        public virtual bool GetOutput(int pin)
        {
            if (pin != 0) { throw new InvalidPinException(pin + " is not a valid output pin"); }
            return  pin0 | pin1; 
        }
        /// <summary>
        /// Connects the output pin of a component to the input pin of another component
        /// </summary>
        /// <param name="outputPin">Output pin number</param>
        /// <param name="other">Component that we're connecting to</param>
        /// <param name="inputPin">Input pin number of the connected component</param>
        public virtual void ConnectOutput(int outputPin, ILogicInterface other, int inputPin)
        {
            CheckConnection(inputPin, other);
            connections.Add(new Connections(outputPin, other, inputPin));
            other.SetInput(inputPin, GetOutput(outputPin));
        }

        /// <summary>
        /// Check if the input pin of the component is already connected
        /// </summary>
        /// <param name="inputPin">Input pin number of the component</param>
        /// <param name="other">Component name</param>
        public void CheckConnection(int inputPin, ILogicInterface other)
        {   
            foreach (Connections connection in connections)
            {
                if (connection.GetInputPin == inputPin && connection.GetComponent == other)
                {
                    throw new ConnectionAlreadyCreated("Connection already exists!");                    
                }
            }
        }
    }
}

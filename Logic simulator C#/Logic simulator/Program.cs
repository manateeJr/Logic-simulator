using System;

namespace Logic_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawAndTable();
            DrawOrTable();
            DrawNotTable();
            DrawXorTable();
            DrawHalfAdderTable();
            DrawFullAdderTable();
            TestOutputPinException();
            TestInputPinException();
            TestConnectionNotAndNot();
            TestConnectionException();
        }

        static void TestConnectionException()
        {
            Console.WriteLine("---------------------\nConnection exception testing\nWe initialize 2 NOT gates");
            NotGate notException0 = new NotGate(false);
            NotGate notException1 = new NotGate(false);
            NotGate notException2 = new NotGate(false);
            try
            {
                Console.Write("Connecting gate 1 output to gate 2 input here\n");
                notException1.ConnectOutput(0, notException2, 0);
            }
            catch (ConnectionAlreadyCreated e)
            {
                Console.Write(e.Message);
            }

            try
            {
                Console.Write("Connecting gate 1 output to gate 2 input again\n");
                notException1.ConnectOutput(0, notException2, 0);
            }
            catch (ConnectionAlreadyCreated e)
            {
                Console.Write(e.Message + "\n\n");
            }
        }
        static void DrawFullAdderTable()
        {
            Console.WriteLine("---------------------\n Full-adder");
            FullAdder fullAdder = new FullAdder(false, false, false);
            Console.WriteLine("A B C S C");
            Console.Write("F F F ");

            try
            {
                fullAdder.SetInput(0, false);
                fullAdder.SetInput(1, false);
                fullAdder.SetInput(2, false);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("F F T ");
            try
            {
                fullAdder.SetInput(0, false);
                fullAdder.SetInput(1, false);
                fullAdder.SetInput(2, true);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("F T F ");
            try
            {
                fullAdder.SetInput(0, false);
                fullAdder.SetInput(1, true);
                fullAdder.SetInput(2, false);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("F T T ");
            try
            {
                fullAdder.SetInput(0, false);
                fullAdder.SetInput(1, true);
                fullAdder.SetInput(2, true);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T F F ");
            try
            {
                fullAdder.SetInput(0, true);
                fullAdder.SetInput(1, false);
                fullAdder.SetInput(2, false);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T F T ");
            try
            {
                fullAdder.SetInput(0, true);
                fullAdder.SetInput(1, false);
                fullAdder.SetInput(2, true);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T T F ");
            try
            {
                fullAdder.SetInput(0, true);
                fullAdder.SetInput(1, true);
                fullAdder.SetInput(2, false);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T T T ");
            try
            {
                fullAdder.SetInput(0, true);
                fullAdder.SetInput(1, true);
                fullAdder.SetInput(2, true);
                if (fullAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (fullAdder.GetOutput(1)) { Console.WriteLine("T "); }
                else { Console.WriteLine("F "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
        static void DrawAndTable()
        {

            // AND GATE
            Console.WriteLine("AND Gate");
            AndGate and = new AndGate(false, false);
            Console.WriteLine("A B A & B");
            Console.Write("F F ");
            try
            {
                and.SetInput(0, false);
                and.SetInput(1, false);
                if (and.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }


            Console.Write("F T ");
            try
            {
                and.SetInput(0, false);
                and.SetInput(1, true);
                if (and.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T F ");
            try
            {
                and.SetInput(0, true);
                and.SetInput(1, false);
                if (and.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }


            Console.Write("T T ");
            try
            {
                and.SetInput(0, true);
                and.SetInput(1, true);
                if (and.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }
        static void DrawOrTable()
        {
            // OR GATE
            Console.WriteLine("---------------------\nOR Gate");
            OrGate or = new OrGate(false, false);
            Console.WriteLine("A B A | B");
            Console.Write("F F ");

            try
            {
                or.SetInput(0, false);
                or.SetInput(1, false);
                if (or.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("F T ");
            try
            {
                or.SetInput(0, false);
                or.SetInput(1, true);
                if (or.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T F ");
            try
            {
                or.SetInput(0, true);
                or.SetInput(1, false);
                if (or.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T T ");
            try
            {
                or.SetInput(0, true);
                or.SetInput(1, true);
                if (or.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F\n\n");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }
        static void DrawNotTable()
        {
            Console.WriteLine("---------------------\nNOT Gate");
            NotGate not = new NotGate(false);
            Console.WriteLine("A !A");
            Console.Write("F ");
            try
            {
                not.SetInput(0, false);
                if (not.GetOutput(0)) Console.WriteLine("T");
                else Console.WriteLine("F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T ");
            try
            {
                not.SetInput(0, true);
                if (not.GetOutput(0)) Console.WriteLine("T");
                else Console.WriteLine("F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
        static void DrawXorTable()
        {
            Console.WriteLine("---------------------\nXOR Gate");
            XorGate xor = new XorGate(false, false);
            Console.WriteLine("A B A ^ B");
            Console.Write("F F ");
            try
            {
                xor.SetInput(0, false);
                xor.SetInput(1, false);
                if (xor.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("F T ");
            try
            {
                xor.SetInput(0, false);
                xor.SetInput(1, true);
                if (xor.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T F ");
            try
            {
                xor.SetInput(0, true);
                xor.SetInput(1, false);
                if (xor.GetOutput(0)) Console.WriteLine("  T");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            Console.Write("T T ");
            try
            {
                xor.SetInput(0, true);
                xor.SetInput(1, true);
                if (xor.GetOutput(0)) Console.WriteLine("  T\n\n");
                else Console.WriteLine("  F");
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
        static void DrawHalfAdderTable()
        {

            Console.WriteLine("---------------------\n Half-Adder");
            HalfAdder halfAdder = new HalfAdder(false, false);
            Console.WriteLine("A B S C");
            Console.Write("F F ");
            try
            {
                halfAdder.SetInput(0, false);
                halfAdder.SetInput(1, false);
                if (halfAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (halfAdder.GetOutput(1)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            Console.Write("F T ");
            try
            {
                halfAdder.SetInput(0, false);
                halfAdder.SetInput(1, true);
                if (halfAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (halfAdder.GetOutput(1)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            Console.Write("T F ");
            try
            {
                halfAdder.SetInput(0, true);
                halfAdder.SetInput(1, false);
                if (halfAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (halfAdder.GetOutput(1)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            Console.Write("F F ");
            try
            {
                halfAdder.SetInput(0, true);
                halfAdder.SetInput(1, true);
                if (halfAdder.GetOutput(0)) { Console.Write("T "); }
                else { Console.Write("F "); }
                if (halfAdder.GetOutput(1)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
        static void TestOutputPinException()
        {
            NotGate notGatePinExceptionTest = new NotGate(true);
            Console.Write("---------------------\nOutput pin exception test\nNOT Gate\npin A !A\n0   T ");
            try
            {
                if (notGatePinExceptionTest.GetOutput(0)) { Console.Write("T\n1 "); }
                else { Console.Write("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            try
            {
                notGatePinExceptionTest.SetInput(1, false);
                if (notGatePinExceptionTest.GetOutput(0)) { Console.Write("T\n 1 "); }
                else { Console.Write("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        static void TestInputPinException()
        {
            OrGate OrGatePinException = new OrGate(false, false);

            Console.Write("---------------------\nInput pin exception test\nOR Gate\npin A B A|B\n0   F F ");
            try
            {
                if (OrGatePinException.GetOutput(0)) { Console.Write("T\n1 "); }
                else { Console.Write(" F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            try
            {
                OrGatePinException.SetInput(2, false);
                if (OrGatePinException.GetOutput(0)) { Console.Write("T\n 1 "); }
                else { Console.Write("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        static void TestConnectionNotAndNot()
        {
            //Test connection
            NotGate notTest = new NotGate(false);
            NotGate notTest0 = new NotGate(false);
            Console.WriteLine("---------------------\nConnection testing NOT and NOT gate connected");
            Console.Write("A !A !!A\nF  ");
            try
            {
                if (notTest.GetOutput(0)) { Console.Write("T  "); }
                else { Console.Write("F  "); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }            

            try
            {
                notTest.ConnectOutput(0, notTest0, 0);
            }
            catch (ConnectionAlreadyCreated e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                if (notTest0.GetOutput(0)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            
            Console.Write("T  ");
            try
            {
                notTest.SetInput(0, true);
                if (notTest.GetOutput(0)) { Console.Write("T  "); }
                else { Console.Write("F  "); }
                if (notTest0.GetOutput(0)) { Console.WriteLine("T"); }
                else { Console.WriteLine("F"); }
            }
            catch (InvalidPinException e)
            {
                Console.WriteLine(e.Message + "\n");
            }


        }
    }
}

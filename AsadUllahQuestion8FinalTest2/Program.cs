using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AsadUllahQuestion8FinalTest2
{
    public class CalculationEventArgs : EventArgs
    {
        public int Result { get; private set; }

        public CalculationEventArgs(int result)
        {
            Result = result;
        }
    }

    public delegate void CalculationPerformedHandler(object sender, CalculationEventArgs e);

    public class Calculator
    {
        public event CalculationPerformedHandler CalculationPerformed;

        public void Add(int a, int b)
        {
            int result = a + b;
            OnCalculationPerformed(new CalculationEventArgs(result));
        }

        protected virtual void OnCalculationPerformed(CalculationEventArgs e)
        {
            CalculationPerformed?.Invoke(this, e);
        }
    }

    public class CalculationHandler
    {
        public CalculationHandler(Calculator calculator)
        {

            calculator.CalculationPerformed += OnCalculationPerformed;
        }


        private void OnCalculationPerformed(object sender, CalculationEventArgs e)
        {
            Console.WriteLine($"Calculation result: {e.Result}");
        }
    }


    static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    
}

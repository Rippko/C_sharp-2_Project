using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    delegate int Operation(int x, int y);
    internal class Calculator
    {
        private int x;
        private int y;

        public event EventHandler OnSetXY;

        public event EventHandler<Calculator2> OnCompute;

        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
            if (this.OnSetXY != null)
                this.OnSetXY(this, EventArgs.Empty);

            // OnSetXY?.Invoke(this, new EventArgs());
        }

        public void Execute(Operation op)
        {
            int result = op(x, y);
            OnCompute?.Invoke(this, new Calculator2() { Result = result});

            Console.WriteLine(result);
        }


   
    }
}

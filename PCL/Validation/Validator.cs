using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMAssignment1.Validation
{
    public class Validator
    {
        public int ValueA { get; set; }
        public int ValueB { get; set; }
        public Validator(string a,string b)
        {
            ValueA = Convert.ToInt32(a);
            ValueB = Convert.ToInt32(b);
        }
        public bool IsValidated()
        {
            if (ValueB < ValueA)
                return false;
            else
            {
                if (ValueA * ValueB > 70)
                    return false;
                else
                    return true;
            }
        }

    }
}

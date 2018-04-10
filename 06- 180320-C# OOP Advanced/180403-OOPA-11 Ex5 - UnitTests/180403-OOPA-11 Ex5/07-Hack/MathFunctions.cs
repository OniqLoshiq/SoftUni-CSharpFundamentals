using System;

namespace _07_Hack
{
    public class MathFunctions : IMathAbs, IMathFloor
    {

        public int GetMathAbsValue(int number)
        {
            if (number >= 0)
                return number;
            else
                return number * -1;
        }

        public int GetMathFloorValue(double number)
        {
            if (number >= 0)
                return (int)number;
            else
                return (int)number - 1;
        }
    }
}

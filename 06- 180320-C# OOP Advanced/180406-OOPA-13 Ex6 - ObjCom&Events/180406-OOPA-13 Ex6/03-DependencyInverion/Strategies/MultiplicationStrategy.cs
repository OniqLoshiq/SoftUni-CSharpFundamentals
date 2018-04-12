﻿using _03_DependencyInverion.Interfaces;

namespace _03_DependencyInverion.Strategies
{
    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}

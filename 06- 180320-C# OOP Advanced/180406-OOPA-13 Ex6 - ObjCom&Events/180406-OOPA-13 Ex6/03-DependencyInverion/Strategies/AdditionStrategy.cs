﻿using _03_DependencyInverion.Interfaces;

namespace _03_DependencyInverion.Strategies
{
	public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}

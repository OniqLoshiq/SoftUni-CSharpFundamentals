using System;
using System.Collections.Generic;
using System.Text;

namespace _02_KingsGambit.Interfaces
{
    public interface ISubordinate : INamable, IDyable
    {
        string Action { get; }
        void ReactToAttack();
    }
}

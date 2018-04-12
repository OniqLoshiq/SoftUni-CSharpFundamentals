using System;
using System.Collections.Generic;
using System.Text;

namespace _02_KingsGambit.Interfaces
{
    public interface IKing : INamable, IAttackable
    {
        IReadOnlyCollection<ISubordinate> Army { get; }

        void AddUnitToArmy(ISubordinate subordinate);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _05_KingsGambitExtended.Interfaces
{
    public interface IKing : INamable, IAttackable
    {
        IReadOnlyCollection<ISubordinate> Army { get; }

        void AddUnitToArmy(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}

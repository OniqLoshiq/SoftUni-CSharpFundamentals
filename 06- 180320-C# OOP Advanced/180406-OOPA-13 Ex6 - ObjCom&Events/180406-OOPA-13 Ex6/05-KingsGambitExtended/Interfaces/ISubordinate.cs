using System;
using System.Collections.Generic;
using System.Text;

namespace _05_KingsGambitExtended.Interfaces
{
    public delegate void SubordinateDeathEventHandler(object sender);

    public interface ISubordinate : INamable, IDyable
    {
        event SubordinateDeathEventHandler SubordinateDeathEvent;
        string Action { get; }
        void ReactToAttack();
    }
}

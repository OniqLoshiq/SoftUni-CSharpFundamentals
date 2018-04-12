using System;
using System.Collections.Generic;
using System.Text;

namespace _05_KingsGambitExtended.Interfaces
{
    public delegate void BeingAttackedEventHandler();

    public interface IAttackable
    {
        event BeingAttackedEventHandler BeingAttackedEvent;

        void BeingAttacked();
    }
}

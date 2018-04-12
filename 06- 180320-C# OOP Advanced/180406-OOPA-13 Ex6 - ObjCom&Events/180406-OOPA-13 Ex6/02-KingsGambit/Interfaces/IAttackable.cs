using System;
using System.Collections.Generic;
using System.Text;

namespace _02_KingsGambit.Interfaces
{
    public delegate void BeingAttackedEventHandler();

    public interface IAttackable
    {
        event BeingAttackedEventHandler BeingAttackedEvent;

        void BeingAttacked();
    }
}

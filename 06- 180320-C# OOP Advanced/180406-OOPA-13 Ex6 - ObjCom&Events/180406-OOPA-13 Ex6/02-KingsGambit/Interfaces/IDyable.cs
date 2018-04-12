using System;
using System.Collections.Generic;
using System.Text;

namespace _02_KingsGambit.Interfaces
{
    public interface IDyable
    {
        bool IsAlive { get; }
        void Die();
    }
}

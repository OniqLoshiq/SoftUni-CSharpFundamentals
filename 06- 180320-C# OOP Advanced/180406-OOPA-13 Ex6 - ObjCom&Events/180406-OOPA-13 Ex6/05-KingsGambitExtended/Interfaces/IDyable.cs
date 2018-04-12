using System;
using System.Collections.Generic;
using System.Text;

namespace _05_KingsGambitExtended.Interfaces
{
    public interface IDyable
    {
        int HitPoints { get; }
        void TakeDamage();
    }
}

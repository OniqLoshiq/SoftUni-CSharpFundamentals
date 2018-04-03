using System;
using System.Collections.Generic;
using System.Text;

namespace _06_TrafficLights
{
    interface ITrafficLight
    {
        Light Light { get; }
        void ChangeLight();
    }
}

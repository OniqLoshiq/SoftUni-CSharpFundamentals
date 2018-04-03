using System;
using System.Collections.Generic;
using System.Text;

namespace _06_TrafficLights
{
    public class TrafficLight : ITrafficLight
    {
        public Light Light { get; private set; }

        public TrafficLight(Light light)
        {
            this.Light = light;
        }

        public void ChangeLight()
        {
            this.Light++;
            if ((int)this.Light > 2)
                this.Light = 0;
        }

        public override string ToString()
        {
            return this.Light.ToString();
        }
    }
}

﻿using _07_InfernoInfinity.Commands;
using _08_CustomClassAttribute.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _08_CustomClassAttribute.Commands
{
    public class DescriptionCommand : Command
    {
        public DescriptionCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(a => a.CustomAttributes.Any(n => n.AttributeType == typeof(WeaponAttribute)));
            WeaponAttribute attrs = type.GetCustomAttribute<WeaponAttribute>(false);

            Console.WriteLine($"Class {this.Data[0].ToLower()}: {attrs.Description}");
        }
    }
}

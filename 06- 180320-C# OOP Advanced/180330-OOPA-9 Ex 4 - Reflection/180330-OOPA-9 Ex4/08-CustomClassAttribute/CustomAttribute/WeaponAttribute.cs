using System;
using System.Collections.Generic;
using System.Text;

namespace _08_CustomClassAttribute.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WeaponAttribute : Attribute
    {
        public string Author { get; private set; }
        public int Revision { get; private set; }
        public string Description { get; private set; }
        public IList<string> Reviewers { get; private set; }

        public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }
    }
}

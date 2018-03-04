using System.Collections.Generic;

interface ILeutenantGeneral : IPrivate
{
    IReadOnlyCollection<ISoldier> Privates { get; }
}

using System;
using System.Collections.Generic;

namespace Toci.Piascode.Instructions.Interfacces.Dev
{
    public interface IDevInstructions
    {
        Dictionary<string, Action> DevInstructions { get; set; }

        //string AccessModifier { get; set; }
        //string Name { get; set; }
        //string Object { get; set; } //interface, class, file...
    }
}
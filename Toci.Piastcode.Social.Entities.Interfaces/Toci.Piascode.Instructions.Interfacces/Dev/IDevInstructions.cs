using System;
using System.Collections.Generic;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piascode.Instructions.Interfacces.Dev
{
    public interface IDevInstructions<THandledInstruction> where THandledInstruction : IDevHandledInstruction
    {
        string AccessModifier { get; set; }
        string EntityType { get; set; }
        string Name { get; set; }
        Action<THandledInstruction> CustomCallback { get; set; }
        //string Object { get; set; } //interface, class, file...
    }
}
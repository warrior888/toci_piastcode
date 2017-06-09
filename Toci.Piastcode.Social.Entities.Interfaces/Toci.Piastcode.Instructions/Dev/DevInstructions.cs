using System;
using Toci.Piascode.Instructions.Interfacces.Dev;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;

namespace Toci.Piastcode.Instructions.Dev
{
    public class DevInstructions<THandledInstruction> : IDevInstructions<THandledInstruction> 
        where THandledInstruction : IDevHandledInstruction
    {
        public string AccessModifier { get; set; }
        public string EntityType { get; set; }
        public string Name { get; set; }
        public Action<THandledInstruction> CustomCallback { get; set; }
        public IOperation Operation { get; set; }
    }
}
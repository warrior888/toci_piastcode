using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piascode.Instructions.Interfacces.Tools
{
    public interface IGenericParser<TTarget, TSource> where TTarget : ITarget where TSource : ISource
    {
        TTarget Target { get; set; }
        TSource Source { get; set; }

        IParseResult Parse(TTarget target, TSource source);
    }
}
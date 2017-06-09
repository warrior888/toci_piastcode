using System.Linq.Expressions;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;
using Toci.Piastcode.Instructions.Entities;

namespace Toci.Piastcode.Instructions.Tools
{
    public class DeveloperCommandParser : IDeveloperCommandParser
    {
        public void CommandParser(string source, ITarget target)
        {
            IParser<ITarget, ISource, IResult> commandParser = new Parser<ITarget, ISource, IResult>();
            var commandSource = new Source {StringSource = source};
            commandParser.Source = commandSource;
            commandParser.Target = target;
            IResult result = commandParser.Parse(null, commandParser.Source);
        }


    }
}
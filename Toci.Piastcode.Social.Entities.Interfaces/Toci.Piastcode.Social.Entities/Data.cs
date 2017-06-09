using System.IO;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Entities
{
    public class Data : IData
    {
        public string Text { get; set; }

        public int CaretPosition { get; set; }
    }
}
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
using System.Net.Sockets;

namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
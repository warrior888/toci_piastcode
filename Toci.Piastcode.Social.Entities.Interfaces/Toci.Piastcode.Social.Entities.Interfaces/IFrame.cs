namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IFrame
    {
        IUser User { get; set; }

        IFile File { get; set; }

        IData Data { get; set; }
    }
}
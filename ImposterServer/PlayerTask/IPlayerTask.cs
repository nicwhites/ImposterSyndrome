using System.Reflection;

namespace ImposterServer.PlayerTask
{
    public interface IPlayerTask
    {
         int TaskId { get; }
         string TaskLocation { get; }
         string TaskName { get; }

        bool isCompleted { get; }


    } 
}
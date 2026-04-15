using Taskly.Models;

namespace Taskly.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        TaskItem CreateTask(TaskItem taskItem);
        void UpdateTask(TaskItem taskItem);
        void DeleteTask(int id);
    }
}

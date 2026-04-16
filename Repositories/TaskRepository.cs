using Taskly.Models;
using TaskCoreAPI.Exceptions;

namespace Taskly.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _taskItems = new List<TaskItem>();
        public async Task<List<TaskItem>> GetAllTasksAsync() => _taskItems;
        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return _taskItems.FirstOrDefault(i => i.Id == id)!;
        }
        public async Task<TaskItem> CreateTaskAsync(TaskItem newTaskItem)
        {
            newTaskItem.Id = _taskItems.Count + 1;

            _taskItems.Add(newTaskItem);

            return newTaskItem;
        }
        public async Task UpdateTaskAsync(TaskItem updatedTaskItem) => _taskItems[updatedTaskItem.Id - 1] = updatedTaskItem;
        public async Task DeleteTaskAsync(TaskItem taskItem) => _taskItems.Remove(taskItem);
    }
}

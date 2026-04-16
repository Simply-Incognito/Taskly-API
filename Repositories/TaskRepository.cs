using Taskly.Models;

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
            newTaskItem.IsCompleted = false;

            _taskItems.Add(newTaskItem);

            return newTaskItem;
        }
        public async Task UpdateTaskAsync(TaskItem updatedTaskItem)
        {
            var taskItem = await GetTaskByIdAsync(updatedTaskItem.Id);

            if (taskItem != null)
            {
                _taskItems[taskItem.Id - 1] = updatedTaskItem;
            }
        }
        public async Task DeleteTaskAsync(int id)
        {
            var taskItem = await GetTaskByIdAsync(id);

            if (taskItem != null) _taskItems.Remove(taskItem);
        }
  
    }
}

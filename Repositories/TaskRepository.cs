using Taskly.Models;

namespace Taskly.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _taskItems = new List<TaskItem>();
        public List<TaskItem> GetAllTasks() => _taskItems;
        public TaskItem GetTaskById(int id) => _taskItems.FirstOrDefault(i => i.Id == id)!;
        public TaskItem CreateTask(TaskItem newTaskItem)
        {
            newTaskItem.Id = _taskItems.Count + 1;
            newTaskItem.IsCompleted = false;

            _taskItems.Add(newTaskItem);

            return newTaskItem;
        }
        public void UpdateTask(TaskItem updatedTaskItem)
        {
            var taskItem = GetTaskById(updatedTaskItem.Id);

            if (taskItem != null)
            {
                _taskItems[taskItem.Id - 1] = updatedTaskItem;
            }
        }
        public void DeleteTask(int id)
        {
            var taskItem = GetTaskById(id);

            if (taskItem != null) _taskItems.Remove(taskItem);
        }
  
    }
}

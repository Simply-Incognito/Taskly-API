using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskly.Models;
using Taskly.Services;

namespace Taskly.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TasksController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }


        // Get All Tasks
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTasksAsync()
        {
            return Ok(await _taskItemService.GetAllTasksAsync());
        }

        // Get Task By ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskItem>> GetTaskByIdAsync(int id)
        {
            var taskItem = await _taskItemService.GetTaskByIdAsync(id);
            if (taskItem == null) return NotFound();

            return Ok(taskItem);
        }

        // Get Completed Tasks
        [HttpGet("completed")]
        public async Task<ActionResult<TaskItem>> GetAllCompletedTasksAsync()
        {
            var completedTasks = (await _taskItemService.GetAllTasksAsync()).Where(item => item.IsCompleted == true);

            return Ok(completedTasks);
        }

        // Create Task
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTaskAsync([FromBody] TaskItem newTaskItem)
        {
            if (newTaskItem == null || string.IsNullOrEmpty(newTaskItem.Title)) return BadRequest();

            newTaskItem = await _taskItemService.CreateTaskAsync(newTaskItem);

            // Use action name without the 'Async' suffix and explicitly name the route value 'id'
            return CreatedAtAction(nameof(GetTaskByIdAsync).Replace("Async", ""), new { id = newTaskItem.Id }, newTaskItem);
        }

        // Update Task
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TaskItem>> UpdateTaskAsync(int id, [FromBody] TaskItem updatedTaskItem)
        {
            var existingTask = await _taskItemService.GetTaskByIdAsync(id);
            
            if (existingTask == null)
            {
                return NotFound();
            } else if (updatedTaskItem == null || string.IsNullOrEmpty(updatedTaskItem.Title))
            {
                return BadRequest();
            }

            updatedTaskItem.Id = id;

            await _taskItemService.UpdateTaskAsync(updatedTaskItem);

            return Ok(updatedTaskItem);
            
        }

        // Delete task
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            var taskItem = await _taskItemService.GetTaskByIdAsync(id);

            if (taskItem == null) return NotFound();

            await _taskItemService.DeleteTaskAsync(id);

            return NoContent();
        } 


    }
}
using System;
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
            _taskItemService = taskItemService ?? throw new ArgumentNullException(nameof(taskItemService));
        }


        // Get All Tasks
        [HttpGet]
        public ActionResult<List<TaskItem>> GetAllTasks()
        {
            return Ok(_taskItemService.GetAllTasks());
        }

        // Get Task By ID
        [HttpGet("{id:int}")]
        public ActionResult<TaskItem> GetTaskById(int id)
        {
            var taskItem = _taskItemService.GetTaskById(id);
            if (taskItem == null) return NotFound();

            return Ok(taskItem);
        }

        // Get Completed Tasks
        [HttpGet("completed")]
        public ActionResult<TaskItem> GetAllCompletedTasks()
        {
            var completedTasks = _taskItemService.GetAllTasks().FindAll(task => task.IsCompleted == true);

            return Ok(completedTasks);
        }

        // Create Task
        [HttpPost]
        public ActionResult<TaskItem> CreateTask([FromBody] TaskItem newTaskItem)
        {
            newTaskItem = _taskItemService.CreateTask(newTaskItem);

            return CreatedAtAction(nameof(GetTaskById), new { newTaskItem.Id }, newTaskItem);
        }

        // Update Task
        [HttpPut("{id:int}")]
        public ActionResult<TaskItem> UpdateTask(int id, [FromBody] TaskItem updatedTaskItem)
        {
            var existingTask = _taskItemService.GetTaskById(id);
            
            if (existingTask == null)
            {
                return NotFound();
            } else if (updatedTaskItem == null || string.IsNullOrEmpty(updatedTaskItem.Title))
            {
                return BadRequest();
            }

            updatedTaskItem.Id = id;

            _taskItemService.UpdateTask(updatedTaskItem);

            return Ok(updatedTaskItem);
            
        }

        // Delete task
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            var taskItem = _taskItemService.GetTaskById(id);

            if (taskItem == null) return NotFound();

            _taskItemService.DeleteTask(id);

            return NoContent();
        } 


    }
}
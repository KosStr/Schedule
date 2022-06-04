using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using StudyngTask = Schedule.Core.Entities.Studying.Task;


namespace Schedule.Controllers.v1.Studying
{
    [RouteV1("[controller]"), Policy(Role.Teacher)]
    public class TaskController : ControllerBase
    {
        #region Properties

        private readonly ITaskService _taskService;

        #endregion

        #region Constructor

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] StudyngTask task, CancellationToken cancellationToken = default)
        {
            return Ok(await _taskService.CreateAsync(task, cancellationToken));
        }

        [HttpGet("task/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _taskService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TaskDto task, CancellationToken cancellationToken = default)
        {
            return Ok(await _taskService.UpdateAsync(task, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _taskService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catto.DataLib.Data;
using Catto.DataLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Catto.AppApi.Services;

namespace Catto.AppApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly AtomContextDB _context;
        
        public TaskManagerController(AtomContextDB context)
        {
            _context = context;
        }

        [HttpGet]        
        [Route("GetTask")]
        public async Task<ActionResult<List<JobTask>>> GetAsmartTask(int EmployeeId)
        {
            var tasks = _context.JobTasks.Where(u=> u.Executor.Id == EmployeeId).ToList();
            var tdplanner = new ToDoPlanner(tasks);
            var tasksID = tdplanner.GetTodayTodo();
            var letter = new List<JobTask>();
            foreach (var id in tasksID)
            {
                var i = _context.JobTasks.Find(id);
                letter.Add(i);
            }
            return letter;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger _logger;

        public HomeController(IBrainstormSessionRepository sessionRepository,ILogger logger)
        {
            _logger = logger;
            _sessionRepository = sessionRepository;
            /*_logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("Logs.txt", rollingInterval: RollingInterval.Day)
               // .WriteTo.Console()
                .CreateLogger();*/
        }

        public async Task<IActionResult> Index()
        {
            _logger.Information("Getting inside Home controller Index method!");
            var sessionList = await _sessionRepository.ListAsync();
            _logger.Information("Getting inside Home controller Index method!");
            
            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });
            _logger.Information("Getting inside Home controller Index method!");
            return View(model);
        }
        
        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Warning("Model state is not valid!");
                return BadRequest(ModelState);
            }
            else
            {
                await _sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                });
            }

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}

using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private ILog _logger;
        public SessionController(IBrainstormSessionRepository sessionRepository, ILog logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            _logger.Debug("Inside index Session Controller");
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }
            _logger.Debug("Getting the ID=${id.Value}");
            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                Log.Debug("Session not found!");
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return View(viewModel);
        }
    }
}

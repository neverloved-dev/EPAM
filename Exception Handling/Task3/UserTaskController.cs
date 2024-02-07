using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            // Check if user exists before adding the task
            if (!_taskService.DoesUserExist(userId))
            {
                model.AddAttribute("action_result", "User not found");
                return false;
            }

            // If user exists, add the task
            _taskService.AddTaskForUser(userId, new UserTask(description));
            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            int result = _taskService.AddTaskForUser(userId, task);
            if (result == -1)
                return "Invalid userId"; // Everything caught in same exception handler, make it more specific. 

            if (result == -2)
                return "User not found";

            if (result == -3)
                return "The task already exists";

            return null;
        }
    }
}
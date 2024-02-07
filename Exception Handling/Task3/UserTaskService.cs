using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            try
            {
                if (userId < 0)
                {
                    throw new ArgumentException("Invalid userId: userId should be a positive value.");
                }



                var user = _userDao.GetUser(userId);
                if (user == null)
                    throw new NullReferenceException("User not found: The specified user does not exist.");

                var tasks = user.Tasks;
                foreach (var t in tasks)
                {
                    if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidOperationException("Task already exists: A task with the same description already exists for the user.");
                }

                tasks.Add(task);

                return 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return -3;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }
        public bool DoesUserExist(int userId)
        {
            // Get the user by userId
            var user = _userDao.GetUser(userId);

            // If the user is not null, then the user exists
            return user != null;
        }
    }
}
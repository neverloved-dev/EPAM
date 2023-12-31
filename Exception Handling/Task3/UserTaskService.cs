﻿using System;
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
                    throw new ArgumentException("User not found: userId should be a positive value.");
                }



                var user = _userDao.GetUser(userId);
                if (user == null)
                    throw new ArgumentException("User not found: The specified user does not exist.");

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }
    }
}
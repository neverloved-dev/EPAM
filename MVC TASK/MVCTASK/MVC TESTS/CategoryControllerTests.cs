using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MVCTASK.Controllers;
using MVCTASK.Models;

namespace MVC_TESTS
{

    public class CategoryControllerTests
    {
        private readonly ILogger<CategoryController> _logger;
        private DataContext _context = new DataContext(options=>options.UseInMemoryDatabase("InMemoryDb"));
        public CategoryControllerTests() 
        {
            CategoryController categoryController = new CategoryController(_logger,_context);
        }

        [Fact]
        public void CategoryControllerGetCategoriesShouldReturnOkResult()
        {

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using GeropharmTestCase.Controllers;
using GeropharmTestCase.Models;
using GeropharmTestCase.Data;

namespace ApiUnitTest
{
    public class UnitTest1
    {
        ProjectController projectController = new ProjectController();
        Random random = new Random();

        [Fact]
        public void TestForGetAllUsers()
        {
            var testForGetAllUsers = projectController.GetAllProjects();
            Assert.Equal(typeof(Task<ActionResult<IEnumerable<object>>>), testForGetAllUsers.GetType());
        }

        [Fact]
        public void TestForGetSomeProjects()
        {
            int firstId = random.Next();
            int count = random.Next();
            var testForGetSomeProjects = projectController.GetSomeProjects(firstId, count);
            Assert.Equal(typeof(Task<ActionResult<object>>), testForGetSomeProjects.GetType());
        }
    }
}
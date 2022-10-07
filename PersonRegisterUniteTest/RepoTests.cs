using Microsoft.EntityFrameworkCore;
using Moq;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.Repository;
using System.Net.WebSockets;

namespace PersonRegisterUniteTest
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public async Task Create()
        {
            //Mock DbContext and DbSet//
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<UserContext>();
            mockContext.Setup(x=>x.Users).Returns(mockSet.Object);

            var userService = new UserRepo(mockContext.Object);
            await userService.CreateUser(new User() { EmailAddress = "test", Name = "test", Surname = "test" });

            mockSet.Verify(x => x.AddAsync(It.IsAny<User>(), default), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());

            
            
        }

        [TestMethod]
        public async Task GetUsers()
        {
            var userlist = new List<User>();
            {
                new User() { Id = 1, Name = "test", Surname = "test" };
                new User() { Id = 2, Name = "test", Surname = "test" };
                new User() { Id = 3, Name = "test", Surname = "test" };
            }

            
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUsers()).Returns(Task.FromResult(userlist));
            var result = await mockRepo.Object.GetUsers();
            Assert.AreEqual(result.Count, userlist.Count);
        }
    }
}
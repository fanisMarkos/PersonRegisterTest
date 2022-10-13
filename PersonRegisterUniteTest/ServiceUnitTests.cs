using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.MappingProfile;
using PersonRegisterTest.Infrastracture.Repository;
using PersonRegisterTest.Infrastracture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegisterUniteTest
{
    [TestClass]
    public class ServiceUnitTests
    {
        public static Mock<IUserRepo> _repo = new Mock<IUserRepo>();
        public static IMapper? _mapper;

        [ClassInitialize]
        public static void Initialize(TestContext ctx)
        {
            var _cfg = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            _mapper = _cfg.CreateMapper();
            _repo.Setup(x => x.GetSignleUser(It.IsAny<int>())).ReturnsAsync(new User() { Name ="test",Surname="test",EmailAddress="test",Id=5 });
            _repo.Setup(x => x.GetUsers()).ReturnsAsync(new List<User>() { new User() { Name="test", Surname = "test", EmailAddress = "test", Id = 5 } });
            _repo.Setup(x => x.CreateUser(It.IsAny<User>())).ReturnsAsync((User user) => { var result = new User(); result = user; return result; });
        }

        [TestMethod]
        public async Task GetUserAsync()
        {
            var userService = new UserService(_repo.Object, _mapper);
            var result = await userService.GetUserByIdAsync(5);
            Assert.IsTrue(result.Name == "test" && result.Surname == "test" && result.EmailAddress == "test" && result.Id == 5);
        }

        [TestMethod]
        public async Task GetUserListAsync()
        {
            var userService = new UserService(_repo.Object, _mapper);
            var resultList = await userService.GetUsersListAsync();
            Assert.IsTrue(resultList.Count > 0);
        }

        [TestMethod]
        public async Task CreateUserAsync()
        {
            var userService = new UserService(_repo.Object, _mapper);
            var user = new UserDTO() { Name = "test", Surname = "test", EmailAddress = "test", Id = 5 };
            var userResult = await userService.CreateUserAsync(user);
            Assert.AreEqual(user.Name, userResult.Name);

        }



    }
}

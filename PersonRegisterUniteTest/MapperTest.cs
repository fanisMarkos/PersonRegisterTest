using AutoMapper;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegisterUniteTest
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void TestMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            var mapper = config.CreateMapper();
            var user = new User() { Id = 1, Name = "test", Surname = "test", EmailAddress = "test" };
            var userDto = mapper.Map<UserDTO>(user);

            Assert.IsTrue(userDto.Id == 1 && userDto.Name=="test" && userDto.Surname=="test" && userDto.EmailAddress=="test");
        }
    }
}

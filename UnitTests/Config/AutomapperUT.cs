using AutoMapper;
using backend1;
using backend1.Data.Entity;
using backend1.Models;

namespace UnitTests.Config
{
    //GOOD PRACTICES: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    public class AutomapperUT
    {
        //TESTED METHOD'S NAME, SCENARIO TESTED, EXPECTED BEHAVIOR
        //Arrange (create objects), Act (act on object), Assert(see if it meet expected behavior)
        /*
         Example:
            [Fact]
            public void Add_EmptyString_ReturnsZero()
            {
                // Arrange
                var stringCalculator = new StringCalculator();

                // Act
                var actual = stringCalculator.Add("");

                // Assert
                Assert.Equal(0, actual);
            }
         */
        [Fact]
        public void AutomapperProfile_ChildModel_ReturnsChildEntity()
        {
            //Arrange
            var childModel = new ChildModel() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };
            var childEntity = new ChildEntity();
            var typeChildEntity = typeof(ChildEntity);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            //Act
            var actual = mapper.Map<ChildEntity>(childModel);

            //Assert
            Assert.Equal(childEntity.GetType().ToString(), actual.GetType().ToString());
        }
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModel()
        {
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };
            var childModel = new ChildModel();           
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            var actual = mapper.Map<ChildModel>(childEntity);

            Assert.Equal(childModel.GetType().ToString(), actual.GetType().ToString());
        }

        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameName()
        {
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };            

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            var actual = mapper.Map<ChildModel>(childEntity);
            
            Assert.Equal("Marco",actual.ChildName);
        }
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameBirthDate()
        {
            var birthDate = new DateTime(2005, 2, 3);
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate= birthDate };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            var actual = mapper.Map<ChildModel>(childEntity);

            Assert.Equal(birthDate, actual.BirthDate);
        }
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameId()
        {
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            var actual = mapper.Map<ChildModel>(childEntity);

            Assert.Equal(1, actual.Id);
        }
       
    }
}
using AutoMapper;
using backend1;
using backend1.Data;
using backend1.Data.Entity;
using backend1.Data.Repository;
using backend1.Models;
using backend1.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ServicesUT
{
    //https://stackoverflow.com/questions/45409622/net-core-how-to-unit-test-service
    public class ChildServiceUT:BaseTest
    {

         [Fact]
         public async void GetChildren_TwoChildrenAdded_ReturnsListWith2Children_UNIT()
         {
            // ARRANGE
             var martina = new ChildEntity()
             {
                 Id=1,
                 ChildName = "Martina",
                 BirthDate = new DateTime(2007, 3, 5)
             };
             var tatiana = new ChildEntity()
             {
                 Id = 2,
                 ChildName = "Tatiana",
                 BirthDate = new DateTime(2007, 3, 5)
             };            
             var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
             var mapper = config.CreateMapper();
             var enumerable = new List<ChildEntity>() { martina, tatiana } as IEnumerable<ChildEntity>;             
             var repositoryMock = new Mock<IChildrenWithCourageAppRepository>();             
             repositoryMock.Setup(r => r.GetChildrenAsync()).ReturnsAsync(enumerable);
             var childService = new ChildService(repositoryMock.Object, mapper);

             // ACT 
             var listChildren = await childService.GetChildrenAsync();


             // ASSERT
             Assert.Equal(2, listChildren.Last().Id);
         }
        [Fact]
        public async void GetChildren_TwoChildrenAdded_ReturnsListWithTwoChildren_INTEGRATION()
        {
            // ARRANGE
            var martinaModel = new ChildModel()
            {

                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
             var tatianaModel = new ChildModel()
             {

                 ChildName = "Tatiana",
                 BirthDate = new DateTime(2007, 3, 5)
             };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();                        
            var repositoryMock = new ChildrenWithCourageAppRepository(ctx);
            var childService = new ChildService(repositoryMock, mapper);

            // Act
            var mart = await childService.CreateChildAsync(martinaModel);
            await childService.CreateChildAsync(tatianaModel);
            var listChildren =  await childService.GetChildrenAsync();


            // ASSERT
            Assert.Equal(2, listChildren.Count());
        }

        /*[Fact]
        public void GetChildren_ChildrenList_ReturnChildren()
        {
            var martina = new ChildEntity()
            {
                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ChildrenWithCourageDBContext>()
            .UseInMemoryDatabase(databaseName: "ChildrenWithCourageDB")
            .Options;
            using (var context = new ChildrenWithCourageDBContext(options))
            {
                context.Children.Add(martina);

                context.SaveChanges();
            }
            martina.Id = 1;
            //
            using (var context = new ChildrenWithCourageDBContext(options))
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
                var mapper = config.CreateMapper();
                Task<IEnumerable<ChildEntity>> enumerable = (Task<IEnumerable<ChildEntity>>)(new List<ChildEntity>() { martina } as IEnumerable<ChildEntity>);
                // Arrange
                var repositoryMock = new Mock<IChildrenWithCourageAppRepository>();
                repositoryMock.Setup(r => r.GetChildrenAsync()).Returns(enumerable);

                var childService = new ChildService(repositoryMock.Object, mapper);

                // Act
                var blog = childService.GetChildrenAsync();
                repositoryMock.Verify(r => r.GetChildrenAsync());
                // Assert
                //repositoryMock.Verify(r => r.GetBlogByName("Blog2"));
                //Assert.Equal(null,);

            }
        
        }*/
    }
}


using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Services.Data;
using SweetAcademy.Web.ViewModels.Chef;
using SweetAcademy.Web.ViewModels.User;

namespace SweetAcademy.Services.Tests
{
    [TestFixture]
    public class ChefServiceTests
    {

        private DbContextOptions<SweetAcademyDbContext> _dbContextOptions;
        private SweetAcademyDbContext _dbContext;
        private IChefService _chefService;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<SweetAcademyDbContext>()
                .UseInMemoryDatabase("SweetAcademyInMemory" + Guid.NewGuid().ToString()).Options;
            _dbContext = new SweetAcademyDbContext(_dbContextOptions);
            _dbContext.Database.EnsureCreated();
            DatabaseSeeder.SeedDatabase(_dbContext); 
            _chefService = new ChefService(_dbContext);
        }

        [Test]
        public async Task AddChefAsync_ShouldAddChefToDatabase()
        {
            using (var _dbContext = new SweetAcademyDbContext(_dbContextOptions))
            {
                
                var _chefService = new ChefService(_dbContext);

                var model = new AddChefViewModel
                {
                    FullName = "John Doe",
                    ApplicationUserId = Guid.NewGuid(),
                    PhoneNumber = 1234567890,
                    TaxPerTrainingForStudent = 10.0m,
                    Active = true,
                    Users = new List<UserViewModel>()
                };

                await _chefService.AddChefAsync(model);

                var addedChef = await _dbContext.Chefs.FirstOrDefaultAsync(c => c.ApplicationUserId == model.ApplicationUserId);

                // Assertions
                Assert.NotNull(addedChef);
                Assert.AreEqual(model.FullName, addedChef.FullName);
             
            }
        }

        [Test]
        public async Task ChefExistByUserIdShouldReturnTrueWhenThereIsChef()
        {
            var userId = DatabaseSeeder.Chef.ApplicationUserId; 

            var result = await _chefService.ChefExistByUserIdAsync(userId);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllChefsAsync_ShouldReturnListOfChefs()
        {
            var chefs = await _chefService.GetAllChefsAsync();

            Assert.NotNull(chefs);
            Assert.IsNotEmpty(chefs);
            Assert.AreEqual(DatabaseSeeder.Chef.FullName, chefs.First().FullName); 
            
        }

        [Test]
        public async Task GetChefByIdAsync_ShouldReturnCorrectChef()
        {
            var chefId = DatabaseSeeder.Chef.Id; 

            var chefViewModel = await _chefService.GetChefByIdAsync(chefId);

            Assert.NotNull(chefViewModel);
            Assert.AreEqual(DatabaseSeeder.Chef.FullName, chefViewModel.FullName);
            
        }


        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}

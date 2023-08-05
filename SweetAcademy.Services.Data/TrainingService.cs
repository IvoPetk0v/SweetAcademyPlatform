
using SweetAcademy.Data;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Training;

namespace SweetAcademy.Services.Data
{
    public class TrainingService : ITrainingService
    {
        private readonly SweetAcademyDbContext dbContext;

        public TrainingService(SweetAcademyDbContext context)
        {
            this.dbContext = context;
        }
        public Task<ICollection<TrainingViewModel>> GetAllTrainingAsync()
        {
            throw new NotImplementedException();
        }
    }
}

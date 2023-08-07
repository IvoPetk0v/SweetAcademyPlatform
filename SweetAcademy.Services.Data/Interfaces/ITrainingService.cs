
using SweetAcademy.Web.ViewModels.Training;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface ITrainingService
    {
        Task<ICollection<TrainingViewModel>> GetAllActiveTrainingAsync();
        Task<ICollection<TrainingViewModel>> GetAllTrainingAsync();
        Task<TrainingViewModel> ShowDetailsByIdAsync(int id);

        Task DeActivateByIdAsync(int id);

        Task ActivateByIdAsync(int id);

        Task AddTrainingAsync(AddTrainingViewModel model);

        Task<ICollection<DateTime>> GetTrainingDateAsync();
        Task<ICollection<TrainingViewModel>> AllByChef(Guid chefId);
    }
}

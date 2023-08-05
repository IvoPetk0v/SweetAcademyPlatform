
using SweetAcademy.Web.ViewModels.Training;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface ITrainingService
    {
        Task<ICollection<TrainingViewModel>> GetAllActiveTrainingAsync();
        Task<TrainingViewModel> ShowDetailsByIdAsync(int id);
    }
}

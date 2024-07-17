using System;
using System.Threading.Tasks;

namespace CahanMotors.Data.Abstract.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICarRepository Cars { get; }
        IRegisterRepository Registers { get; }
        IPhotoRepository Photos { get; }
        IQuestionRepository Questions { get; }
        ISliderRepository Sliders { get; }
        IArticleRepository Articles { get; }
        ICarBrendModelRepository CarBrendModels { get; }
        Task<int> SaveAsync();
    }
}

using CahanMotors.Entities.ComplexTypes;
using CahanMotors.Entities.DTOs;
using CahanMotors.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Services.Abstract
{
    public interface ICarBrendModelService
    {
        Task<IDataResult<CarBrendModelDto>> Get(int CarBrendModelId);
        Task<IDataResult<CarBrendModelListDto>> GetAll();
        Task<IDataResult<CarBrendModelListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CarBrendModelUpdateDto>> GetCarBrendModelUpdateDto(int CarBrendModelId);
        Task<IDataResult<CarBrendModelDto>> Add(CarBrendModelAddDto CarBrendModelAddDto, string createdByName);
        Task<IDataResult<CarBrendModelDto>> Update(CarBrendModelUpdateDto CarBrendModelUpdateDto, string modifiedByName);
        Task<IResult> Delete(int CarBrendModelId, string modifiedByName);
    }
}

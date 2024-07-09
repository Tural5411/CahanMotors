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
    public interface IPhotoService
    {
        //All Service Methods Are Async!
        Task<IDataResult<PhotoDto>> Get(int photoId);
        Task<IDataResult<PhotoListDto>> GetAllByNonDeletedAndActive(int projectId);
        Task<IDataResult<PhotoListDto>> GetAllByNonDeletedAndActiveV2(int productId);
        Task<IResult> Add(PhotoAddDto photoAddDto, string createdByName);
        Task<IResult> HardDelete(int photoId);
    }
}

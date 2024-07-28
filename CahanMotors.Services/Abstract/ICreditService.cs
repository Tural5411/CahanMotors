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
    public interface ICreditService
    {
        Task<IDataResult<CreditDto>> Get(int creditId);
        Task<IDataResult<CreditListDto>> GetAll();
        Task<IDataResult<CreditListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<CreditUpdateDto>> GetCreditUpdateDto(int CreditId);
        Task<IDataResult<CreditDto>> Add(CreditAddDto CreditAddDto);
        Task<IDataResult<CreditDto>> Update(CreditUpdateDto CreditUpdateDto);
        Task<IResult> Delete(int CreditId);
    }
}

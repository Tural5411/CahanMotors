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
    public interface IQuestionService
    {
        Task<IDataResult<QuestionDto>> Get(int QuestionId);
        Task<IDataResult<QuestionListDto>> GetAll();
        Task<IDataResult<QuestionListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<QuestionUpdateDto>> GetQuestionUpdateDto(int QuestionId);
        Task<IDataResult<QuestionDto>> Add(QuestionAddDto QuestionAddDto, string createdByName);
        Task<IDataResult<QuestionDto>> Update(QuestionUpdateDto QuestionUpdateDto, string modifiedByName);
        Task<IResult> Delete(int QuestionId, string modifiedByName);
    }
}

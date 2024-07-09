using Microsoft.AspNetCore.Http;
using CahanMotors.Entities.DTOs;
using CahanMotors.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Helpers.Abstract
{
    public interface IFileHelper
    {
        Task<IDataResult<FileUploadDto>> UploadFile(string name,
            IFormFile pdfFile, string folderName = null);
        IDataResult<FileDeletedDto> FileDelete(string fileName);
    }
}

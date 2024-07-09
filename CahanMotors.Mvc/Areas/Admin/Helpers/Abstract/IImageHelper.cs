using Microsoft.AspNetCore.Http;
using CahanMotors.Shared.Utilities.Results.Abstract;
using CahanMotors.Entities.ComplexTypes;
using CahanMotors.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Helpers.Abstract
{
    public interface IImageHelper
    {
        //string UploadImage(string name, 
        //    IFormFile pictureFile,PictureType pictureType, string folderName=null);

        Task<string> UploadImageV2(IFormFile file);
        Task<IDataResult<ImageUploadedDto>> UploadImage(string name,
            IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> ImageDelete(string PictureName);
    }
}

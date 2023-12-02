using Microsoft.AspNetCore.Mvc;
using KHN.FileUploader.API.Models;
using KHN.FileUploader.API.Services;

namespace KHN.FileUploader.API.Controllers
{
	[ApiController]
	[Route("khnapi/[controller]")]
	public class FileController : ControllerBase
	{
		private readonly IFileService _uploadService;

		public FileController(IFileService uploadService)
		{
			_uploadService = uploadService;
		}


		/// <summary>
		/// Single File Upload
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		[HttpPost("PostSingleFile/{companyName}")]
		public async Task<ResponseModel> PostSingleFile([FromForm] FileUploadModel fileDetails, string companyName)
		{
			ResponseModel model = new ResponseModel();

			if (fileDetails == null)
			{
				return model;
			}

			try
			{
				model = await _uploadService.PostFileAsync(fileDetails.FileDetails, companyName);
			}
			catch (Exception)
			{
				throw;
			}

			return model;
		}

	}
}

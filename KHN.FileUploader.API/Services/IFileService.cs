using KHN.FileUploader.API.Models;

namespace KHN.FileUploader.API.Services
{
	public interface IFileService
	{
		Task<ResponseModel> PostFileAsync(IFormFile fileData, string companyName);
	}
}
using KHN.FileUploader.API.Models;
using System.Reflection;

namespace KHN.FileUploader.API.Services
{
	public class FileService : IFileService
	{
		public async Task<ResponseModel> PostFileAsync(IFormFile fileData, string companyName)
		{
			ResponseModel model = new ResponseModel();

			if (fileData != null && fileData.Length > 0)
			{
				string path = @"wwwroot\" + companyName;
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}

				var fileName = Guid.NewGuid() + Path.GetExtension(fileData.FileName);

				var filePath = Path.Combine(
					Directory.GetCurrentDirectory(),
					@"wwwroot" + "\\" + companyName + "\\",
					fileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await fileData.CopyToAsync(fileStream);
				}

				model.Path = @"wwwroot" + @"\" + companyName + @"\";
				model.FileName = fileName;
				model.FullAddress = model.Path + model.FileName;
			}

			return model;
		}
	}
}

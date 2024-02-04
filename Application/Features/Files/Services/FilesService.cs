using Application.Features.Files.Options;
using Application.Features.Host.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Features.Files.Services;

public class FilesService(IOptions<FilesOptions> filesOption, IOptions<UwOptions> hostOptions)
{
	private readonly FilesOptions _filesOption = filesOption.Value;
	private readonly UwOptions _hostOption = hostOptions.Value;

	public async Task<string> Write(IFormFile file)
	{
		var fileExtension = Path.GetExtension(file.FileName);

		var fileName = $"{Guid.NewGuid()}{fileExtension}";

		var filePath = $"{_filesOption.StoragePath}{fileName}";

		using (Stream fileStream = new FileStream(filePath, FileMode.Create))
		{
			await file.CopyToAsync(fileStream);
		}

		return fileName;
	}

	public void RemoveFile(string filePath)
	{
		File.Delete(filePath);
	}

	public string GetFileLink(string fileName)
	{
		return $"{_hostOption.Host}{_hostOption.MediaPath}/{fileName}";
	}
}


using Application.Features.Auth;
using Application.Features.Files.Models;
using Application.Features.Files.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Files.Controllers;


[ApiController]
[Route("files")]
public class FileController(FilesService filesService)
{
	private readonly FilesService _filesService = filesService;

	[HttpPost("upload")]
	public async Task<CreateFileResponse> Upoload(IFormFile file)
	{
		var filePath = await _filesService.Write(file);
		
		return new CreateFileResponse()
		{
			FilePath = filePath,
		};
	}

}

#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace militaryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageUploadController : ControllerBase
{
    private readonly IWebHostEnvironment _hosting;

    public ImageUploadController(IWebHostEnvironment hosting)
    {
        _hosting = hosting;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult PostSoldierImage(IFormFile file)
    {
        string webRootPath = _hosting.WebRootPath;
        string absolutePath = Path.Combine($"{webRootPath}/images/SoldierImage/{file.FileName}");

        try
        {
            using(var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            
            return StatusCode(201);
        }
        catch
        {
            return StatusCode(501);
        }        
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult PostWeaponImage(IFormFile file)
    {
        string webRootPath = _hosting.WebRootPath;
        string absolutePath = Path.Combine($"{webRootPath}/images/weaponImage/{file.FileName}");

        try{
            using(var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return StatusCode(201);
        }
        catch
        {
            return StatusCode(501);
        }
    }
}
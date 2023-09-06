using AutoMapper;
using Infrastructure.Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace StorageService.API.Controllers;

[Route("api/Advertisement")]
[ApiController]

public class AdvertisementController : Controller
{
    private readonly IAdvertisementRepository _db;
    private readonly ILogger<AdvertisementController> _logger;
    private readonly IMapper _mapper;

    public AdvertisementController(IAdvertisementRepository db, ILogger<AdvertisementController> logger, 
        IMapper mapper)
    {
        _db = db;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task GetAdvertisement(int id, [FromQuery] string fields = "")
    {
        
    }
    
}
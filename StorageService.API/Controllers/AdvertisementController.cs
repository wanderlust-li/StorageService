using System.Net;
using System.Text.Json;
using AutoMapper;
using StorageService.Application.DTO;
using StorageService.Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using StorageService.Domain.Entities;

namespace StorageService.API.Controllers;

[Route("api/Advertisement")]
[ApiController]

public class AdvertisementController : Controller
{
    private readonly IAdvertisementRepository _db;
    private readonly IGetAllRepository _allRepository;
    private readonly ILogger<AdvertisementController> _logger;
    private readonly IMapper _mapper;
    private readonly APIResponse _response;

    public AdvertisementController(IAdvertisementRepository db, ILogger<AdvertisementController> logger, 
        IMapper mapper, IGetAllRepository allRepository)
    {
        _db = db;
        _logger = logger;
        _mapper = mapper;
        _allRepository = allRepository;
        this._response = new();
    }
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetAdvertisements([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortBy = null)
    {
        try
        {
            var advertisements = await _allRepository.GetAllAsync(null, pageSize, pageNumber, sortBy);
            // var result = _mapper.Map<List<AdvertisementDTO>>(advertisements);

            _response.Result = _mapper.Map<List<AdvertisementDTO>>(advertisements);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
 
    }

    [HttpGet("{id:int}", Name = "GetAdvertisement")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<APIResponse>> GetAdvertisement(int id)
    {
        try
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            var advertisement = await _db.GetAsync(u => u.Id == id);

            if (advertisement == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<AdvertisementDTO>(advertisement);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    
    
    

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> CreateAdvertisement([FromBody] CreateAdvertisementDTO createDto)
    {
        try
        {
            if (await _db.GetAsync(u => u.Title.ToLower() == createDto.Title.ToLower()) != null)
            {
                ModelState.AddModelError("ErrorMessages", "Advertisement already Exists!");
                return BadRequest(ModelState);
            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            Advertisement advertisement = _mapper.Map<Advertisement>(createDto);

            await _db.CreateAsync(advertisement);

            _response.Result = _mapper.Map<CreateAdvertisementDTO>(advertisement);
            _response.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetAdvertisement", new { id = advertisement.Id }, _response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}
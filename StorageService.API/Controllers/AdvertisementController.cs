﻿using System.Net;
using AutoMapper;
using Infrastructure.Application.DTO;
using Infrastructure.Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using StorageService.Domain.Entities;

namespace StorageService.API.Controllers;

[Route("api/Advertisement")]
[ApiController]

public class AdvertisementController : Controller
{
    private readonly IAdvertisementRepository _db;
    private readonly ILogger<AdvertisementController> _logger;
    private readonly IMapper _mapper;
    private readonly APIResponse _response;

    public AdvertisementController(IAdvertisementRepository db, ILogger<AdvertisementController> logger, 
        IMapper mapper)
    {
        _db = db;
        _logger = logger;
        _mapper = mapper;
        this._response = new();
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
    
}
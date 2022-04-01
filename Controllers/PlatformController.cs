using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class PlatformsController: ControllerBase
{
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper= mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("=> Getting Pla");
        var platformItem = _repo.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }

    [HttpGet("{id}", Name ="GetPlatformsById")]
    public ActionResult<PlatformReadDto> GetPlatformsById(int id)
    {
        Console.WriteLine("=> Getting Pla");
        var platformItem = _repo.GetPlatformByID(id);
        if(platformItem!= null)
        {
        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto createPlatform)
    {
        Console.WriteLine("=> creating Pla");
        var platformModel =  _mapper.Map<Platform>(createPlatform);
        _repo.CreatPlatform(platformModel);
        _repo.SaveChanges();

        var item = _mapper.Map<PlatformReadDto>(platformModel);

        return CreatedAtRoute(nameof(GetPlatformsById), new {id= item.Id,},item );
    }
}
}
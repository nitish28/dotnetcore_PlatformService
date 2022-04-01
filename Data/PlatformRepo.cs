using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{

    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        

        public void CreatPlatform(Platform platform)
        {
            if(platform== null)
            {
                throw new ArgumentNullException();
            }
            _context.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformByID(int id)
        {
             return _context.Platforms.FirstOrDefault(x=> x.Id == id);
        }

        public bool SaveChanges()
        {
           return _context.SaveChanges() > 0 ? true: false;
        }
    }
    }
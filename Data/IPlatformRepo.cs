using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{

public interface IPlatformRepo
{
bool SaveChanges();
IEnumerable<Platform> GetAllPlatforms();
Platform GetPlatformByID(int id);
void CreatPlatform(Platform platform);

}
}
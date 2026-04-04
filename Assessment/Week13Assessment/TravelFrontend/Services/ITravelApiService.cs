using System;
using TravelFrontend.Models;

namespace TravelFrontend.Services;

public interface ITravelApiService
{
    Task<IEnumerable<Destination>> GetAllAsync();
}

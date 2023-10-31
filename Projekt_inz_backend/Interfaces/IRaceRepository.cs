using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IRaceRepository
    {
        public ICollection<Race> GetRaces();
        public Race GetRace(int id);
        public ICollection<Race> GetRace(string name);
        public bool CreateRace(int ownerId, Race race);
        public bool UpdateRace(Race race);
        public bool DeleteRace(Race race);
        public bool Save();
    }
}


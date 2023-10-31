using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly DndDatabaseContext _context;

        public RaceRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public bool CreateRace(int ownerId, Race race)
        {
            User ownerEntity = _context.Users.Where(b => b.userID == ownerId).FirstOrDefault();
            race.owner = ownerEntity;
            _context.Add(race);
            return Save();
        }

        public Race GetRace(int id)
        {
            return _context.Races.Where(b => b.raceID == id).FirstOrDefault();
        }

        public ICollection<Race> GetRace(string name)
        {
            return _context.Races.Where(b => b.raceName == name).ToList();
        }

        public ICollection<Race> GetRaces()
        {
            return _context.Races.OrderBy(b => b.raceID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

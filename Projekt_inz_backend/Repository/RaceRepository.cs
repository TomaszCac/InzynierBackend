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

        public bool DeleteRace(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public Race GetRace(int id)
        {
            return _context.Races.Where(b => b.raceId == id).FirstOrDefault();
        }

        public ICollection<Race> GetRace(string name)
        {
            return _context.Races.Where(b => b.raceName == name).ToList();
        }

        public ICollection<Race> GetRaces()
        {
            return _context.Races.OrderBy(b => b.raceId).ToList();
        }
        public int GetOwnerId(int raceId)
        {
            return _context.Races.Where(b => b.raceId == raceId).Select(b => b.owner.userID).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRace(Race race)
        {
            _context.Update(race);
            return Save();
        }

        public ICollection<Race> GetRacesByOwner(int ownerId)
        {
            return _context.Races.Where(b => b.owner.userID == ownerId).ToList();
        }

        public int Upvotes(int raceId)
        {
            return _context.upvotes.Where(b => b.category == "race" && b.categoryId == raceId).Count();
        }

        public bool Upvote(int userid, int raceId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "race" && b.userId == userid && b.categoryId == raceId).FirstOrDefault();
            if (upvote != null)
            {
                _context.upvotes.Remove(upvote);
                return Save();
            }
            upvote = new Upvote();
            upvote.userId = userid;
            upvote.category = "race";
            upvote.categoryId = raceId;
            _context.upvotes.Add(upvote);
            return Save();
        }

        public bool CheckUpvote(int userid, int raceId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "race" && b.userId == userid && b.categoryId == raceId).FirstOrDefault();
            if (upvote != null)
            {
                return true;
            }
            return false;
        }
    }
}

using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class CustomRaceFeatureRepository : ICustomRaceFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public CustomRaceFeatureRepository(DndDatabaseContext context )
        {
            _context = context;
        }

        public bool CreateCustomRaceFeature(int raceId, CustomRaceFeature customRaceFeature)
        {
            var customRaceFeatureRace = _context.Races.Where(b => b.raceId == raceId).FirstOrDefault();
            customRaceFeature.usedBy = customRaceFeatureRace;
            _context.Add(customRaceFeature);
            return Save();
        }

        public bool DeleteCustomRaceFeature(CustomRaceFeature customRaceFeature)
        {
            _context.Remove(customRaceFeature);
            return Save();
        }

        public ICollection<CustomRaceFeature> GetCustomRaceFeature(int raceId)
        {
            var customs = _context.Races.Where(b => b.raceId == raceId).Select(b => b.customFeatures).SingleOrDefault();
            return customs;
        }

        public ICollection<CustomRaceFeature> GetCustomRaceFeatures()
        {
            return _context.customRaceFeatures.OrderBy(b => b.featureId).ToList();
        }
        public int GetOwnerIdByFeatureId(int featureId)
        {
            return _context.customRaceFeatures.Where(b => b.featureId == featureId).Select(b => b.usedBy.owner.userID).FirstOrDefault();
        }
        public int GetOwnerIdByRaceId(int raceId)
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

        public bool UpdateCustomRaceFeature(CustomRaceFeature customRaceFeature)
        {
            _context.Update(customRaceFeature);
            return Save();
        }
    }
}

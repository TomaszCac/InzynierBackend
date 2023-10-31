using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class RaceFeatureRepository : IRaceFeatureRepository
    {
        private readonly DndDatabaseContext _context;
        public RaceFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public bool CreateRaceFeature(int raceId, RaceFeature raceFeature)
        {
            var raceFeatureRace = _context.Races.Where(b => b.raceID == raceId).FirstOrDefault();
            raceFeature.usedBy = raceFeatureRace;
            _context.Add(raceFeature);
            return Save();
        }

        public bool DeleteRaceFeature(RaceFeature raceFeature)
        {
            _context.Remove(raceFeature);
            return Save();
        }

        public RaceFeature GetRaceFeature(int raceId)
        {
            return _context.raceFeatures.Where(b => b.raceID == raceId).FirstOrDefault();
        }

        public ICollection<RaceFeature> GetRaceFeatures()
        {
            return _context.raceFeatures.OrderBy(b => b.featureID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRaceFeature(RaceFeature raceFeature)
        {
            _context.Update(raceFeature);
            return Save();
        }
    }
}

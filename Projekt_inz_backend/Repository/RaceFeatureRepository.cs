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

        public RaceFeature GetRaceFeature(int id)
        {
            return _context.raceFeatures.Where(b => b.raceID == id).FirstOrDefault();
        }

        public ICollection<RaceFeature> GetRaceFeatures()
        {
            return _context.raceFeatures.OrderBy(b => b.featureID).ToList();
        }
    }
}

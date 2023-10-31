using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class CustomRaceFeatureRepository : ICustomRaceFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public CustomRaceFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public ICollection<CustomRaceFeature> GetCustomRaceFeatures()
        {
            return _context.customRaceFeatures.OrderBy(b => b.featureID).ToList();
        }
    }
}

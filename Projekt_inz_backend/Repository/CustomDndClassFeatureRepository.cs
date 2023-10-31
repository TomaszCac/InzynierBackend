using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class CustomDndClassFeatureRepository : ICustomDndClassFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public CustomDndClassFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public ICollection<CustomDndClassFeature> GetCustomDndClassFeatures()
        {
            return _context.customDndClassFeatures.OrderBy(b => b.featureID).ToList();
        }
    }
}

using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class DndClassFeatureRepository : IDndClassFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public DndClassFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public DndClassFeature GetClassFeatureById(int id)
        {
            return _context.dndClassFeatures.Where(b => b.DndClassID == id).FirstOrDefault();
        }

        public ICollection<DndClassFeature> GetClassFeatures()
        {
            return _context.dndClassFeatures.OrderBy(b => b.featureID).ToList();
        }
    }
}

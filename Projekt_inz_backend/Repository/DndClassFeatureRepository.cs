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

        public bool CreateClassFeature(int classId, DndClassFeature feature)
        {
            var classEntity = _context.dndClasses.Where(b => b.classID == classId).FirstOrDefault();
            feature.usedBy = classEntity;
            _context.Add(feature);
            return Save();
        }

        public bool DeleteClassFeature(DndClassFeature feature)
        {
            _context.Remove(feature);
            return Save();
        }

        public DndClassFeature GetClassFeatureById(int id)
        {
            return _context.dndClassFeatures.Where(b => b.DndClassID == id).FirstOrDefault();
        }

        public ICollection<DndClassFeature> GetClassFeatures()
        {
            return _context.dndClassFeatures.OrderBy(b => b.featureID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClassFeature(DndClassFeature feature)
        {
            _context.Update(feature);
            return Save();
        }
    }
}

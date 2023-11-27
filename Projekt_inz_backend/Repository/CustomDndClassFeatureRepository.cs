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

        public bool CreateCustomDndClassFeature(int classId, CustomDndClassFeature customFeature)
        {
            var classEntity = _context.dndClasses.Where(b => b.classId == classId).FirstOrDefault();
            customFeature.usedBy = classEntity;
            _context.Add(customFeature);
            return Save();
        }

        public bool DeleteCustomDndClassFeature(CustomDndClassFeature customFeature)
        {
            _context.Remove(customFeature);
            return Save();
        }

        public ICollection<CustomDndClassFeature> GetCustomDndClassFeature(int classId)
        {
            return _context.customDndClassFeatures.Where(b => b.usedBy.classId == classId).ToList();
        }

        public ICollection<CustomDndClassFeature> GetCustomDndClassFeatures()
        {
            return _context.customDndClassFeatures.OrderBy(b => b.featureId).ToList();
        }

        public int GetOwnerIdByFeatureId(int featureId)
        {
            return _context.customDndClassFeatures.Where(b => b.featureId == featureId).Select(b => b.usedBy.owner.userID).FirstOrDefault();
        }
        public int GetOwnerIdByClassId(int classId)
        {
            return _context.dndClasses.Where(b => b.classId == classId).Select(b => b.owner.userID).FirstOrDefault();
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

        public bool UpdateCustomDndClassFeature(CustomDndClassFeature customFeature)
        {
            _context.Update(customFeature);
            return Save();
        }
    }
}

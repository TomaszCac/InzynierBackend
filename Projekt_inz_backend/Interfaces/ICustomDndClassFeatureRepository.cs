using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ICustomDndClassFeatureRepository
    {
        public ICollection<CustomDndClassFeature> GetCustomDndClassFeatures();
        public ICollection<CustomDndClassFeature> GetCustomDndClassFeature(int classId);
        public bool CreateCustomDndClassFeature(int classId, CustomDndClassFeature customFeature);
        public bool DeleteCustomDndClassFeature(CustomDndClassFeature customFeature);
        public bool UpdateCustomDndClassFeature(CustomDndClassFeature customFeature); 
        public bool Save();
        public int GetOwnerIdByFeatureId(int featureId);
        public int GetOwnerIdByClassId(int classId);
        public int GetUserIdByName(string username);
    }
}

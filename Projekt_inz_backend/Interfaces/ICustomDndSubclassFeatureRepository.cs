using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ICustomDndSubclassFeatureRepository
    {
        public ICollection<CustomDndSubclassFeature> GetCustomSubclassFeatures();
        public CustomDndSubclassFeature GetCustomSubclassFeature(int featureid);
        public bool Save();
        public bool DeleteCustomSubclassFeature(CustomDndSubclassFeature feature);
        public bool UpdateCustomSubclassFeature(CustomDndSubclassFeature feature);
        public bool CreateCustomSubclassFeature(int subclassid, CustomDndSubclassFeature feature);
        public ICollection<CustomDndSubclassFeature> GetCustomDndsubclassFeaturesFromSubclass(int subclassid);
    }
}

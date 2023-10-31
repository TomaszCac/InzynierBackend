using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IDndClassFeatureRepository
    {
        public ICollection<DndClassFeature> GetClassFeatures();
        public DndClassFeature GetClassFeatureById(int id);
    }
}

﻿using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class CustomDndSubclassFeatureRepository : ICustomDndSubclassFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public CustomDndSubclassFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public bool CreateCustomSubclassFeature(int subclassid, CustomDndSubclassFeature feature)
        {
            DndSubclass dndSubclassEntity = _context.dndSubclasses.Where(b => b.subclassId == subclassid).FirstOrDefault();
            feature.usedBy = dndSubclassEntity;
            _context.Add(feature);
            return Save();
        }

        public bool DeleteCustomSubclassFeature(CustomDndSubclassFeature feature)
        {
            _context.Remove(feature);
            return Save();
        }

        public ICollection<CustomDndSubclassFeature> GetCustomDndsubclassFeaturesFromSubclass(int subclassid)
        {
            return _context.customDndSubclassFeatures.Where(b => b.usedBy.subclassId == subclassid).ToList();
        }

        public CustomDndSubclassFeature GetCustomSubclassFeature(int featureid)
        {
            return _context.customDndSubclassFeatures.Where(b => b.featureId == featureid).FirstOrDefault();
        }

        public ICollection<CustomDndSubclassFeature> GetCustomSubclassFeatures()
        {
            return _context.customDndSubclassFeatures.ToList();
        }
        public int GetOwnerId(int subclassId)
        {
            return _context.dndSubclasses.Where(b => b.subclassId == subclassId).Select(b => b.owner.userID).FirstOrDefault();
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

        public bool UpdateCustomSubclassFeature(CustomDndSubclassFeature feature)
        {
            _context.Update(feature);
            return Save();
        }
    }
}

using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class SpellRepository : ISpellRepository
    {
        private readonly DndDatabaseContext _context;

        public SpellRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public ICollection<Spell> GetSpells()
        {
            return _context.Spells.OrderBy(c => c.spellId).ToList();
        }
        public Spell GetSpellById(int spellID)
        {
            return _context.Spells.Where(b => b.spellId == spellID).FirstOrDefault();
        }
        public ICollection<Spell> GetSpellByName(string spellname)
        {
            return _context.Spells.Where(b => b.spellName == spellname).ToList();
        }
        public ICollection<Spell> GetSpellByLvl(int lvl)
        {
            return _context.Spells.Where(b => b.spellLevel == lvl).ToList();
        }

        public User GetOwner(int id)
        {
            return _context.Spells.Where(b => b.spellId == id).Select(b => b.owner).FirstOrDefault();
        }

        public ICollection<DndClass> GetClassesUsing(int id)
        {
            return _context.spellsForClasses.Where(b => b.spellId == id).Select(b => b.usingClass).ToList();
        }

        public bool CreateSpell(int ownerId, Spell spell)
        {
            var spellOwnerEntity = _context.Users.Where(b => b.userID == ownerId).FirstOrDefault();
            spell.owner = spellOwnerEntity;
            _context.Add(spell);
            return Save();
            
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSpell(Spell spell)
        {
            _context.Update(spell);
            return Save();
        }
        public int GetOwnerId(int spellId)
        {
            return _context.Spells.Where(b => b.spellId == spellId).Select(b => b.owner.userID).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }

        public bool DeleteSpell(Spell spell)
        {
            var spellused = _context.spellsForClasses.Where(b => b.spellId == spell.spellId).ToList();
            foreach (var c in spellused)
            {
                _context.Remove(c);
            }
            _context.Remove(spell);
            return Save();
        }

        public ICollection<Spell> GetSpellsByOwner(int ownerId)
        {
            return _context.Spells.Where(b => b.owner.userID == ownerId).ToList();
        }

        public int Upvotes(int spellId)
        {
            return _context.upvotes.Where(b => b.category == "spell" && b.categoryId == spellId).Count();
        }

        public bool Upvote(int userid, int spellId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "spell" && b.userId == userid && b.categoryId == spellId).FirstOrDefault();
            if (upvote != null)
            {
                _context.upvotes.Remove(upvote);
                return Save();
            }
            upvote = new Upvote();
            upvote.userId = userid;
            upvote.category = "spell";
            upvote.categoryId = spellId;
            _context.upvotes.Add(upvote);
            return Save();
        }

        public bool CheckUpvote(int userid, int spellId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "spell" && b.userId == userid && b.categoryId == spellId).FirstOrDefault();
            if (upvote != null)
            {
                return true;
            }
            return false;
        }
    }
}

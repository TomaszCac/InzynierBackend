using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ISpellRepository
    {
        ICollection<Spell> GetSpells();
        Spell GetSpellById(int id);
        ICollection<Spell> GetSpellByName(string spellname);
        ICollection<Spell> GetSpellByLvl(int lvl);
        User GetOwner(int id);
        bool CreateSpell(int ownerId, Spell spell);
        bool UpdateSpell(Spell spell);
        bool DeleteSpell(Spell spell);
        bool Save();
        public int GetOwnerId(int spellId);
        public int GetUserIdByName(string username);
        ICollection<Spell> GetSpellsByOwner(int ownerId);
        public bool Upvote(int userid, int spellId);
        public bool CheckUpvote(int userid, int spellId);
        public ICollection<Spell> UpvotedList(int userid);
    }
}

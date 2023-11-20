namespace Projekt_inz_backend.Dto
{
    public class DndClassDto
    {
        public int? classId { get; set; }
        public string className { get; set; }
        public string[] classTableHeader { get; set; }
        public string[,] classTableData { get; set; }
        public string[] spellTableHeader { get; set; }
        public string[,] spellTableData { get; set; }
        public int? inheritedClassID { get; set; }
        public string classDescription { get; set; }
        public string classMulticlassReq { get; set; }
        public string classHitDice { get; set; }
        public string classHitPointsAtFirst { get; set; }
        public string classHitPointsAtHigh { get; set; }
        public string classArmorProficency { get; set; }
        public string classWeaponProficency { get; set; }
        public string classToolsProficency { get; set; }
        public string classSavingThrows { get; set; }
        public string classSkills { get; set; }
        public string classEquipment { get; set; }
    }
}

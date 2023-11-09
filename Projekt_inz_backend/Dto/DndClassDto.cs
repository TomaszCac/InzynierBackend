namespace Projekt_inz_backend.Dto
{
    public class DndClassDto
    {
        public int? classID { get; set; }
        public string className { get; set; }
        public string[] tableHeader { get; set; }
        public string[,] tableData { get; set; }
        public int? inheritedClassID { get; set; }
        public string classDescription { get; set; }
        public string multiclassReq { get; set; }
        public string hitDice { get; set; }
        public string hitPointsAtFirst { get; set; }
        public string hitPointsAtHigh { get; set; }
        public string armorProficency { get; set; }
        public string weaponProficency { get; set; }
        public string toolsProficency { get; set; }
        public string savingThrows { get; set; }
        public string skills { get; set; }
        public string equipment { get; set; }
    }
}

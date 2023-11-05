namespace Projekt_inz_backend.Dto
{
    public class DndClassFeatureDto
    {
        public int? featureID { get; set; }
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
        public int DndClassID { get; set; }
    }
}

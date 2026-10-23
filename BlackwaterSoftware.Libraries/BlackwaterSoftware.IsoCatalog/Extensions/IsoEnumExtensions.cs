using BlackwaterSoftware.IsoCatalog.Enums;

namespace BlackwaterSoftware.IsoCatalog.Extensions
{
    public static class IsoEnumExtensions
    {
        public static string ToDisplayName(this IsoOrganisation organisation)
        {
            return organisation switch
            {
                IsoOrganisation.ISO => "ISO",
                IsoOrganisation.IEC => "IEC",
                IsoOrganisation.ISOIEC => "ISO/IEC",
                _ => throw new ArgumentOutOfRangeException(nameof(organisation), organisation, null)
            };
        }

        public static string ToDisplayName(this IsoCategory category)
        {
            return category switch
            {
                IsoCategory.Unknown => "Unknown",
                IsoCategory.ArtificialIntelligence => "Artificial Intelligence",
                IsoCategory.BusinessContinuity => "Business Continuity",
                IsoCategory.EnergyManagement => "Energy Management",
                IsoCategory.EnvironmentalManagement => "Environmental Management",
                IsoCategory.FoodSafety => "Food Safety",
                IsoCategory.HealthAndSafety => "Health and Safety",
                IsoCategory.InformationSecurity => "Information Security",
                IsoCategory.MedicalDevices => "Medical Devices",
                IsoCategory.QualityManagement => "Quality Management",
                IsoCategory.RiskManagement => "Risk Management",
                _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
            };
        }
    }
}

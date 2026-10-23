using System.Collections.ObjectModel;
using BlackwaterSoftware.IsoCatalog.Enums;
using BlackwaterSoftware.IsoCatalog.Models;

namespace BlackwaterSoftware.IsoCatalog
{
    public static class IsoStandards
    {
        private static readonly ReadOnlyCollection<IsoStandard> _all = Array.AsReadOnly([
            new IsoStandard
            {
                Number = 9001,
                Name = "Quality management systems",
                Description = "Requirements for establishing and improving a quality management system.",
                Category = IsoCategory.QualityManagement,
                EditionYear = 2026,
                Status = IsoStandardStatus.Published,
                Url = new Uri("https://www.iso.org/standard/62085.html")
            },
            new IsoStandard
            {
                Number = 14001,
                Name = "Environmental management systems",
                Description = "Requirements with guidance for managing environmental responsibilities.",
                Category = IsoCategory.EnvironmentalManagement,
                EditionYear = 2026,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 45001,
                Name = "Occupational health and safety management systems",
                Description = "Requirements with guidance for managing workplace health and safety risks.",
                Category = IsoCategory.HealthAndSafety,
                EditionYear = 2018,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 27001,
                Name = "Information security management systems",
                Description = "Requirements for establishing and improving an information security management system.",
                Organization = IsoOrganisation.ISOIEC,
                Category = IsoCategory.InformationSecurity,
                EditionYear = 2022,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 42001,
                Name = "Artificial intelligence management system",
                Description = "Requirements and guidance for establishing an AI management system.",
                Organization = IsoOrganisation.ISOIEC,
                Category = IsoCategory.ArtificialIntelligence,
                EditionYear = 2023,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 22301,
                Name = "Security and resilience — Business continuity management systems",
                Description = "Requirements for preparing for, responding to, and recovering from disruptions.",
                Category = IsoCategory.BusinessContinuity,
                EditionYear = 2019,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 50001,
                Name = "Energy management systems",
                Description = "Requirements with guidance for improving energy performance.",
                Category = IsoCategory.EnergyManagement,
                EditionYear = 2018,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 22000,
                Name = "Food safety management systems",
                Description = "Requirements for organizations across the food chain.",
                Category = IsoCategory.FoodSafety,
                EditionYear = 2018,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 13485,
                Name = "Medical devices — Quality management systems",
                Description = "Requirements for quality management systems used by medical device organizations.",
                Category = IsoCategory.MedicalDevices,
                EditionYear = 2016,
                Status = IsoStandardStatus.Published
            },
            new IsoStandard
            {
                Number = 31000,
                Name = "Risk management — Guidelines",
                Description = "Guidelines for identifying, assessing, and treating organizational risks.",
                Category = IsoCategory.RiskManagement,
                EditionYear = 2018,
                Status = IsoStandardStatus.Published
            }
        ]);

        public static IReadOnlyList<IsoStandard> All => _all;

        public static IsoStandard? GetByCode(string code)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code);

            return _all
                .FirstOrDefault(s => string.Equals(
                    s.Code,
                    code.Trim(),
                    StringComparison.OrdinalIgnoreCase));
        }

        public static IReadOnlyList<IsoStandard> GetByCategory(IsoCategory category)
        {
            return _all
                .Where(s => s.Category == category)
                .ToArray();
        }

        public static IReadOnlyList<IsoStandard> Search(string term)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(term);

            return _all
                .Where(s =>
                    s.Code.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    s.Number.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    s.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    s.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    (s.Category.ToString()?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToArray();
        }
    }
}

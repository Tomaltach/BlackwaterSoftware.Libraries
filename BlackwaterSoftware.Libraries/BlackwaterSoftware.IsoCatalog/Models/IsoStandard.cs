using BlackwaterSoftware.IsoCatalog.Enums;
using BlackwaterSoftware.IsoCatalog.Extensions;

namespace BlackwaterSoftware.IsoCatalog.Models
{
    public sealed record IsoStandard
    {
        public string Code =>
            $"{Organization.ToDisplayName()} {Number}" +
            (EditionYear.HasValue ? $":{EditionYear}" : "");
        public required int Number { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public IsoOrganisation Organization { get; init; } = IsoOrganisation.ISO;
        public string OrganisationName => Organization.ToDisplayName();
        public IsoCategory? Category { get; init; } = null;
        public string? CategoryName => Category?.ToDisplayName();
        public int? EditionYear { get; init; } = null;
        public IsoStandardStatus Status { get; init; } = IsoStandardStatus.Unknown;
        public Uri? Url { get; init; } = null;
        public IReadOnlyList<string> Replaces { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RelatedStandards { get; init; } = Array.Empty<string>();
    }
}

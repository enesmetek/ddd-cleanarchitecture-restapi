using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId(string sectionName) : ValueObject
    {
        public string Value { get; } = $"Section_{sectionName}";

        public static MenuSectionId Create(string sectionName)
        {
            return new MenuSectionId(sectionName);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

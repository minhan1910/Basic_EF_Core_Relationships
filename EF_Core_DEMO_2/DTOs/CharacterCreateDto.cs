namespace EF_Core_DEMO_2.DTOs
{
    public record struct CharacterCreateDto(
        string Name, 
        BackpackCreateDto Backpack,
        List<WeaponCreateDto> Weapons,
        List<FactionCreateDto> Factions);
}

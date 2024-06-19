public class Spell
{
    public int Id { get; set; }
    public double Cooldown { get; set; }
    public string Icon { get; set; }
    public int? ParentId { get; set; }

    public Spell(int id, double cooldown, string icon, int? parentId = null)
    {
        Id = id;
        Cooldown = cooldown;
        Icon = icon;
        ParentId = parentId;
    }
}

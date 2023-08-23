using System.Reflection;

var pl = new CreateTeamPayload
{
    Name = "Hanz",
    Description = "14150 SE 24th St",
    teamMembers = new List<Guid>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() })
};
Console.WriteLine(pl);

var input = new CreateTeamInput(Guid.NewGuid(), 1, pl);

Console.WriteLine(input);

foreach(var x in input.teamMembers) Console.WriteLine(x);


public record CreateTeamPayload
{
    public string Name { get; init; } = "";

    public string? Description { get; init; }

    public List<Guid>? teamMembers { get; init; }

}

public record CreateTeamInput : CreateTeamPayload
{
    public CreateTeamInput(Guid facilityId, int leagueId, CreateTeamPayload payload)
    {
        this.facilityId = facilityId;
        this.leagueId = leagueId;

        var properties = typeof(CreateTeamPayload).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            if (property.CanWrite)
            {
                property.SetValue(this, property.GetValue(payload));
            }
        }
    }
    public Guid facilityId { get; init; }

    public int leagueId { get; init; }

}

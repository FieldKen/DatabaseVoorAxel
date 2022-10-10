using Microsoft.EntityFrameworkCore;

/*Grade ib5 = new Grade()
{
    Name = "Informaticabeheer",
    Year = 5
};

Persoon axel = new Persoon()
{
    Name = "Axel",
    Age = 25,
    Grade = ib5
};

using (ApplicationDbContext ctx = new ApplicationDbContext())
{
    ctx.Personen.Add(axel);
    ctx.Personen.Add(new Persoon
    {
        Name = "Ken",
        Age = 26,
        Grade = ib5
    });

    ctx.SaveChanges();
}*/

using (ApplicationDbContext ctx = new ApplicationDbContext())
{
    foreach (Persoon student in ctx.Personen.Include(s => s.Grade))
    {
        Console.WriteLine($"{student.Name} - {student.Age} - {student.Grade.Year} {student.Grade.Name}");
    }
}

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder barbecue)
    {
        barbecue.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AxelDatabase;Trusted_Connection=True;");
    }

    public DbSet<Persoon> Personen { get; set; }
    public DbSet<Grade> Grades { get; set; }
}

public class Persoon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Grade Grade { get; set; }
}

public class Grade
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public ICollection<Persoon> Personen { get; set; }
}
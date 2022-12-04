using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Superior)
            .WithMany(m => m.Subordinates)
            .HasForeignKey(e => e.SuperiorId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<TaskItem>()
            .HasOne(e => e.AssignedTo)
            .WithMany()
            .HasForeignKey(e => e.AssignedToId);

        modelBuilder.Entity<Manager>().HasData(
            new Manager
            {
                Id = 1,
                Name = "John Doe",
                SuperiorId = 1
            });

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 2,
                Name = "Jane Doe",
                SuperiorId = 1
            },
            new Employee
            {
                Id = 3,
                Name = "Joe Doe",
                SuperiorId = 1
            });
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Title = "Project 1",
                Description = "Project 1 Description",
                ManagerId = 1
            },
            new Project
            {
                Id = 2,
                Title = "Project 2",
                Description = "Project 2 Description",
                ManagerId = 1
            });
        modelBuilder.Entity<TaskItem>().HasData(
            new TaskItem
            {
                Id = 1,
                Title = "Task 1",
                Description = "Task 1 Description",
                ProjectId = 1,
                AssignedToId = 2
            },
            new TaskItem
            {
                Id = 2,
                Title = "Task 2",
                Description = "Task 2 Description",
                ProjectId = 1
            },
            new TaskItem
            {
                Id = 3,
                Title = "Task 3",
                Description = "Task 3 Description",
                ProjectId = 2,
                AssignedToId = 3
            },
            new TaskItem
            {
                Id = 4,
                Title = "Task 4",
                Description = "Task 4 Description",
                ProjectId = 2
            });
    }
}
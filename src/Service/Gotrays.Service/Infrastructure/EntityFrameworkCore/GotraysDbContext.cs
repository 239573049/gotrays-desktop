using Gotrays.Service.Domain.Chat.Aggregates;
using Gotrays.Service.Domain.Users.Aggregates;
using Gotrays.Service.Infrastructure.Helpers;
using System.Reflection;

namespace Gotrays.Service.Infrastructure.EntityFrameworkCore;

public class GotraysDbContext : MasaDbContext<GotraysDbContext>
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Channel> Channels { get; set; } = null!;

    private readonly IConfiguration _configuration;

    public GotraysDbContext(MasaDbContextOptions<GotraysDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(MasaDbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration["ConnectionStrings:DefaultConnection"] ??
                                 throw new InvalidOperationException());
    }

    protected override void OnModelCreatingExecuting(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        ConfigEntities(builder);
        base.OnModelCreatingExecuting(builder);
    }

    private static void ConfigEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(options =>
        {
            options.HasKey(x => x.Id);

            options.HasIndex(x => x.Account).IsUnique();

            options.Property(x => x.Account).HasMaxLength(20).IsRequired();
        });

        modelBuilder.Entity<Channel>(options =>
        {
            options.HasKey(x => x.Id);

            options.HasIndex(x => x.UserId);
            options.HasIndex(x => x.Name);
            options.Property(x => x.Name).HasMaxLength(20).IsRequired();
            options.Property(x => x.Description).HasMaxLength(200);
            options.Property(x => x.Avatar).HasMaxLength(200);
        });

        // 默认角色
        var user = new User(Guid.NewGuid())
        {
            Account = "admin",
            UserName = "admin",
            Avatar = "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg",
            Salt = Guid.NewGuid().ToString("N"),
            Password = "Aa010426.",
            Role = "Admin"
        };

        user.Password = Md5Helper.HashPassword(user.Password, user.Salt);

        modelBuilder.Entity<User>().HasData(user);

        var channel = new Channel(Guid.NewGuid())
        {
            Avatar = "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg",
            Description = "默认频道",
            Name = "默认频道",
            UserId = user.Id
        };

        modelBuilder.Entity<Channel>().HasData(channel);
    }
}
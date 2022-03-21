using Microsoft.EntityFrameworkCore;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Helpers;

public class HogeBlazorDbContext : DbContext
{
    public virtual DbSet<Member> Members { get; set; } = default!;
    public virtual DbSet<User> Users { get; set; } = default!;

    public HogeBlazorDbContext()
        : base()
    {
    }
    public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 論理削除されたレコードを除外する
        modelBuilder.Entity<User>()
            .HasQueryFilter(s => !s.IsDel);
        // レコードのデフォルト値
        modelBuilder.Entity<User>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<User>()
            .Property(b => b.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        // 初期データの投入
        modelBuilder.Entity<User>().HasData(
            new User(
                id: 1,
                name: "管理者",
                email: "admin@hogeblazor",
                role: User.RoleType.Admin
            )
        );
    }
}
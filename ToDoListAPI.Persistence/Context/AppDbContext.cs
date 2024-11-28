using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Common;
using ToDoListAPI.Domain.Entities.Identity;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Persistence.Context
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Task> Tasks { get; set; }

		public DbSet<Grade> Grades { get; set; }
		public DbSet<StudentTask> StudentTasks { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<StudentTask>()
				.HasKey(x => new { x.StudentId, x.TaskId });

			builder.Entity<StudentTask>()
				.HasOne(x => x.Student)
				.WithMany(x => x.StudentTasks)
				.HasForeignKey(x => x.StudentId);

			builder.Entity<StudentTask>()
				.HasOne(y => y.Task)
				.WithMany(y => y.StudentTasks)
				.HasForeignKey(y => y.TaskId);

			builder.Entity<Task>()
			   .HasOne(t => t.Teacher)
			   .WithMany(teacher => teacher.Tasks)
			   .HasForeignKey(t => t.TeacherId)
			   .OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(builder);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseEntity entity)
				{
					switch (entry.State)
					{
						case EntityState.Added:
							entity.CreatedDate = DateTime.UtcNow;
							break;
						case EntityState.Modified:
							entity.UpdatedDate = DateTime.UtcNow;
							break;
					}
				}
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}

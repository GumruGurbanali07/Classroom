using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Identity;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Persistence.Context
{
	public class AppDbContext:IdentityDbContext<AppUser,AppRole, string>
	{
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Task> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Teacher-Student many-many
			builder.Entity<Teacher>()
				.HasMany(x => x.Students)
				.WithMany(x => x.Teachers);
			//Student-Task many-many
			builder.Entity<Student>()
				.HasMany(y => y.Tasks)
				.WithMany(y => y.Students);

			//Teacher-Task
			builder.Entity<Teacher>()
				.HasMany(z => z.Tasks)
				.WithOne(z => z.Teacher)
				.HasForeignKey(z => z.TeacherId);


			base.OnModelCreating(builder);
		}
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var datas
		}
	}
}

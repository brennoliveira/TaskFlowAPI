//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;
//using TaskFlow.Domain.Entities;

//namespace TaskFlow.Infrastructure.Configurations
//{
//    public class TaskItemsConfiguration : IEntityTypeConfiguration<TaskItem>
//    {
//        public void Configure(EntityTypeBuilder<TaskItem> builder)
//        {
//            builder.ToTable("TaskItems");

//            builder.HasKey(t => t.Id);

//            builder.Property(t => t.Title)
//                .IsRequired();

//            builder
//                .HasOne<User>()
//                .WithMany()
//                .HasForeignKey(t => t.UserId)
//                .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}

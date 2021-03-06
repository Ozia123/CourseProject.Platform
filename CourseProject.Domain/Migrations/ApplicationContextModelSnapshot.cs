﻿// <auto-generated />
using CourseProject.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseProject.Domain.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseProject.Domain.Entities.GlossaryItem", b =>
                {
                    b.Property<int>("GlossaryItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("HtmlContent");

                    b.HasKey("GlossaryItemId");

                    b.ToTable("GlossaryItems");
                });

            modelBuilder.Entity("CourseProject.Domain.Entities.Pattern", b =>
                {
                    b.Property<int>("PatternId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GlossaryItemId");

                    b.Property<string>("Match");

                    b.HasKey("PatternId");

                    b.HasIndex("GlossaryItemId");

                    b.ToTable("Patterns");
                });

            modelBuilder.Entity("CourseProject.Domain.Entities.Pattern", b =>
                {
                    b.HasOne("CourseProject.Domain.Entities.GlossaryItem", "GlossaryItem")
                        .WithMany("Patterns")
                        .HasForeignKey("GlossaryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

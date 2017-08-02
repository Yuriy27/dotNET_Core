using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BSA_netCore.Models.EF;

namespace BSAnetCore.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20170802154645_AddedMatches")]
    partial class AddedMatches
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BSA_netCore.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Team");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BSA_netCorenetCore.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Guest");

                    b.Property<string>("Owner");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlackBot.Models;

namespace SlackBot.Migrations
{
    [DbContext(typeof(PreprodStatusContext))]
    partial class PreprodStatusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("SlackBot.Models.Release", b =>
                {
                    b.Property<int>("ReleaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Ended");

                    b.Property<DateTime>("Started");

                    b.Property<string>("Tickets");

                    b.Property<string>("User");

                    b.HasKey("ReleaseId");

                    b.ToTable("Releases");
                });
#pragma warning restore 612, 618
        }
    }
}

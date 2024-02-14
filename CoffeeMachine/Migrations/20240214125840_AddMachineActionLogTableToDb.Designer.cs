﻿// <auto-generated />
using System;
using CoffeeMachine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeMachine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240214125840_AddMachineActionLogTableToDb")]
    partial class AddMachineActionLogTableToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("CoffeeMachine.Models.MachineActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ActionLogs");
                });
#pragma warning restore 612, 618
        }
    }
}

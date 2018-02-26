﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TestExercise.Context;
using TestExercise.Models.OrderModel;

namespace TestExercise.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20180225121858_datetime")]
    partial class datetime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestExercise.Models.OrderModel.Order", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreationTime");

                    b.Property<int>("Manager");

                    b.Property<string>("Note");

                    b.Property<int>("Number");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

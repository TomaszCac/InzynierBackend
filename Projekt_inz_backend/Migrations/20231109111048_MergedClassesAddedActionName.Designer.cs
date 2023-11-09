﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_inz_backend.Data;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    [DbContext(typeof(DndDatabaseContext))]
    [Migration("20231109111048_MergedClassesAddedActionName")]
    partial class MergedClassesAddedActionName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndClassFeature", b =>
                {
                    b.Property<int>("featureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureID"));

                    b.Property<string>("featureDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("featureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByclassID")
                        .HasColumnType("int");

                    b.HasKey("featureID");

                    b.HasIndex("usedByclassID");

                    b.ToTable("customDndClassFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomRaceFeature", b =>
                {
                    b.Property<int>("featureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureID"));

                    b.Property<string>("featureDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("featureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByraceID")
                        .HasColumnType("int");

                    b.HasKey("featureID");

                    b.HasIndex("usedByraceID");

                    b.ToTable("customRaceFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.Property<int>("classID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("classID"));

                    b.Property<string>("armorProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("className")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hitDice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hitPointsAtFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hitPointsAtHigh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("inheritedClassID")
                        .HasColumnType("int");

                    b.Property<string>("multiclassReq")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("savingThrows")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tableData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tableHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("toolsProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weaponProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("classID");

                    b.HasIndex("owneruserID");

                    b.ToTable("dndClasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.Property<int>("EnemyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyID"));

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armorClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("charisma")
                        .HasColumnType("int");

                    b.Property<int>("constitution")
                        .HasColumnType("int");

                    b.Property<string>("dangerLvl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dexterity")
                        .HasColumnType("int");

                    b.Property<string>("health")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("immunes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("inteligence")
                        .HasColumnType("int");

                    b.Property<string>("languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("proficencyBonus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resistances")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("savingThrows")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("strength")
                        .HasColumnType("int");

                    b.Property<string>("vulnerabilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("wisdom")
                        .HasColumnType("int");

                    b.HasKey("EnemyID");

                    b.HasIndex("owneruserID");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.EnemyActionEconomy", b =>
                {
                    b.Property<int>("actionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("actionID"));

                    b.Property<string>("actionDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByEnemyID")
                        .HasColumnType("int");

                    b.HasKey("actionID");

                    b.HasIndex("usedByEnemyID");

                    b.ToTable("enemyActions");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Item", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemID"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemID");

                    b.HasIndex("owneruserID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.Property<int>("raceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raceID"));

                    b.Property<int?>("inheritedRaceID")
                        .HasColumnType("int");

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("raceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tableData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tableHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("raceID");

                    b.HasIndex("owneruserID");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.RaceFeature", b =>
                {
                    b.Property<int>("featureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureID"));

                    b.Property<string>("abilityScoreIncrease")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceID")
                        .HasColumnType("int");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("featureID");

                    b.HasIndex("raceID")
                        .IsUnique();

                    b.ToTable("raceFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.Property<int>("spellID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("spellID"));

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("spellAHL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellCasting")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellComponents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("spellLevel")
                        .HasColumnType("int");

                    b.Property<string>("spellName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellSchool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("spellID");

                    b.HasIndex("owneruserID");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForClass", b =>
                {
                    b.Property<int>("spellID")
                        .HasColumnType("int");

                    b.Property<int>("classID")
                        .HasColumnType("int");

                    b.HasKey("spellID", "classID");

                    b.HasIndex("classID");

                    b.ToTable("spellsForClasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndClassFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "usedBy")
                        .WithMany("customFeatures")
                        .HasForeignKey("usedByclassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomRaceFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Race", "usedBy")
                        .WithMany("customFeatures")
                        .HasForeignKey("usedByraceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("dndClasses")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("enemies")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.EnemyActionEconomy", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Enemy", "usedBy")
                        .WithMany("actionEcononomy")
                        .HasForeignKey("usedByEnemyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Item", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("items")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("races")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.RaceFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Race", "usedBy")
                        .WithOne("feature")
                        .HasForeignKey("Projekt_inz_backend.Models.RaceFeature", "raceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("spells")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForClass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "usingClass")
                        .WithMany("usesSpells")
                        .HasForeignKey("classID")
                        .IsRequired();

                    b.HasOne("Projekt_inz_backend.Models.Spell", "spellUsed")
                        .WithMany("usedBy")
                        .HasForeignKey("spellID")
                        .IsRequired();

                    b.Navigation("spellUsed");

                    b.Navigation("usingClass");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.Navigation("customFeatures");

                    b.Navigation("usesSpells");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.Navigation("actionEcononomy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.Navigation("customFeatures");

                    b.Navigation("feature")
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.User", b =>
                {
                    b.Navigation("dndClasses");

                    b.Navigation("enemies");

                    b.Navigation("items");

                    b.Navigation("races");

                    b.Navigation("spells");
                });
#pragma warning restore 612, 618
        }
    }
}

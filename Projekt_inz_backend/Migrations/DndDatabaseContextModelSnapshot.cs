﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_inz_backend.Data;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    [DbContext(typeof(DndDatabaseContext))]
    partial class DndDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_inz_backend.Models.Character", b =>
                {
                    b.Property<int>("characterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("characterId"));

                    b.Property<int?>("DndClassclassId")
                        .HasColumnType("int");

                    b.Property<string>("characterAlignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterArmorClass")
                        .HasColumnType("int");

                    b.Property<string>("characterBackground")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("characterBonds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterCharisma")
                        .HasColumnType("int");

                    b.Property<int>("characterConstitution")
                        .HasColumnType("int");

                    b.Property<int>("characterDeathFail")
                        .HasColumnType("int");

                    b.Property<int>("characterDeathSuccess")
                        .HasColumnType("int");

                    b.Property<int>("characterDexterity")
                        .HasColumnType("int");

                    b.Property<int>("characterExperience")
                        .HasColumnType("int");

                    b.Property<string>("characterFlaws")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterHealthCurrent")
                        .HasColumnType("int");

                    b.Property<int>("characterHealthMax")
                        .HasColumnType("int");

                    b.Property<int>("characterHealthTemp")
                        .HasColumnType("int");

                    b.Property<string>("characterHitDice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("characterHitDiceTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("characterIdeals")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterInitiative")
                        .HasColumnType("int");

                    b.Property<int>("characterInspiration")
                        .HasColumnType("int");

                    b.Property<int>("characterInteligence")
                        .HasColumnType("int");

                    b.Property<int>("characterLevel")
                        .HasColumnType("int");

                    b.Property<string>("characterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("characterPersonalityTraits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterProficencyBonus")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowCharisma")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowConstitution")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowDexterity")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowInteligence")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowStrength")
                        .HasColumnType("int");

                    b.Property<int>("characterSavingThrowWisdom")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillAcrobatics")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillAnimalHandling")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillArcana")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillAthletics")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillDeception")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillHistory")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillInsight")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillIntimidation")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillInvestigation")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillMedicine")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillNature")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillPerception")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillPerformance")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillPersuation")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillReligion")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillSleightOfHand")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillStealth")
                        .HasColumnType("int");

                    b.Property<int>("characterSkillSurvival")
                        .HasColumnType("int");

                    b.Property<string>("characterSkills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("characterSpeed")
                        .HasColumnType("int");

                    b.Property<int>("characterStrength")
                        .HasColumnType("int");

                    b.Property<int>("characterWisdom")
                        .HasColumnType("int");

                    b.Property<int>("owneruserID")
                        .HasColumnType("int");

                    b.Property<int?>("raceId")
                        .HasColumnType("int");

                    b.HasKey("characterId");

                    b.HasIndex("DndClassclassId");

                    b.HasIndex("owneruserID");

                    b.HasIndex("raceId");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndClassFeature", b =>
                {
                    b.Property<int>("featureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureId"));

                    b.Property<string>("featureDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("featureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByclassId")
                        .HasColumnType("int");

                    b.HasKey("featureId");

                    b.HasIndex("usedByclassId");

                    b.ToTable("customDndClassFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndSubclassFeature", b =>
                {
                    b.Property<int>("featureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureId"));

                    b.Property<string>("featureDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("featureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedBysubclassId")
                        .HasColumnType("int");

                    b.HasKey("featureId");

                    b.HasIndex("usedBysubclassId");

                    b.ToTable("customDndSubclassFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomRaceFeature", b =>
                {
                    b.Property<int>("featureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("featureId"));

                    b.Property<string>("featureDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("featureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByraceId")
                        .HasColumnType("int");

                    b.HasKey("featureId");

                    b.HasIndex("usedByraceId");

                    b.ToTable("customRaceFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.Property<int>("classId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("classId"));

                    b.Property<string>("classArmorProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classEquipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classHitDice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classHitPointsAtFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classHitPointsAtHigh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classMulticlassReq")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("className")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classSavingThrows")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classSkills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classTableData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classTableHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classToolsProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classWeaponProficency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("inheritedClassID")
                        .HasColumnType("int");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("spellTableData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spellTableHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("classId");

                    b.HasIndex("owneruserID");

                    b.ToTable("dndClasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndSubclass", b =>
                {
                    b.Property<int>("subclassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subclassId"));

                    b.Property<int>("inheritedClassclassId")
                        .HasColumnType("int");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("subclassDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subclassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("subclassId");

                    b.HasIndex("inheritedClassclassId");

                    b.HasIndex("owneruserID");

                    b.ToTable("dndSubclasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.Property<int>("enemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("enemyId"));

                    b.Property<string>("enemyArmorClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enemyCharisma")
                        .HasColumnType("int");

                    b.Property<int>("enemyConstitution")
                        .HasColumnType("int");

                    b.Property<string>("enemyDangerLvl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enemyDexterity")
                        .HasColumnType("int");

                    b.Property<string>("enemyHealth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemyImmunes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enemyInteligence")
                        .HasColumnType("int");

                    b.Property<string>("enemyLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemyProficencyBonus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemyRace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemyResistances")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemySavingThrows")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemySenses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemySize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemySkills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enemySpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enemyStrength")
                        .HasColumnType("int");

                    b.Property<string>("enemyVulnerabilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enemyWisdom")
                        .HasColumnType("int");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("int");

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("enemyId");

                    b.HasIndex("owneruserID");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.EnemyActionEconomy", b =>
                {
                    b.Property<int>("actionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("actionId"));

                    b.Property<string>("actionDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedByenemyId")
                        .HasColumnType("int");

                    b.HasKey("actionId");

                    b.HasIndex("usedByenemyId");

                    b.ToTable("enemyActions");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<string>("itemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemRarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemWeight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("int");

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("itemId");

                    b.HasIndex("owneruserID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.Property<int>("raceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raceId"));

                    b.Property<int?>("inheritedRaceID")
                        .HasColumnType("int");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("int");

                    b.Property<string>("raceAbilityScoreIncrease")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceAge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceAlignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceTableData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raceTableHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("raceId");

                    b.HasIndex("owneruserID");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.Property<int>("spellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("spellId"));

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("owneruserID")
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

                    b.Property<int>("upvotes")
                        .HasColumnType("int");

                    b.HasKey("spellId");

                    b.HasIndex("owneruserID");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForClass", b =>
                {
                    b.Property<int>("spellId")
                        .HasColumnType("int");

                    b.Property<int>("classId")
                        .HasColumnType("int");

                    b.HasKey("spellId", "classId");

                    b.HasIndex("classId");

                    b.ToTable("spellsForClasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForSubclass", b =>
                {
                    b.Property<int>("spellId")
                        .HasColumnType("int");

                    b.Property<int>("subclassId")
                        .HasColumnType("int");

                    b.HasKey("spellId", "subclassId");

                    b.HasIndex("subclassId");

                    b.ToTable("spellsForSubclasses");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Upvote", b =>
                {
                    b.Property<int>("upvoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("upvoteId"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("upvoteId");

                    b.ToTable("upvotes");
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

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Character", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "DndClass")
                        .WithMany("characters")
                        .HasForeignKey("DndClassclassId");

                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("characters")
                        .HasForeignKey("owneruserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_inz_backend.Models.Race", "race")
                        .WithMany("characters")
                        .HasForeignKey("raceId");

                    b.Navigation("DndClass");

                    b.Navigation("owner");

                    b.Navigation("race");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndClassFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "usedBy")
                        .WithMany("customFeatures")
                        .HasForeignKey("usedByclassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomDndSubclassFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndSubclass", "usedBy")
                        .WithMany()
                        .HasForeignKey("usedBysubclassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.CustomRaceFeature", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Race", "usedBy")
                        .WithMany("customFeatures")
                        .HasForeignKey("usedByraceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("dndClasses")
                        .HasForeignKey("owneruserID");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndSubclass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "inheritedClass")
                        .WithMany("dndSubclasses")
                        .HasForeignKey("inheritedClassclassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("dndSubclasss")
                        .HasForeignKey("owneruserID");

                    b.Navigation("inheritedClass");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("enemies")
                        .HasForeignKey("owneruserID");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.EnemyActionEconomy", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Enemy", "usedBy")
                        .WithMany("actionEcononomy")
                        .HasForeignKey("usedByenemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usedBy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Item", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("items")
                        .HasForeignKey("owneruserID");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("races")
                        .HasForeignKey("owneruserID");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.User", "owner")
                        .WithMany("spells")
                        .HasForeignKey("owneruserID");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForClass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.DndClass", "usingClass")
                        .WithMany("usesSpells")
                        .HasForeignKey("classId")
                        .IsRequired();

                    b.HasOne("Projekt_inz_backend.Models.Spell", "spellUsed")
                        .WithMany("usedByClass")
                        .HasForeignKey("spellId")
                        .IsRequired();

                    b.Navigation("spellUsed");

                    b.Navigation("usingClass");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.SpellForSubclass", b =>
                {
                    b.HasOne("Projekt_inz_backend.Models.Spell", "spellUsed")
                        .WithMany("usedBySubclass")
                        .HasForeignKey("spellId")
                        .IsRequired();

                    b.HasOne("Projekt_inz_backend.Models.DndSubclass", "usingSubclass")
                        .WithMany("usesSpells")
                        .HasForeignKey("subclassId")
                        .IsRequired();

                    b.Navigation("spellUsed");

                    b.Navigation("usingSubclass");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndClass", b =>
                {
                    b.Navigation("characters");

                    b.Navigation("customFeatures");

                    b.Navigation("dndSubclasses");

                    b.Navigation("usesSpells");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.DndSubclass", b =>
                {
                    b.Navigation("usesSpells");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Enemy", b =>
                {
                    b.Navigation("actionEcononomy");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Race", b =>
                {
                    b.Navigation("characters");

                    b.Navigation("customFeatures");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.Spell", b =>
                {
                    b.Navigation("usedByClass");

                    b.Navigation("usedBySubclass");
                });

            modelBuilder.Entity("Projekt_inz_backend.Models.User", b =>
                {
                    b.Navigation("characters");

                    b.Navigation("dndClasses");

                    b.Navigation("dndSubclasss");

                    b.Navigation("enemies");

                    b.Navigation("items");

                    b.Navigation("races");

                    b.Navigation("spells");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CoinLeopard.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    [DbContext(typeof(CoinLeopardContext))]
    partial class CoinLeopardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoinLeopard.DB.Entities.AnalysisInterval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("High")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Inclination")
                        .HasColumnType("numeric");

                    b.Property<decimal>("InclinationDirectionFactor")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LastMarketPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Symbol");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.AssetValueEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("MonthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("AssetValueEntry");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.ContractTrendEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("EstimatedSettlePrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("IndexPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("MarkPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Symbol");

                    b.ToTable("ContractTrends");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoCurrency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("CryptoCurrencies");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoPair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Left")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("Right")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Left");

                    b.HasIndex("Right");

                    b.ToTable("CryptoPairs");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoPairTrend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CryptoPairId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TrendValue")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CryptoPairId");

                    b.ToTable("CryptoPairTrends");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.FuturesPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnalysisSnapshot")
                        .HasColumnType("text");

                    b.Property<string>("ClientOrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Closed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("CryptoPairId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("OrderSide")
                        .HasColumnType("integer");

                    b.Property<decimal?>("PNL")
                        .HasColumnType("numeric");

                    b.Property<int>("PositionSide")
                        .HasColumnType("integer");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<long?>("StopLossOrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("StopPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("TakeProfitOrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TakeProfitPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CryptoPairId");

                    b.HasIndex("Symbol");

                    b.ToTable("FuturesPositions");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.FuturesSymbol", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<int>("BaseCrypto")
                        .HasColumnType("integer");

                    b.HasKey("Symbol");

                    b.ToTable("FuturesSymbols");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.AnalysisInterval", b =>
                {
                    b.HasOne("CoinLeopard.DB.Entities.FuturesSymbol", "FuturesSymbol")
                        .WithMany("Analyses")
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuturesSymbol");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.ContractTrendEntry", b =>
                {
                    b.HasOne("CoinLeopard.DB.Entities.FuturesSymbol", "FuturesSymbol")
                        .WithMany("TrendEntries")
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuturesSymbol");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoPair", b =>
                {
                    b.HasOne("CoinLeopard.DB.Entities.CryptoCurrency", "LeftCurrency")
                        .WithMany("LeftPairs")
                        .HasForeignKey("Left")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoinLeopard.DB.Entities.CryptoCurrency", "RightCurrency")
                        .WithMany("RightPairs")
                        .HasForeignKey("Right")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeftCurrency");

                    b.Navigation("RightCurrency");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoPairTrend", b =>
                {
                    b.HasOne("CoinLeopard.DB.Entities.CryptoPair", "Pair")
                        .WithMany("Trends")
                        .HasForeignKey("CryptoPairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pair");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.FuturesPosition", b =>
                {
                    b.HasOne("CoinLeopard.DB.Entities.CryptoPair", null)
                        .WithMany("Positions")
                        .HasForeignKey("CryptoPairId");

                    b.HasOne("CoinLeopard.DB.Entities.FuturesSymbol", "FuturesSymbol")
                        .WithMany("Positions")
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuturesSymbol");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoCurrency", b =>
                {
                    b.Navigation("LeftPairs");

                    b.Navigation("RightPairs");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.CryptoPair", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("Trends");
                });

            modelBuilder.Entity("CoinLeopard.DB.Entities.FuturesSymbol", b =>
                {
                    b.Navigation("Analyses");

                    b.Navigation("Positions");

                    b.Navigation("TrendEntries");
                });
#pragma warning restore 612, 618
        }
    }
}

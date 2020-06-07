using Cw13.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cw13.Models
{
    public class BakeryDbContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }

        public BakeryDbContext()
        {

        }

        public BakeryDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new KlientEfConfiguration());

            modelBuilder.ApplyConfiguration(new PracownikEfConfiguration());

            modelBuilder.ApplyConfiguration(new WyrobCukierniczyEfConfiguration());

            modelBuilder.ApplyConfiguration(new ZamowienieEfConfiguration());

            modelBuilder.ApplyConfiguration(new Zamowienie_WyrobCukierniczyEfConfiguration());

            DumpSeedDatabase(modelBuilder);
        }

        private void DumpSeedDatabase(ModelBuilder modelBuilder)
        {
            var clients = new List<Klient>();
            clients.Add(new Klient { IdKlient = 1, Imie = "Jan", Nazwisko = "Kowalski" });
            clients.Add(new Klient { IdKlient = 2, Imie = "Kacper", Nazwisko = "Nowak" });
            modelBuilder.Entity<Klient>().HasData(clients);

            var employees = new List<Pracownik>();
            employees.Add(new Pracownik { IdPracownik = 1, Imie = "Zygmunt", Nazwisko = "Piekarz"});
            employees.Add(new Pracownik { IdPracownik = 2, Imie = "Adam", Nazwisko = "Cukiernik"});
            modelBuilder.Entity<Pracownik>().HasData(employees);

            var orders = new List<Zamowienie>();
            orders.Add(new Zamowienie { IdZamowienia = 1, DataPrzyjecia = DateTime.Parse("2020-01-01"), DataRealizacji = DateTime.Parse("2020-01-03"), IdKlient = 1, IdPracownik = 1 });
            orders.Add(new Zamowienie { IdZamowienia = 2, DataPrzyjecia = DateTime.Parse("2020-06-06"), IdKlient = 2, IdPracownik = 2, Uwagi = "Dużo kremu" });
            modelBuilder.Entity<Zamowienie>().HasData(orders);

            var products = new List<WyrobCukierniczy>();
            products.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 1, Nazwa = "Ciasto z galaretką", CenaZaSzt = 20.50f, Typ="Ciasto"});
            products.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 2, Nazwa = "Kremówka papieska", CenaZaSzt = 3.20f, Typ="Ciastko"});
            modelBuilder.Entity<WyrobCukierniczy>().HasData(products);

            var productsOrders = new List<Zamowienie_WyrobCukierniczy>();
            productsOrders.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 1, IdZamowienia = 1, Ilosc = 2, Uwagi = "Pokroić na kawałki oba torty" });
            productsOrders.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 2, IdZamowienia = 1, Ilosc = 10 });
            productsOrders.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 2, IdZamowienia = 2, Ilosc = 20, Uwagi = "Dać dużo kremu" });
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(productsOrders);
        }
    }
}

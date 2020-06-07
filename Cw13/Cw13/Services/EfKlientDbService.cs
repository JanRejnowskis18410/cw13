using Cw13.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cw13.Services
{
    public class EfKlientDbService : IKlientDbService
    {
        private readonly BakeryDbContext _context;
        public EfKlientDbService(BakeryDbContext context)
        {
            _context = context;
        }

        public bool CheckIfClientExists(string surname)
        {
            return _context.Klient.Any(k => k.Nazwisko.Equals(surname));
        }

        public ICollection<ZamowienieKlientWyrobCukierniczy> GetClientOrders(string surname)
        {
            var joinList = _context.Zamowienie.Join(_context.Klient, z => z.IdKlient, k => k.IdKlient, (z, k) => new { z, k }).Where(e => e.k.Nazwisko.Equals(surname)).ToList();
            var resultList = new List<ZamowienieKlientWyrobCukierniczy>();

            foreach (var element in joinList)
            {
                int idZamowienia = element.z.IdZamowienia;
                int idKlienta = element.k.IdKlient;
                string uwagi = element.z.Uwagi;
                DateTime dataPrzyjecia = element.z.DataPrzyjecia;
                Nullable<DateTime> dataRealizacji = element.z.DataRealizacji;

                var zamowienieWyrobCukierniczy = _context.Zamowienie_WyrobCukierniczy.First(zwc => zwc.IdZamowienia == idZamowienia);
                var productsList = _context.WyrobCukierniczy.Where(wc => wc.IdWyrobuCukierniczego == zamowienieWyrobCukierniczy.IdWyrobuCukierniczego).ToList();

                var result = new ZamowienieKlientWyrobCukierniczy { IdKlienta = idKlienta, IdZamowienia = idZamowienia, Uwagi = uwagi, DataPrzyjecia = dataPrzyjecia, DataRealizacji = dataRealizacji, WyrobyCukiernicze = productsList };
                resultList.Add(result);
            }

            return resultList;
        }

        public ICollection<ZamowienieKlientWyrobCukierniczy> GetClientsOrders()
        {
            var joinList = _context.Zamowienie.Join(_context.Klient, z => z.IdKlient, k => k.IdKlient, (z, k) => new { z, k }).ToList();
            var resultList = new List<ZamowienieKlientWyrobCukierniczy>();

            foreach (var element in joinList)
            {
                int idZamowienia = element.z.IdZamowienia;
                int idKlienta = element.k.IdKlient;
                string uwagi = element.z.Uwagi;
                DateTime dataPrzyjecia = element.z.DataPrzyjecia;
                Nullable<DateTime> dataRealizacji = element.z.DataRealizacji;

                var zamowienieWyrobCukierniczy = _context.Zamowienie_WyrobCukierniczy.First(zwc => zwc.IdZamowienia == idZamowienia);
                var productsList = _context.WyrobCukierniczy.Where(wc => wc.IdWyrobuCukierniczego == zamowienieWyrobCukierniczy.IdWyrobuCukierniczego).ToList();

                var result = new ZamowienieKlientWyrobCukierniczy { IdKlienta = idKlienta, IdZamowienia = idZamowienia, Uwagi = uwagi, DataPrzyjecia = dataPrzyjecia, DataRealizacji = dataRealizacji, WyrobyCukiernicze = productsList};
                resultList.Add(result);
            }

            return resultList;
        }
    }
}

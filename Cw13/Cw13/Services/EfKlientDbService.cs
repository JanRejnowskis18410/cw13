using Cw13.DTOs.Requests;
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

        public void AddNewOrder(CreateNewOrderRequest request, int clientId)
        {
            int zamowienieId = _context.Zamowienie.Max(z => z.IdZamowienia) + 1;
            _context.Zamowienie.Add(new Zamowienie { DataPrzyjecia = request.dataPrzyjecia, Uwagi = request.uwagi, IdKlient = clientId, IdPracownik = request.idPracownika });
            for (int i = 0; i < request.wyroby.Length; i++)
            {
                int idWyrobu = _context.WyrobCukierniczy.Where(wc => wc.Nazwa.Equals(request.wyroby[i].wyrob))
                                                        .Select(wc => wc.IdWyrobuCukierniczego)
                                                        .SingleOrDefault();

                _context.Zamowienie_WyrobCukierniczy.Add(new Zamowienie_WyrobCukierniczy {IdWyrobuCukierniczego = idWyrobu, IdZamowienia = zamowienieId, Uwagi = request.wyroby[i].uwagi, Ilosc = request.wyroby[i].ilosc});
            }
            _context.SaveChanges();
        }

        public bool CheckIfClientExists(string surname)
        {
            return _context.Klient.Any(k => k.Nazwisko.Equals(surname));
        }

        public bool CheckIfClientExists(int id)
        {
            return _context.Klient.Any(k => k.IdKlient == id);
        }

        public bool CheckIfEmployeeExists(int id)
        {
            return _context.Pracownik.Any(p => p.IdPracownik == id);
        }

        public string CheckIfProductsExistst(CreateNewOrderRequest request)
        {
            string result = null;
            var wyroby = request.wyroby;
            var flag = true;
            for(int i = 0; i < wyroby.Length && flag; i++)
            {
                if (!_context.WyrobCukierniczy.Any(w => w.Nazwa.Equals(wyroby[i].wyrob)))
                {
                    result = wyroby[i].wyrob;
                    flag = false;
                }
            }
            return result;
        }

        public ICollection<OrderInfo> GetClientOrders(string surname)
        {
            var joinList = _context.Zamowienie.Join(_context.Klient, z => z.IdKlient, k => k.IdKlient, (z, k) => new { z, k }).Where(e => e.k.Nazwisko.Equals(surname)).ToList();
            var resultList = new List<OrderInfo>();

            foreach (var element in joinList)
            {
                int idZamowienia = element.z.IdZamowienia;
                int idKlienta = element.k.IdKlient;
                string uwagi = element.z.Uwagi;
                DateTime dataPrzyjecia = element.z.DataPrzyjecia;
                Nullable<DateTime> dataRealizacji = element.z.DataRealizacji;

                var zamowienieWyrobCukierniczy = _context.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zwc => zwc.IdWyrobuCukierniczego, wc => wc.IdWyrobuCukierniczego, (zwc, wc) => new { zwc, wc})
                                                 .Where(pivot => pivot.zwc.IdZamowienia == idZamowienia).ToList();
                var productsList = new List<WyrobCukierniczy>();
                foreach (var zwc in zamowienieWyrobCukierniczy)
                {
                    var product = _context.WyrobCukierniczy.First(wc => wc.IdWyrobuCukierniczego == zwc.wc.IdWyrobuCukierniczego);
                    productsList.Add(product);
                }
                var productsInfo = new List<ProductInfo>();
                foreach (var product in productsList)
                {
                    var newInfo = new ProductInfo { Nazwa = product.Nazwa, CenaZaSzt = product.CenaZaSzt, Typ = product.Typ };
                    productsInfo.Add(newInfo);
                }
                var result = new OrderInfo { IdKlienta = idKlienta, IdZamowienia = idZamowienia, Uwagi = uwagi, DataPrzyjecia = dataPrzyjecia, DataRealizacji = dataRealizacji, WyrobyCukiernicze = productsInfo };
                resultList.Add(result);
            }

            return resultList;
        }

        public ICollection<OrderInfo> GetClientsOrders()
        {
            var joinList = _context.Zamowienie.Join(_context.Klient, z => z.IdKlient, k => k.IdKlient, (z, k) => new { z, k }).ToList();
            var resultList = new List<OrderInfo>();

            foreach (var element in joinList)
            {
                int idZamowienia = element.z.IdZamowienia;
                int idKlienta = element.k.IdKlient;
                string uwagi = element.z.Uwagi;
                DateTime dataPrzyjecia = element.z.DataPrzyjecia;
                Nullable<DateTime> dataRealizacji = element.z.DataRealizacji;

                var zamowienieWyrobCukierniczy = _context.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zwc => zwc.IdWyrobuCukierniczego, wc => wc.IdWyrobuCukierniczego, (zwc, wc) => new { zwc, wc })
                                                 .Where(pivot => pivot.zwc.IdZamowienia == idZamowienia).ToList();
                var productsList = new List<WyrobCukierniczy>();
                foreach (var zwc in zamowienieWyrobCukierniczy)
                {
                    var product = _context.WyrobCukierniczy.First(wc => wc.IdWyrobuCukierniczego == zwc.wc.IdWyrobuCukierniczego);
                    productsList.Add(product);
                }
                var productsInfo = new List<ProductInfo>();
                foreach(var product in productsList)
                {
                    var newInfo = new ProductInfo { Nazwa = product.Nazwa, CenaZaSzt = product.CenaZaSzt, Typ = product.Typ};
                    productsInfo.Add(newInfo);
                }
                var result = new OrderInfo { IdKlienta = idKlienta, IdZamowienia = idZamowienia, Uwagi = uwagi, DataPrzyjecia = dataPrzyjecia, DataRealizacji = dataRealizacji, WyrobyCukiernicze = productsInfo};
                resultList.Add(result);
            }

            return resultList;
        }
    }
}

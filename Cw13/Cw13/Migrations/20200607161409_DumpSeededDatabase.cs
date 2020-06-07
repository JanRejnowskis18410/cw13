using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw13.Migrations
{
    public partial class DumpSeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klient",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Kacper", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Zygmunt", "Piekarz" },
                    { 2, "Adam", "Cukiernik" }
                });

            migrationBuilder.InsertData(
                table: "WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 20.5f, "Ciasto z galaretką", "Ciasto" },
                    { 2, 3.2f, "Kremówka papieska", "Ciastko" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 2, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, "Dużo kremu" });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 1, 1, 2, "Pokroić na kawałki oba torty" });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 1, 2, 10, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 2, 2, 20, "Dać dużo kremu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 2);
        }
    }
}

using Candid.Models;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Candid.Utilities
{
    public static class AddressExtensions
    {
        public async static Task<Int32> GetExistingOrCreatedId(Address address, AppDbContext _context)
        {
            var addr = await _context.Addresses.FirstOrDefaultAsync(a => a.Street == address.Street && a.PostalCode == address.PostalCode && a.City == address.City && a.State == address.State);

            if (addr == null)
            {
                await _context.AddAsync(address);

                // Get lat, lng coords
                List<Decimal> Coords = await GetLocation($"{address.Street} {address.City}, {address.State} {address.PostalCode}");

                address.Lat = Coords[0];
                address.Lng = Coords[1];

                await _context.SaveChangesAsync();
                return address.AddressId;
            }

            return addr.AddressId;
        }

        public static async Task<Address> GetAddressById(Int32 AddressId, AppDbContext _context)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == AddressId);
        }

        public async static Task<List<Decimal>> GetLocation(String Address)
        {
            var KEY = "";
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(Address), KEY);

            XDocument xmlDocument;

            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(requestUri);
                var content = await request.Content.ReadAsStringAsync();
                xmlDocument = XDocument.Parse(content);
            }

            XElement result = xmlDocument.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            String lat = locationElement.Element("lat").Value;
            String lng = locationElement.Element("lng").Value;

            Decimal Lat = Decimal.Parse(lat);
            Decimal Lng = Decimal.Parse(lng);

            return new List<Decimal> { Lat, Lng };
        }
    }
}
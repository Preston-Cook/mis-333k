using Candid.Models;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Candid.Utilities
{
    public static class MiscExtensions
    {
        public static String GenerateCode()
        {
            String Code = "";

            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                Code += $"{rnd.Next(0, 10)}";
            }

            Console.WriteLine($"{Code} <------");

            return "";
        }
    }
}
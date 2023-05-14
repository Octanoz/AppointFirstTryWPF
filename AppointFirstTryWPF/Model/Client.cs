using AppointFirstTryWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointFirstTryWPF.Model
{
    public class Client
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Consults2023 { get; set; }
        public Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public ZodiacSigns Zodiac { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public string IsActive { get; set; }
        public Archive Archive { get; set; }
    
    
        public enum ZodiacSigns
        {
            Ram = 0,
            Stier = 1,
            Tweelingen = 2,
            Kreeft = 3,
            Leeuw = 4,
            Maagd = 5,
            Weegschaal = 6,
            Schorpioen = 7,
            Boogschutter = 8,
            Steenbok = 9,
            Waterman = 10,
            Vissen = 11
        }
    }

        public enum Gender : int
        {
            Man = 0,
            Vrouw = 1
        }

        //Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces

        public enum Archive : int
        {
            Geen = 0,
            Een,
            Twee,
            Drie,
            Vier,
            Vijf,
            Zes,
            Zeven,
            Acht,
            Negen,
            Tien,
            Elf,
            Twaalf,
            Dertien,
            Veertien,
            Vijftien
        }
    }
    public static class ZodiacSignsExtensions
    {
        private static readonly string[] symbols = new string[]
        {
        "♈", "♉", "♊", "♋", "♌", "♍", "♎", "♏", "♐", "♑", "♒", "♓"
        };

        public static string Symbol(this Client.ZodiacSigns sign)
        {
            return symbols[(int)sign];
        }
    }

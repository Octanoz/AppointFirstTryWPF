using AppointFirstTryWPF.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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
        public string ZodiacSymbol
        {
            get { return GetZodiacSymbol(Zodiac); }
        }   
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public Active Active { get; set; }
        public bool IsActive
        {
            get
            {
                return Active == 0;
            }
        }
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

        private static string GetZodiacSymbol(ZodiacSigns sign)
        {
            switch (sign)
            {
                case ZodiacSigns.Ram:
                    return "♈";
                case ZodiacSigns.Stier: 
                    return "♉";
                case ZodiacSigns.Tweelingen: 
                    return "♊";
                case ZodiacSigns.Kreeft: 
                    return "♋";
                case ZodiacSigns.Leeuw: 
                    return "♌";
                case ZodiacSigns.Maagd: 
                    return "♍";
                case ZodiacSigns.Weegschaal: 
                    return "♎";
                case ZodiacSigns.Schorpioen: 
                    return "♏";
                case ZodiacSigns.Boogschutter:
                    return "♐";
                case ZodiacSigns.Steenbok: 
                    return "♑";
                case ZodiacSigns.Waterman: 
                    return "♒";
                case ZodiacSigns.Vissen: 
                    return "♓";
                default: 
                    return string.Empty;
            }
        }
    }

        public enum Gender : int
        {
            Man = 0,
            Vrouw = 1
        }

    public enum Active
    {
        Actief = 0,
        Non_Actief = 1
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


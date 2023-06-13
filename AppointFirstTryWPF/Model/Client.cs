using System;

namespace AppointFirstTryWPF.Model
{
    public class Client
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string ZodiacSymbol
        {
            get { return GetZodiacSign(BirthDate); }
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

        public static string GetZodiacSign(DateTime dateOfBirth)
        {
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;

            if (month == 12 && day >= 22 || month == 1 && day <= 19)
                return "♑";
            if (month == 1 && day >= 20 || month == 2 && day <= 18)
                return "♒";
            if (month == 2 && day >= 19 || month == 3 && day <= 20)
                return "♓";
            if (month == 3 && day >= 21 || month == 4 && day <= 19)
                return "♈";
            if (month == 4 && day >= 20 || month == 5 && day <= 20)
                return "♉";
            if (month == 5 && day >= 21 || month == 6 && day <= 20)
                return "♊";
            if (month == 6 && day >= 21 || month == 7 && day <= 22)
                return "♋";
            if (month == 7 && day >= 23 || month == 8 && day <= 22)
                return "♌";
            if (month == 8 && day >= 23 || month == 9 && day <= 22)
                return "♍";
            if (month == 9 && day >= 23 || month == 10 && day <= 22)
                return "♎";
            if (month == 10 && day >= 23 || month == 11 && day <= 21)
                return "♏";
            if (month == 11 && day >= 22 || month == 12 && day <= 21)
                return "♐";

            throw new ArgumentException("Invalid date of birth");
        }

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   FirstName == client.FirstName &&
                   LastName == client.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }

    #region Enums
    public enum Gender
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

    public enum Archive
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
    #endregion

}


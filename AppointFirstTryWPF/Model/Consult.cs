﻿using System;

namespace AppointFirstTryWPF.Model
{
    internal class Consult
    {
            public DateOnly Consult_Date { get; set; }
            public TimeOnly Time_Slot { get; set; }
            public int Client_Id { get; set; }
            public Status Status { get; set; }
    }

    enum Status
    {
        Geboekt = 1,
        Afgerond
    }
}

using System;

namespace Dateing.extinatino
{
    public static class DateTimeExtention
    {
        public static int calcAge(this DateTime age)
        {
            var today = DateTime.Today;
            var ag=today.Year-age.Year;
            if (age.Date > today.AddYears(-ag)) --ag;
            return ag;
        }
    }
}

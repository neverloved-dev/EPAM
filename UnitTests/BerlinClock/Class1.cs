using System;

namespace BerlinClockClass
{
    public class BerlinClock
    {
        public  string GetBerlinClock(int hour, int minute, int second)
        {
            if (hour < 0 || hour > 24 || minute < 0 || minute > 59 || second < 0 || second > 59)
            {
                throw new ArgumentException("Invalid input: hour, minute, or second out of range.");
            }

            // Calculate top yellow lamp (blinks on/off every two seconds)
            char topYellow = second % 2 == 0 ? 'Y' : 'O';

            // Calculate hours
            string topHours = hour >= 5 ? "RROO" : "OOOO"; // First row for 5 hours, second row for 1 hour
            string bottomHours = new string('R', hour % 5) + new string('O', 4 - hour % 5);

            // Calculate minutes
            string topMinutes = "";
            for (int i = 1; i <= 11; i++)
            {
                if (i <= minute / 5)
                {
                    if (i % 3 == 0)
                    {
                        topMinutes += 'R';
                    }
                    else
                    {
                        topMinutes += 'Y';
                    }
                }
                else
                {
                    topMinutes += 'O';
                }
            }

            string bottomMinutes = new string('Y', minute % 5) + new string('O', 4 - minute % 5);

            // Construct Berlin Clock representation
            string berlinClockRepresentation = $"{topYellow}\n{topHours}\n{bottomHours}\n{topMinutes}\n{bottomMinutes}";
            return berlinClockRepresentation;
        }
    }
}

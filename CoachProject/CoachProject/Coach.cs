using System;

namespace CoachProject
{
    class Coach
    {
        private Passenger[] contents;
        private int counter;

        public Coach(int size)
        {
            contents = new Passenger[size];
        }

        public bool AddPassenger(Passenger passenger)
        {
            if (passenger == null) return false;
            if (passenger.GetSeat() > contents.Length) return false;
            if (!IsSeatEmpty(passenger.GetSeat())) return false;

            contents[passenger.GetSeat()] = passenger;
            counter++;
            return true;
        }

        public bool RemovePassenger(Passenger passenger)
        {
            if (passenger == null) return false;
            if (IsSeatEmpty(passenger.GetSeat())) return false;
            if (contents[passenger.GetSeat()] != passenger) return false;

            contents[passenger.GetSeat()] = null;
            counter--;
            return true;
        }

        public Passenger[] GetPassengers()
        {
            return contents;
        }

        public int GetSize()
        {
            return counter;
        }

        public Passenger GetPassengerByName(String name)
        {
            for(int seat = 0; seat < contents.Length; seat++)
            {
                if (IsSeatEmpty(seat)) continue;
                if (contents[seat].GetName() == name) return contents[seat];
            }
            return null;
        }

        public int GetSeatByName(String name)
        {
            for (int seat = 0; seat < contents.Length; seat++)
            {
                if (IsSeatEmpty(seat)) continue;
                if (contents[seat].GetName() == name) return seat;
            }
            return -1;
        }

        public bool IsSeatEmpty(int seat)
        {
            if (contents[seat] == null) return true;
            return false;
        }
    }
}
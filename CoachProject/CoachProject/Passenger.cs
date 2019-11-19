using System;
using System.Collections.Generic;
using System.Text;

namespace CoachProject
{
    public class Passenger : Person
    {
        private int seat;

        public Passenger(String name, int age, int seat) : base(name, age)
        {
            this.seat = seat;
        }

        public int GetSeat()
        {
            return seat;
        }

        public void SetSeat(int seat)
        {
            this.seat = seat;
        }
    }
}
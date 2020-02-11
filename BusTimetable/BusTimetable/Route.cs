namespace BusTimetable
{
    class Route
    {
        private string origin, destination;
        private string[] startTimes;
        private int routeCount;

        public Route(string origin, string destination, string[] startTimes, int routeCount)
        {
            this.origin = origin;
            this.destination = destination;
            this.startTimes = startTimes;
            this.routeCount = routeCount;
        }

        public string getOrigin()
        {
            return origin;
        }

        public string getDestination()
        {
            return destination;
        }

        public string[] getStartTimes()
        {
            return startTimes;
        }

        public int getRouteCount()
        {
            return routeCount;
        }
    }
}
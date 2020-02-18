namespace BusTimetable
{
    internal class Route
    {
        // where the bus starts from
        private readonly string _origin;
        // where bus terminates
        private readonly string _destination;
        // the amount of journeys scheduled along this route each day
        private readonly int _routeCount;
        // array of the start times.
        private readonly string[] _startTimes;

        public Route(string origin, string destination, string[] startTimes, int routeCount)
        {
            _origin = origin;
            _destination = destination;
            _startTimes = startTimes;
            _routeCount = routeCount;
        }

        public string GetOrigin()
        {
            return _origin;
        }

        public string GetDestination()
        {
            return _destination;
        }

        public string[] GetStartTimes()
        {
            return _startTimes;
        }

        public int GetRouteCount()
        {
            return _routeCount;
        }
    }
}
using Types;

namespace Events
{
    public class MoveEvent
    {
        public Position2D from;
        public Position2D to;
        public bool cancelled = false;
        
        public MoveEvent(Position2D from, Position2D to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
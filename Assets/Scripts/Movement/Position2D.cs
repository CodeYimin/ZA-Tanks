using UnityEngine;

namespace Types
{
    public struct Position2D
    {
        public Vector2 location;
        public float rotation;

        public Position2D(Vector2 location, float rotation)
        {
            this.location = location;
            this.rotation = rotation;
        }
    }
}
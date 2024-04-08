using UnityEngine;

namespace AICodingGame.API.Data.EventInfo.Hit
{
    public abstract class HitInfo
    {
        public Vector3 OtherPosition { get; set; }
        public float CollisionSpeed { get; set; }
    }
}
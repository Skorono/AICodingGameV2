using UnityEngine;

namespace AICodingGame.API.GameObjects
{
    public class RobotScanner : Rotator2D
    {
        public delegate void ScannedInfo(RaycastHit2D hit2D);

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            RotationSpeed = 40f;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        public event ScannedInfo OnObjectDetected;

        private void Scan()
        {
            var currentPos = _rigidbody.position;

            //var raycastPosition = transform.TransformDirection(currentPos);

            var hits = Physics2D.RaycastAll(currentPos, transform.up, 300);

            foreach (var hit in hits)
                if (hit.collider != null)
                {
                    Debug.DrawLine(currentPos, hit.point, Color.red, 1);
                    OnObjectDetected?.Invoke(hit);
                }
        }
    }
}
namespace AICodingGame.API.GameObjects
{
    public class RobotScanner : Rotator2D
    {
        public delegate void ScannedInfo(RaycastHit2D hit2D);

        private Rigidbody2D _rigidbody;

        public event ScannedInfo OnObjectDetected;

        private void Start()
        {
            _rotationSpeed = 40f;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Scan()
        {
            var currentPos = _rigidbody.position;

            //var raycastPosition = transform.TransformDirection(currentPos);

            RaycastHit2D[] hits = Physics2D.RaycastAll(currentPos, transform.up, 300);

            foreach (var hit in hits)
                if (hit.collider != null)
                {
                    Debug.DrawLine(currentPos, hit.point, Color.red, 1000);
                    OnObjectDetected?.Invoke(hit);
                }
        }
    }
}
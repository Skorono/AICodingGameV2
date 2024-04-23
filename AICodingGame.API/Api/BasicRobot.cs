using System;
using AICodingGame.API.GameObjects;

namespace AICodingGame.API
{
    /// <summary>
    ///     Basic class that describes interface of robot
    ///     Inherits Unity MonoBehaviour
    /// </summary>
    public abstract class BasicRobot : Robot
    {
        private readonly RobotStackFSM _fsm = new RobotStackFSM();

        private Rigidbody2D _rigidbody;

        private RobotGun _robotGun;
        private RobotScanner _scanner;
        private bool _turnIsEnd;
        public GameObject BulletPrefab { get; set; }

        private void Awake()
        {
            _fsm.PushAction(Run);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rotationSpeed = 25f;
            _robotGun = transform.Find("RobotBody").Find("Gun")
                .GetComponent<RobotGun>(); // При создании робота приклепляется компонент
            ((RobotGun)_robotGun.GetComponent(typeof(RobotGun))).BulletPrefab = BulletPrefab;

            _scanner = transform.Find("RobotBody").Find("Radar").GetComponent<RobotScanner>();
            _scanner.OnObjectDetected += OnScanDetectObject;
            _rigidbody.inertia = 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Action action;
            _rigidbody.inertia = 0;

            Energy -= 10;

            // Потому что могу :)
            switch (other.gameObject.tag)
            {
                case "Robot":
                    action = OnHitByRobot;
                    break;
                case "Wall":
                    action = OnHitWall;
                    break;
                case "Bullet":
                    action = OnHitByBullet;
                    break;
                default:
                    action = Run;
                    break;
            }

            _fsm.PushAction(action);
        }

        public void Execute()
        {
            _fsm.ExecuteAction();

            if (_fsm.GetStackSize > 1)
                _fsm.PopAction();
            _turnIsEnd = false;
        }

        public void SetBodyColor(Color color)
        {
            transform.Find("RobotBody").GetComponent<SpriteRenderer>().color = color;
        }

        public void SetTowerColor(Color color)
        {
            transform.Find("Gun").GetComponent<SpriteRenderer>().color = color;
        }

        private void OnScanDetectObject(RaycastHit2D hit)
        {
            Action action = null;

            if (hit.collider != gameObject.GetComponent<Collider2D>())
                switch (hit.collider.gameObject.tag)
                {
                    case "Robot":
                        action = OnEnemyDetect;
                        break;
                    /*case "Wall":
                    */
                }

            _fsm.PushAction(action);
        }

        public void OnScan()
        {
            _scanner.SendMessage("Scan");
        }


        protected void Move(int distance, MoveSpeed speed, MoveDirection direction)
        {
            var targetPoint = transform.TransformDirection(transform.up * distance * (float)direction);
            transform.position = Vector2.MoveTowards(transform.position, transform.position + targetPoint,
                (float)speed / 10 * Time.fixedDeltaTime);
        }

        public void TurnBody(float angle)
        {
            AddAngle(angle);
        }

        public void TurnAt(float angle)
        {
            SetAngle(angle);
        }

        public void TurnRobotGun(float angle)
        {
            _robotGun.SendMessage("AddAngle", angle);
        }

        public void TurnRobotGunAt(float angle)
        {
            _robotGun.SendMessage("SetAngle", angle);
        }

        public void TurnRadar(float angle)
        {
            _scanner.SendMessage("AddAngle", angle);
        }

        public void TurnRadarAt(float angle)
        {
            _scanner.SendMessage("SetAngle", angle);
        }

        public void Fire(RobotGun.FirePower firePower)
        {
            _robotGun.SendMessage("Fire", firePower);
        }

        public void Add(object o)
        {
        }
    }
}
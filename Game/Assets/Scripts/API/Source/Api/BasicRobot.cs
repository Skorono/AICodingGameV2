using System.Collections;
using AICodingGame.API.Data.EventInfo.Hit;
using AICodingGame.API.Data.EventInfo.Scanner;
using AICodingGame.API.GameObjects;
using UnityEngine;

namespace AICodingGame.API
{
    /// <summary>
    ///     Basic class that describes interface of robot
    ///     Inherits Unity MonoBehaviour
    /// </summary>
    public abstract class BasicRobot : Robot
    {
        public GameObject BulletPrefab;
        private RobotGun _robotGun;
        private RobotScanner _scanner;

        private void Awake()
        {
            gameObject.AddComponent(typeof(RobotStackFSM));
            _fsm = gameObject.GetComponent<RobotStackFSM>();

            var task = new RobotStackFSM.RobotTask
            {
                Work = _Run
            };
            task.Parameters = new object[] { task };

            _fsm.PushAction(task);
            _rigidBody2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            RotationSpeed = 25f;
            _robotGun = transform.Find("RobotBody").Find("Gun")
                .GetComponent<RobotGun>(); // При создании робота приклепляется компонент
            ((RobotGun)_robotGun.GetComponent(typeof(RobotGun))).BulletPrefab = BulletPrefab;

            _scanner = transform.Find("RobotBody").Find("Radar").GetComponent<RobotScanner>();
            _scanner.OnObjectDetected += OnScanDetectObject;
            _rigidBody2d.inertia = 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _rigidBody2d.velocity = Vector3.zero;
            _rigidBody2d.angularVelocity = 0;
            Energy -= 10;

            switch (other.gameObject.tag)
            {
                case "Robot":
                    Collide(new RobotHit
                    {
                        OtherPosition = other.collider.transform.position
                    });
                    break;
                case "Wall":
                    Collide(new WallHit());
                    break;
                case "Bullet":
                    Collide(new BulletHit());
                    break;
                default:
                    _fsm.PushAction(new RobotStackFSM.RobotTask
                    {
                        Work = _Run
                    });
                    break;
            }
        }

        private IEnumerator _Run(object[] parameters = null)
        {
            Run();
            ((RobotStackFSM.RobotTask)parameters[0]).IsEnded = true;
            yield return null;
        }

        private void OnScanDetectObject(RaycastHit2D hit)
        {
            if (hit.collider != gameObject.GetComponent<Collider2D>())
                switch (hit.collider.gameObject.tag)
                {
                    case "Robot":
                        Detect(new RobotInfo());
                        break;
                    case "Wall":
                        break;
                }
        }

        private void Detect(RobotInfo inf)
        {
            OnEnemyDetect(inf);
        }

        //private void Detect() => OnWallDetect(); 
        private void Collide(RobotHit hit)
        {
            HP -= (int)(hit.CollisionSpeed * 0.1);
            OnHitByRobot(hit);
        }

        private void Collide(WallHit hit)
        {
            HP -= 10;
            OnHitWall(hit);
        }

        private void Collide(BulletHit hit)
        {
            HP -= (int)(hit.CollisionSpeed * 0.25);
            OnHitByBullet(hit);
        }


        public void OnScan()
        {
            _scanner.SendMessage("Scan");
        }

        public void SetBodyColor(Color color)
        {
            transform.Find("RobotBody").GetComponent<SpriteRenderer>().color = color;
        }

        public void SetTowerColor(Color color)
        {
            transform.Find("RobotBody").transform.Find("Gun")
                .GetComponent<SpriteRenderer>().color = color;
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
    }
}
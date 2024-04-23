using System.Collections;
using API.Source.GameObjects;
using UnityEngine;
using Math = System.Math;

namespace AICodingGame.API.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotator2D : StackedWorker
    {
        [SerializeField] protected float RotationSpeed;
        protected Rigidbody2D _rigidBody2d;

        public bool isRotate { private set; get; }

        private void Awake()
        {
            if (_fsm == null)
            {
                gameObject.AddComponent<RobotStackFSM>();
                _fsm = gameObject.GetComponent<RobotStackFSM>();
            }

            _rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        }


        public void AddAngle(float angle)
        {
            isRotate = true;
            _fsm.PushAction(new RobotStackFSM.RobotTask
            {
                Work = Rotating,
                Parameters = new object[]
                    { angle > 0 ? (transform.rotation.eulerAngles.z + angle) % 360 : Math.Abs(360 + angle % 360) }
            });
        }

        private IEnumerator Rotating(object[] objects)
        {
            var step = RotationSpeed * Time.deltaTime;

            if (isRotate && _rigidBody2d.rotation != (float)objects[0])
            {
                _rigidBody2d.MoveRotation(_rigidBody2d.rotation + step);
            }
            else
            {
                isRotate = false;
                _fsm.GetTopAction().IsEnded = true;
            }

            yield return null;
        }

        public void SetAngle(float angle)
        {
            AddAngle(angle - GetObjectRotation());
        }

        public float GetObjectRotation()
        {
            return transform.rotation.z;
        }
    }
}
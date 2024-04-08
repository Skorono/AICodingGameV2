using System.Collections;
using API.Source.GameObjects;
using UnityEngine;

namespace AICodingGame.API.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotator2D : StackedWorker
    {
        protected Rigidbody2D _rigidBody2d;

        [SerializeField] protected float RotationSpeed;

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
                Parameters = new object[] { angle > 0 ? (transform.rotation.eulerAngles.z + angle) % 360 : Mathf.Abs(360 + angle) }
            });
        }

        private IEnumerator Rotating(object[] objects)
        {
            if (isRotate && transform.rotation.eulerAngles.z != (float)objects[0])
            {
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.Euler(0, 0, (float)objects[0]),
                    Time.fixedDeltaTime * RotationSpeed);
                yield return new WaitForFixedUpdate();
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
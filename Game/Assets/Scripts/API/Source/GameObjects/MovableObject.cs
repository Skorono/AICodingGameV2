using System.Collections;
using AICodingGame.API;
using AICodingGame.API.GameObjects;
using UnityEngine;

namespace API.Source.GameObjects
{
    public class MovableObject : Rotator2D
    {
        public enum MoveDirection
        {
            Forward = 1,
            Back = -1
        }

        [SerializeField]
        public enum MoveSpeed
        {
            Low = 15,
            Medium = 20,
            High = 25
        }

        public bool IsMoving { get; private set; }

        protected void Move(int distance, MoveSpeed speed, MoveDirection direction)
        {
            IsMoving = true;
            var targetPoint = transform.TransformDirection(Vector2.up * distance * (float)direction);
            var destinationPoint = transform.position + targetPoint;
            _fsm.PushAction(new RobotStackFSM.RobotTask
            {
                Work = Moving,
                Parameters = new object[] { destinationPoint, (float)speed }
            });

            /*while (transform.position != destinationPoint)
                transform.Translate(Vector2.up * ((int)speed * (int)direction)* Time.deltaTime);*/
        }

        private IEnumerator Moving(params object[] parameters)
        {
            Vector2 targetPosition = (Vector3)parameters[0];
            var speed = (float)parameters[1];

            if (IsMoving &&
                transform.position != new Vector3(targetPosition.x, targetPosition.y, transform.position.z))
            {
                _rigidBody2d.position = Vector2.MoveTowards(transform.position, targetPosition,
                    speed / 10 * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }

            else
            {
                _fsm.GetTopAction().IsEnded = true;
                IsMoving = false;
            }

            yield return null;
        }
    }
}
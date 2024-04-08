using System;
using System.ComponentModel.DataAnnotations;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace AICodingGame.API.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotator2D: MonoBehaviour
    {
        private Rigidbody2D _rigidBody2d;
        protected float _rotationSpeed;

        void Start()
        {
            _rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        }
        
        public void AddAngle([MinLength(360), MaxLength(360)] float angle)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angle),
                Time.fixedDeltaTime * _rotationSpeed);
        }

        public void SetAngle(float angle) => AddAngle(angle - GetObjectRotation());

        public float GetObjectRotation() => transform.rotation.z;
    }
}
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using UnityEngine;

namespace AICodingGame.API.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RobotGun: Rotator2D
    {
        public GameObject BulletPrefab { get; set; }

        private bool _gunIsCooling = false;

        private float _temperature;

        public float CurrentTemperature => _temperature;         
        
        public const float MaxGunTemputure = 30;

        private void Update()
        {
            if (_gunIsCooling != true)
            {
                StartCoroutine(GunCooling());
            }
        }

        private void Start()
        {
            _rotationSpeed = 60f;
            StartCoroutine(GunCooling());
        }

        public enum FirePower
        {
            Min = 1,
            Medium,
            High 
        }

        public void Fire(FirePower firePower)
        {
            if (_temperature < MaxGunTemputure)
            {
                Instantiate(BulletPrefab, transform.Find("BulletSpawner").position, transform.rotation)
                    .GetComponent<Rigidbody2D>().AddForce(transform.up * (float)firePower, ForceMode2D.Impulse);
                _temperature += (float)firePower / 3;
            }
            else
            {
                StartCoroutine(GunCooling());
            }
        }


        private IEnumerator GunCooling()
        {
            _gunIsCooling = true;
            
            if (_temperature > 0)
                _temperature -= .01f;

            _gunIsCooling = false;
            yield return null;
        }
    }
}
using System.Collections;
using UnityEngine;

namespace AICodingGame.API.GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RobotGun : Rotator2D
    {
        public enum FirePower
        {
            Min = 1,
            Medium,
            High
        }

        public const float MaxGunTemputure = 30;

        private bool _gunIsCooling;

        public GameObject BulletPrefab { get; set; }

        public float CurrentTemperature { get; private set; }

        private void Start()
        {
            RotationSpeed = 60f;
            StartCoroutine(GunCooling());
        }

        private void Update()
        {
            if (_gunIsCooling != true) StartCoroutine(GunCooling());
        }

        public void Fire(FirePower firePower)
        {
            if (CurrentTemperature < MaxGunTemputure)
            {
                Instantiate(BulletPrefab, transform.Find("BulletSpawner").position, transform.rotation)
                    .GetComponent<Rigidbody2D>().AddForce(transform.up * (float)firePower, ForceMode2D.Impulse);
                CurrentTemperature += (float)firePower / 3;
            }
            else
            {
                StartCoroutine(GunCooling());
            }
        }


        private IEnumerator GunCooling()
        {
            _gunIsCooling = true;

            if (CurrentTemperature > 0)
                CurrentTemperature -= .01f;

            _gunIsCooling = false;
            yield return null;
        }
    }
}
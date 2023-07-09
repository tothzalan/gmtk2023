using System;
using UnityEngine;

namespace PropScripts
{
    public class CarSpawnTrigger : MonoBehaviour
    {
        public GameObject car;
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(car, transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
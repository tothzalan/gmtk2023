using System;
using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothness = 1.125f;

        public Vector3 offset;

        private void LateUpdate()
        {
            Vector3 targetPos = Vector3.Lerp(new Vector3(target.position.x, 0), new Vector3((target.position + offset).x, 0, (target.position + offset).z), smoothness);
            transform.position = targetPos;
        }
    }
}

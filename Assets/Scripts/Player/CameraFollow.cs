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
            Vector3 targetPos = Vector3.Lerp(target.position, target.position + offset, smoothness);
            transform.position = targetPos;
        }
    }
}

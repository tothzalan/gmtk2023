using UnityEngine;

namespace Platforms
{
    public class PlatformHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("PlatformDestroy"))
                Destroy(gameObject);
        }
    }
}

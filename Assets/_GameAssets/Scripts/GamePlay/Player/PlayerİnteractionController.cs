using UnityEngine;

public class PlayerİnteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectibles>(out var Collectibles))
        {
            Collectibles.Collect();
        }
    }
}

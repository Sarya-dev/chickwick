using UnityEngine;

public class EggCollectible : MonoBehaviour, ICollectibles
{
    public void Collect()
    {
        GameManager.Instance.onEggCollected();
        Destroy(gameObject);
           
    }
}

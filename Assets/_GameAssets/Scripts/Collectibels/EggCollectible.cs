using UnityEngine;

public class EggCollectible : MonoBehaviour, ICollectibles
{
    public void Collect()
    {
        GameManager.Instance.onEggCollected();
        AudioManager.Instance.Play(SoundType.PickupGoodSound);
        Destroy(gameObject);
           
    }
}

using UnityEngine;

public class FireDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private float _force = 10f;
    


    public void GiveDamage(Rigidbody playerRigidbody, Transform playerVisualTransform)
    {
        HealthManager.Instance.Damage(1);
        playerRigidbody.AddForce(-playerVisualTransform.forward * _force, ForceMode.Impulse);
        Destroy(gameObject);
    }
    
}

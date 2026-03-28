using UnityEngine;

public interface IDamagable
{
    void GiveDamage(Rigidbody playerRigidbody, Transform playerVisualTransform);
}

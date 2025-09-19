using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void Damage(int damageAmaount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmaount; // TODO: uı damage animate}

            if (_currentHealth <= 0)
            {
                //TODO: player dead
            }

        }
    }
    public void Heal (int healAmount)
    {
       if(_currentHealth < _maxHealth)
        {
            _currentHealth=Mathf.Min(_currentHealth + healAmount, _maxHealth);
           
            
        }
    }

}

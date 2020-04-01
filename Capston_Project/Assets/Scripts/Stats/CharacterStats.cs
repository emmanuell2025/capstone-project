using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxMana = 100;
    public int currentHealth { get; private set; }
    public int currentMana { get; private set; }

    public Stat damage;
    public Stat armor;
    public Stat magicAttack;
    public Stat magicDefense;
    public Stat attackCooldown;
    public Stat attackSpeed;

    public event System.Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    
     

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        if (damage < 1)
        {
            damage = 1;
        }
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage. ");

        DetermineIfHealthChanged();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void DetermineIfHealthChanged() //Used for updating HealthBars.
    {
        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
    }

    public virtual void Die()
    {
        //Death method/animation depends on character.
        //Overwritable.
        Debug.Log(transform.name + " died.");
    }

    public void Heal(int amount)
    {
        if(currentHealth != maxHealth)
        {
            currentHealth += amount;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        DetermineIfHealthChanged();
    }
}

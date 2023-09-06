using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 5;
    private int currentHealth;
    [SerializeField] private GameObject BloodSplatter;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealth = startingHealth;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(BloodSplatter, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}

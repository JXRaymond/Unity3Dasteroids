using UnityEngine;
using System.Collections;

public class forceField : MonoBehaviour {

    [SerializeField]
    int maxHealth = 5;
    [SerializeField]
    int curHealth;
    [SerializeField]
    float regenerationRate = 100f;
    [SerializeField]
    int regenerateAmount = 1;

    void Start()
    {
        curHealth = maxHealth;
        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate()
    {
        if (curHealth < maxHealth)
            curHealth += regenerateAmount;
            eventManager.RegenDamage(curHealth / (float)maxHealth);

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
            CancelInvoke();
        }
    }

    public void TakeDamange(int dmg = 1)
    {
        curHealth -= dmg;
        eventManager.TakeDamage(curHealth / (float)maxHealth);
    }
    void Update()
    {
        if (curHealth < 0)
        {
            livesManager.lostLife();
            curHealth = 5;
            eventManager.TakeDamage(curHealth / (float)maxHealth);
        }
    }
}

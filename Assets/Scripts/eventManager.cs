using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class eventManager : MonoBehaviour {

    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void RegenDamageDelegate(float amt);
    public static RegenDamageDelegate onRegenDamage;

    public static void TakeDamage(float percent)
    {
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }

    public static void RegenDamage(float percent)
    {
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }

}

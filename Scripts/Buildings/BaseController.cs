using UnityEngine;

public class BaseController : MonoBehaviour
{
    public int maxHP = 200;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Check which base died
        if (CompareTag("TeamA"))
        {
            MatchManager.Instance.LoseGame();
        }
        else if (CompareTag("TeamB"))
        {
            MatchManager.Instance.WinGame();
        }

        Destroy(gameObject);
    }
}

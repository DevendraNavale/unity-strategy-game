using UnityEngine;
using System.Linq;

public class UnitController : MonoBehaviour
{
    [Header("Unit Data")]
    public UnitDefinition unitData;

    [Header("Combat Settings")]
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private float currentHP;
    private float lastAttackTime;

    private Transform targetEnemy;

    void Start()
    {
        if (unitData == null)
        {
            Debug.LogError($"UnitData missing on {gameObject.name}");
            enabled = false;
            return;
        }

        currentHP = unitData.maxHP;
    }
void Update()
{
    if (MatchManager.Instance == null ||
        MatchManager.Instance.CurrentState != MatchState.Playing)
    {
        return;
    }

    FindClosestEnemy();

    if (targetEnemy == null) return;

    float distance = Vector3.Distance(transform.position, targetEnemy.position);

    if (distance > attackRange)
        MoveTowardsEnemy();
    else
        TryAttack();
}



    void FindClosestEnemy()
    {
        string enemyTag = (gameObject.tag == "TeamA") ? "TeamB" : "TeamA";
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (enemies.Length == 0)
        {
            targetEnemy = null;
            return;
        }

        targetEnemy = enemies
            .OrderBy(e => Vector3.Distance(transform.position, e.transform.position))
            .First()
            .transform;
    }

    void MoveTowardsEnemy()
    {
        Vector3 dir = (targetEnemy.position - transform.position).normalized;
        transform.position += dir * unitData.moveSpeed * Time.deltaTime;
        transform.forward = dir;
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;
        Attack(targetEnemy.gameObject);
    }

    // 🔥 IMPORTANT PART (NEW)
    void Attack(GameObject target)
    {
        if (target.TryGetComponent(out UnitController unit))
        {
            unit.TakeDamage(unitData.damage);
            Debug.Log($"{name} hit UNIT {unit.name}");
        }
        else if (target.TryGetComponent(out BaseController baseCtrl))
        {
            baseCtrl.TakeDamage(unitData.damage);
            Debug.Log($"{name} hit BASE {baseCtrl.name}");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) Die();
    }

void Die()
{
    // Notify spawner if enemy died
    Destroy(gameObject);
}
}
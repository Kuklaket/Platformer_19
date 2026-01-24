using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    protected Stats CharacterStats { get; private set; }
    protected HealthSystem HealthSystem { get; private set; }

    private void Awake()
    {
        CharacterStats = GetComponent<Stats>();
        HealthSystem = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        HealthSystem.Died += Die;
    }
    private void OnDisable()
    {
        HealthSystem.Died -= Die;
    } 

    public void HandlerDamage(int damageCount)
    {
        HealthSystem.GetDamage(damageCount);
    }

    public int GetAttack()
    {
        return CharacterStats.Attack;
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}

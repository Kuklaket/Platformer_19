using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    public int Attack => CharacterStats.Attack;

    protected Stats CharacterStats { get; private set; }
    protected HealthSystem HealthSystem { get; private set; }

    private void Awake()
    {
        CharacterStats = GetComponent<Stats>();
        HealthSystem = GetComponent<HealthSystem>();
    }

    protected virtual void OnEnable()
    {
        HealthSystem.Died += Die;
    }
    protected virtual void OnDisable()
    {
        HealthSystem.Died -= Die;
    }

    public void HandleDamage(int damageCount)
    {
        HealthSystem.GetDamage(damageCount);
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
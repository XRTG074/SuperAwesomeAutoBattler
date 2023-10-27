using UnityEngine;



public class Enemy : MonoBehaviour
{
    private Hero hero;

    private int EnemyType;

    private double Health = 100;

    private int Power = 0;

    private System.Random rnd;

    private EnemyControllerScript ECS;

    private float attackDelay;

    void Start()
    {
        ECS = GameObject.Find("GameCanvas").GetComponent<EnemyControllerScript>();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        rnd = new System.Random();
    }

    public void CreateEnemy(int EnemyType, float attackDelay)
    {
        this.EnemyType = EnemyType;
        this.attackDelay = attackDelay;
        Invoke("Attack", 1.7f);
    }

    private void AttackDelay()
    {
        Invoke("Attack", attackDelay);
    }

    public void Attack()
    {
        switch (EnemyType)
        {
            case 0:
                if (GetComponent<Transform>().position.x > -2.5)
                {
                    GetComponent<Animator>().SetBool("Running", true);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-6.1f, 0), ForceMode2D.Impulse);
                    Invoke("RunDelay", 1.50f);
                }
                else
                {
                    if (Power <= 56)
                    {
                        GetComponent<Animator>().SetTrigger("Attack1");
                        AttackDelay();
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Attack2");
                        Power -= 56;
                        AttackDelay();
                    }
                }
                break;
            case 1:
                GetComponent<Animator>().SetTrigger("Attack1");
                AttackDelay();
                break;
        }
    }

    public void DealDamage(int AttackType)
    {
        switch (AttackType)
        {
            case 0:
                hero.RecieveDamage(rnd.Next(12,21));
                Power += rnd.Next(19, 31);
                break;
            case 1:
                hero.RecieveDamage(rnd.Next(24, 37));
                break;
            case 2:
                hero.RecieveDamage(rnd.Next(16, 22));
                break;
        }
    }

    public void RecieveDamage(double Damage)
    {
        if(Health - Damage <= 0)
        {
            GetComponent<Animator>().SetBool("Died", true);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Damaged");
            Health -= Damage;
        }
    }

    public void DieDelay()
    {
        ECS.OnEnemyDied(EnemyType);
        Destroy(gameObject);
    }

    private void RunDelay()
    {
        GetComponent<Animator>().SetBool("Running", false);
        AttackDelay();
    }
}

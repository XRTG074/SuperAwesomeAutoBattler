using UnityEngine;


public class Hero : MonoBehaviour
{

    private double health = 100;

    private double mana = 0;

    private Animator HeroAnimator;

    void Start()
    {
        HeroAnimator = GetComponent<Animator>();
    }

    public void Attack(int AttackID)
    {
        System.Random rnd = new System.Random();

        switch (AttackID)
        {
            case 0:
                HeroAnimator.SetTrigger("Attack1");
                double ManaRecharge = rnd.Next(0, 20);
                if (mana + ManaRecharge < 100)
                {
                    mana = mana + ManaRecharge;
                }
                break;
            case 1:
                if (mana >= 25)
                {
                    mana = mana - 25;
                    HeroAnimator.SetTrigger("Attack2");
                }
                break;
            case 2:
                if (mana >= 60)
                {
                    mana = mana - 60;
                    HeroAnimator.SetTrigger("Attack3");
                }
                break;
        }
    }

    public void RecieveDamage(double Damage)
    {
        if (health - Damage > 0)
        {
            HeroAnimator.SetTrigger("Damaged");
            health -= Damage;
        }
        else
        {
            HeroAnimator.SetTrigger("Die");
            Time.timeScale = 0;
        }
    }


    private void EndDieAnimation()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        GameObject.Find("GameCanvas").GetComponent<Animator>().SetTrigger("GameOver");
    }
}
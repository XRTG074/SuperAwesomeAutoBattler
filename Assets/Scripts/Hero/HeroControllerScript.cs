using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{

    private double health = 100;

    private double mana = 0;

    private Animator HeroAnimator;

    private System.Random rnd;

    private EnemyControllerScript ECS;

    private double tempDamage;

    private bool invulnerable = false;

    [SerializeField] private Button Attack2Button;
    [SerializeField] private Button Attack3Button;

    [SerializeField] private SpriteRenderer image;

    [SerializeField] private Text HealthText;
    [SerializeField] private Text ManaText;

    private AudioSource Soundtrack;
    private AudioSource DefeatSound;

    void Start()
    {
        Time.timeScale = 1;
        Soundtrack = GameObject.Find("Soundtrack").GetComponent<AudioSource>();
        DefeatSound = GameObject.Find("DefeatSound").GetComponent<AudioSource>();
        rnd = new System.Random();
        HeroAnimator = GetComponent<Animator>();
        ECS = GameObject.Find("GameCanvas").GetComponent<EnemyControllerScript>();
        AttackDelay();
    }

    private void AttackDelay()
    {
        Invoke("Attack", 3f);
        HealthText.text = "" + (int)health;
        ManaText.text = "" + (int)mana;
    }


    public void Attack()
    {
        if (ECS.Enemy1Exists || ECS.Enemy2Exists)
        {
            HeroAnimator.SetTrigger("Attack1");
            ECS.DamageEnemy(rnd.Next(11, 22));
            double ManaRecharge = rnd.Next(3, 18);
            if (mana + ManaRecharge < 100)
            {
                mana = mana + ManaRecharge;
            }
            if (mana >= 25)
            {
                if (mana >= 60)
                {
                    Attack3Button.interactable = true;
                }
                else
                {
                    Attack2Button.interactable = true;
                }
            }
        }
        AttackDelay();
    }

    public void Attack(int AttackID)
    {
        switch (AttackID)
        {
            case 1:
                if (mana >= 25)
                {
                    CancelInvoke();
                    mana = mana - 25;
                    HeroAnimator.SetTrigger("Attack2");
                    tempDamage = rnd.Next(39, 52);
                }
                break;
            case 2:
                if (mana >= 67)
                {
                    CancelInvoke();
                    mana = mana - 67;
                    HeroAnimator.SetTrigger("Attack3");
                    tempDamage = 200;
                }
                break;
        }
        if (mana < 67 && mana >= 25)
        {
            Attack3Button.interactable = false;
        }
        else
        {
            Attack2Button.interactable = false;
            Attack3Button.interactable = false;
        }
        Invoke("AttackDelay", 0.9f);
    }

    public void DamageDelay()
    {
        ECS.DamageEnemy(tempDamage);
    }

    public void RecieveDamage(double Damage)
    {
        if (invulnerable)
        {
            invulnerable = false;
        }
        else
        {
            if (health - Damage > 0)
            {
                invulnerable = true;
                HeroAnimator.SetTrigger("Damaged");
                health -= Damage;
                HealthText.text = "" + (int)health;
                ManaText.text = "" + (int)mana;
                if (health > 37 && health < 52)
                {
                    Soundtrack.pitch = 1.05f;
                    image.color = new Color(255, 0, 0, 0.09f);
                }
                else if (health > 24 && health < 37)
                {
                    Soundtrack.pitch = 1.1f;
                    image.color = new Color(255, 0, 0, 0.17f);
                }
                else if(health < 23)
                {
                    Soundtrack.pitch = 1.13f;
                    image.color = new Color(255, 0, 0, 0.34f);
                }

            }
            else
            {
                HealthText.text = "0";
                ManaText.text = "" + (int)mana;
                HeroAnimator.SetBool("Died", true);
                Soundtrack.enabled = false;
                DefeatSound.enabled = true;
                DefeatSound.ignoreListenerPause = true;
                DefeatSound.ignoreListenerVolume = true;
                image.color = new Color(255, 0, 0, 0);
                Time.timeScale = 0;
                
            }
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
using UnityEngine;


namespace HeroControllerScript
{
    public class HeroControllerScript : MonoBehaviour
    {

        private Hero hero;

        void Start()
        {
            hero = new Hero();
        }
    }
    public class Hero
    {
        public double health;

        public double mana;

        public Hero()
        {
            health = 100;
            mana = 0;
        }
    }
    public class HeroAttack : Hero
    {
        public void Attack(int AttackID)
        {
            System.Random rnd = new System.Random();

            switch (AttackID)
            {
                case 0:
                    GameObject.Find("Hero").GetComponent<Animator>().SetTrigger("Attack1");
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
                        GameObject.Find("Hero").GetComponent<Animator>().SetTrigger("Attack2");
                    }
                    break;
                case 2:
                    if (mana >= 60)
                    {
                        mana = mana - 60;
                        GameObject.Find("Hero").GetComponent<Animator>().SetTrigger("Attack3");
                    }
                    break;
            }
        }
    }
}

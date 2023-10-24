using System.Collections.Generic;
using UnityEngine;


namespace EnemyControllerScript
{
    public class EnemyControllerScript : MonoBehaviour
    {
        private List<Enemy> enemies;

        void Start()
        {
            enemies = new List<Enemy>();
        }

        public void CreateNewEnemy(int EnemyType)
        {
            switch (EnemyType)
            {
                case 0:
                    enemies.Add(new Enemy(enemies.Count, 0));
                    break;
                case 1:
                    enemies.Add(new Enemy(enemies.Count, 1));
                    break;
            }
            print(enemies[enemies.Count - 1].enemy.EnemyID);
        }
    }
}
public class Enemy
{
    public int EnemyID;

    public Enemy enemy;

    public Enemy()
    {

    }
    public Enemy(int EnemyID, int EnemyType)
    {
        this.EnemyID = EnemyID;
        switch (EnemyType)
        {
            case 0:
                enemy = new Enemy1(EnemyID);
                break;
            case 1:
                enemy = new Enemy2(EnemyID);
                break;
        }

    }
}
public class Enemy1 : Enemy
{
    public double health;

    public double power;


    public Enemy1(int EnemyID)
    {
        this.EnemyID = EnemyID;
        health = 100;
        power = 0;
    }
}
public class Enemy2 : Enemy
{
    public double health;

    public Enemy2(int EnemyID)
    {
        this.EnemyID = EnemyID;
        health = 100;
    }
}

//public interface IDamage
//{
//    public void GetDamage();
//}

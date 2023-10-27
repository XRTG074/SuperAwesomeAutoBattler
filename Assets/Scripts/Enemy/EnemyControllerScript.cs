using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{

    public float GameTemp = 10f;

    public bool Enemy1Exists = false;

    public bool Enemy2Exists = false;

    void Start()
    {
        CreateEnemy();
    }

    private void EnemyCreateDelay()
    {
        Invoke("CreateEnemy", GameTemp);
    }

    private void CreateEnemy()
    {
        if (!Enemy1Exists)
        {
            Instantiate(GameObject.Find("Enemy1Template")).name = "Enemy1";
            GameObject.Find("Enemy1").GetComponent<Enemy>().enabled = true;
            GameObject.Find("Enemy1").GetComponent<Enemy>().CreateEnemy(0, 3.7f);
            GameObject.Find("Enemy1").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("Enemy1").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            Enemy1Exists = true;
        }
        else if (!Enemy2Exists)
        {
            Instantiate(GameObject.Find("Enemy2Template")).name = "Enemy2";
            GameObject.Find("Enemy2").GetComponent<Enemy>().enabled = true;
            GameObject.Find("Enemy2").GetComponent<Enemy>().CreateEnemy(1, 5.5f);
            GameObject.Find("Enemy2").GetComponent<Animator>().enabled = true;
            GameObject.Find("Enemy2").GetComponent<SpriteRenderer>().enabled = true;

            Enemy2Exists = true;
        }
        EnemyCreateDelay();
    }

    public void OnEnemyDied(int EnemyType)
    {
        switch (EnemyType)
        {
            case 0:
                Enemy1Exists = false;
                break;
            case 1:
                Enemy2Exists = false;
                break;
        }
    }

    public void DamageEnemy(double Damage)
    {
        if (Damage == 200)
        {
            if (Enemy1Exists)
            {
                GameObject.Find("Enemy1").GetComponent<Enemy>().RecieveDamage(Damage);
            }
            if (Enemy2Exists)
            {
                GameObject.Find("Enemy2").GetComponent<Enemy>().RecieveDamage(Damage);
            }
        }
        try
        {
            if (Enemy1Exists && GameObject.Find("Enemy1").GetComponent<Transform>().position.x <= 5)
            {
                GameObject.Find("Enemy1").GetComponent<Enemy>().RecieveDamage(Damage);
            }
            else if(!Enemy2Exists && Enemy1Exists)
            {
                GameObject.Find("Enemy1").GetComponent<Enemy>().RecieveDamage(Damage);
            }
            else if(Enemy2Exists)
            {
                GameObject.Find("Enemy2").GetComponent<Enemy>().RecieveDamage(Damage);
            }
        }
        catch
        {
            if (Enemy2Exists)
            {
                GameObject.Find("Enemy2").GetComponent<Enemy>().RecieveDamage(Damage);
            }
        }

    }
}

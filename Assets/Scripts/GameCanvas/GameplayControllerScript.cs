using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayControllerScript : MonoBehaviour
{
    [SerializeField] private EnemyControllerScript ECS;

    [SerializeField] private GameObject panel;

    [SerializeField] private SpriteRenderer image;
    void Start()
    {
        Invoke("Delay1", 25f);
    }

    private void Delay1()
    {
        ECS.GameTemp = 7f;
        Invoke("Delay2", 15f);
    }

    private void Delay2()
    {
        ECS.GameTemp = 4f;
        Invoke("Delay3", 25f);
    }

    private void Delay3()
    {
        panel.SetActive(true);
        image.color = new Color(0, 0, 0, 0);
        Time.timeScale = 0;
    }
}

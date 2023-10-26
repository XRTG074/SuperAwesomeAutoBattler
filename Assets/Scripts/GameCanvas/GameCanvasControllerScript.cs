using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasControllerScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }
}

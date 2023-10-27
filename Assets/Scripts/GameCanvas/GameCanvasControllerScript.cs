using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasControllerScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }
    public void ButtonClicked(int option)
    {
        switch (option)
        {
            case 0:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case 1:
                SceneManager.LoadScene(0);
                break;
        }

    }
}

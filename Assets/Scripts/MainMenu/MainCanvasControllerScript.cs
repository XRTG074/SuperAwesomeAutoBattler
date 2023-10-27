using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
            isPaused = !isPaused;
        }
       
    }

    void Pause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(isPaused);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            pauseMenu.SetActive(isPaused);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        

    }
}

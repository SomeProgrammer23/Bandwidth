using UnityEngine;

public class TimeManager_01 : MonoBehaviour
{
    public float slowSpeed = 0.05f;
    //private float realTime = 1.0f;
    public float slowDownLength = 2f;
    public bool tutorialOff = false;

    //Method used to slow time when moving
    public void SlowTime()
    {
        Time.timeScale = slowSpeed;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    //This turns the tutorial off
    public void TutorialSwitch()
    {
        tutorialOff = !tutorialOff;
    }
    
    //Method used to bring time back to normal when not moving
    public void ReturnTime()
    {
        if(tutorialOff == true)
        {
            //Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }
}

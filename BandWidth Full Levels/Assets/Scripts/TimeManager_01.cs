using UnityEngine;

public class TimeManager_01 : MonoBehaviour
{
    public float slowSpeed = 0.05f;
    //private float realTime = 1.0f;
    public float slowDownLength = 2f;

    public void SlowTime()
    {
        Time.timeScale = slowSpeed;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void ReturnTime()
    {
        //Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}

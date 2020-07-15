using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowSpeed = 0.05f;
    private float realTime = 1.0f;
    public float slowDownLength = 2f;

    public void SlowTime()
    {
        Time.timeScale = slowSpeed;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void ReturnTime()
    {
        Time.timeScale = realTime;
    }
}

using UnityEngine;

public class Timer :MonoBehaviour
{
    private readonly float _startTime = 5f; 
    private float _currentTime;
    public bool StartDestroyTime = false;

    void Start()
    {
        StartTime();
    }

    public void StartTime()=>_currentTime = _startTime;
    public bool IsFinished()=> _currentTime <= 0;
    
    public void Tick()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            _currentTime = Mathf.Max(_currentTime, 0);
            Debug.Log("время:" + _currentTime.ToString("F0"));
        }
    }

    public void Reset()
    {
        StartDestroyTime = false;
        StartTime();
    }
  
}

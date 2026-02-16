using System.Collections.Generic;
using UnityEngine;

public class PlatformBlink : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    [SerializeField] float cycleTime = 2f;
    [SerializeField] float activeTime = 0.5f;
    [SerializeField] float startDelay = 0f;
    float remTime = 0f;
    bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeTime = Mathf.Clamp(activeTime, 0f, cycleTime);
        isActive = false;
        SetPlatformsActive(false);
        remTime = Mathf.Max(0f, startDelay);
    }

    void SetPlatformsActive(bool value)
    {
        foreach (GameObject p in platforms)
        {
            if (p != null)
                p.SetActive(value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        remTime -= Time.deltaTime;
        if (remTime > 0f) return;
        
        isActive = !isActive;
        SetPlatformsActive(isActive);

        remTime = isActive ? activeTime : Mathf.Max(0f, cycleTime - activeTime);

    }
}

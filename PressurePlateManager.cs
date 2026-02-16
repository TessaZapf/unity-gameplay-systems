using UnityEngine;
using System.Collections.Generic;

public class PressurePlateManager : MonoBehaviour
{
    [SerializeField] List<PressurePlate> plates = new List<PressurePlate>();
    [SerializeField] List<GameObject> portals = new List<GameObject>();
    [SerializeField] AudioClip activationSound;
    bool allActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPortalsActive(false);
    }

    void SetPortalsActive(bool value)
    {
        foreach (GameObject p in portals)
        {
            if (p != null)
                p.SetActive(value);
        }
    }

    public void NotifyPlatePressed(PressurePlate plate)
    {
        bool allActiveCheck = CheckAllPlates();
        if (allActiveCheck != allActive)
        {
            allActive = allActiveCheck;
            if (allActive)
            {
                ActivateTeleporter();
            }
            else DeactivateTeleporter();
        }
        
    }

    bool CheckAllPlates()
    {
        if (plates.Count == 0) 
        { 
            return false; 
        }
        
        foreach (PressurePlate plate in plates)
        {
            if (plate == null || !plate.IsActive)
            {
                return false;
            }
        }
        return true;
        
    }

    void ActivateTeleporter()
    {
        SetPortalsActive(true);

        if (activationSound != null) AudioSource.PlayClipAtPoint(activationSound, transform.position);
    }
    void DeactivateTeleporter()
    {
        SetPortalsActive(false);
    }
}

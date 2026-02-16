using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isActive;
    public bool IsActive => isActive;
    bool soundPlayed;
    [SerializeField] AudioClip sound;
    [SerializeField] TriggerManager manager;
    HashSet<GameObject> contacts = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Wall"))
        {
            if (!contacts.Contains(other.gameObject))
            {
                contacts.Add(other.gameObject);
                if(contacts.Count == 1)
                {
                    isActive = true;

                    if (manager != null) manager.NotifyPlatePressed(this);
                    
                    if (!soundPlayed) 
                    {
                        if(sound != null)AudioSource.PlayClipAtPoint(sound, transform.position);
                        soundPlayed = true;
                    }
                }
                
            }
            //Debug.Log(contacts.Count);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wall"))
        {
            if (contacts.Contains(other.gameObject))
            {
                contacts.Remove(other.gameObject);
                //Debug.Log(contacts.Count);
                if (contacts.Count == 0)
                {
                    isActive = false;
                    soundPlayed = false;
                    if (manager != null) manager.NotifyPlatePressed(this);
                }
            }
        }
    }
}

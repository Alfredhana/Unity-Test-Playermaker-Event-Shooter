using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventShooter : MonoBehaviour
{
    private PlayMakerFSM fsm;
    private GameObject gameObject;
    public string gameobjectName;
    public List<EventDict> events = new List<EventDict>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find(gameobjectName);
        if (gameObject)
        {
            fsm = gameObject.GetComponent<PlayMakerFSM>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            foreach (EventDict e in events)
            {
                if (e.isTriggered)
                {
                    fsm.SendEvent(e.eventName);
                    e.isTriggered = false;
                    break;
                }
            }
        }
    }
}

[System.Serializable] // So that the class shows up in the inspector
public class EventDict
{
    public string eventName; // Your event name
    public bool isTriggered;// Fire the event when clicked
}

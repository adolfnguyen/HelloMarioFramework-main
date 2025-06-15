using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerObject : MonoBehaviour
{
    [SerializeField] public int TriggerObjectID = 0;
    protected virtual void Awake()
    {
        EventManager.StartListening("TriggerObject", new UnityEngine.Events.UnityAction<int>(OnTriggerObject));
    }

    private void OnTriggerObject(int id)
    {
        Debug.Log("TriggerObject ID: " + id);
        if (id == TriggerObjectID)
        {
            OnTriggerStart();
        }
    }
    protected abstract void OnTriggerStart();
    void OnDestroy()
    {
        EventManager.StopListening("TriggerObject", new UnityEngine.Events.UnityAction<int>(OnTriggerObject));
    }
}

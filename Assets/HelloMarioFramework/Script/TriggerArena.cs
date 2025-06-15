using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HelloMarioFramework
{
    public class TriggerArena : MonoBehaviour
    {
        [SerializeField] int TriggerArenaID = 0;
        private void OnTriggerEnter(Collider collision)
        {
            Player p = collision.transform.GetComponent<Player>();
            if (p != null)
            {
                
                Debug.Log("Arena Triggered: " + TriggerArenaID);
                EventManager.TriggerEvent("TriggerObject", TriggerArenaID);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    public UnityEvent collisionEvent;
    [Tooltip("leave as 'any' for any collision")]
    public string targetTag = "any";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(targetTag == "any" || collision.gameObject.tag == targetTag)
        {
            collisionEvent.Invoke();
        }
    }
}

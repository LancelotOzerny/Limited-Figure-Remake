using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerContact : MonoBehaviour
{
    [SerializeField] private PlayerContactTagAction[] collisionEvents;
    [SerializeField] private PlayerContactTagAction[] triggerEvents;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var action in this.collisionEvents)
        {
            if (collision.gameObject.CompareTag(action.name))
            {
                if (action.destroyTrigger)
                {
                    Destroy(collision.gameObject);
                }

                action.actions.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var action in this.triggerEvents)
        {
            if (collision.CompareTag(action.name))
            {
                if (action.destroyTrigger)
                {
                    Destroy(collision.gameObject);
                }

                action.actions.Invoke();
            }
        }
    }
}

[System.Serializable]
class PlayerContactTagAction
{
    public string name;
    public bool destroyTrigger;
    public UnityEvent actions;
}
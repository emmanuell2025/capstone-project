
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    public Transform interactionTransform;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //stuff
       // Debug.Log("Interaction occured with " + transform.name);

    }

    void Update()
    {
        {
            if (isFocus && !hasInteracted)
            {
                float distance = Vector3.Distance(player.position, interactionTransform.position);
                if (distance <= radius)
                {
                    Interact();
                    hasInteracted = true;
                }
            }

        }
    }
    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocus()
    {

        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


}

using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus; //stores current focus
    public LayerMask movementMask; //Filters out objects

    //reference to our camera
    Camera cam;
    PlayerMotor motor;
    float range = 100;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))// Left Mouse Button is 0
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range, movementMask))// out keyword to pass by reference.
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))// Right Mouse Button is 1
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))// out keyword to pass by reference.
            {

               Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
               
                    SetFocus(interactable);                   

                }
            }
        }

    }
    void SetFocus(Interactable newFocus) {
        if (newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocus();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocus(transform);

    }

    void RemoveFocus() {
        if(focus != null)
            focus.OnDefocus();
        focus = null;
        motor.StopFollowingTarget();
    }
}

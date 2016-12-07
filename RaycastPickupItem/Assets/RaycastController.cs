using UnityEngine;
using System.Collections;

public class RaycastController : MonoBehaviour {

    // How far do you want the raycast to go? (Max distance a player can pickup an item from)
    public int theRayDistance;

    // What is the game object that has the camera attached to it? Set this in the editor.
    public GameObject other;

    // Variable which will contain the camera so we can get the position from it.
    private Camera cam;

    // Variable which will contain what the raycast hits.
    private RaycastHit hit;

    // I noticed we need to offset the RayCast just a little bit as it points too far down based on the camera's view in game.
    // Comment this line out if it is confusing and then play test. I think you will see the problem.
    Quaternion spreadAngle = Quaternion.AngleAxis(-15, new Vector3(1, 0, 0));

    void Start() { 

        // Get the camera attached to the "other" GameObject;
        cam = other.GetComponent<Camera>();

    }   

void FixedUpdate() {

        // Variable for how far away the object is from the character.
        float theDistance;

        // Variable forward: "Which direction is forward?" Lets get the Vector3 for that.
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward) * theRayDistance;

        // Offset the forward Vector3 slightly upward (in the "Y" Direction)
        // Comment this next line out if it is confusing, I think you will see the problem.
        Vector3 newVectorForward = spreadAngle * forward;

        // Debug allows us to see the raycast in the scene view to help us determine if it is doing what is intended.
        // This DOES NOT show in Game View.
        Debug.DrawRay(transform.position, newVectorForward, Color.blue);

        // Execute the raycast (this occurs every frame)
        // Did it hit anything (true or false)?
        if (Physics.Raycast(transform.position, (newVectorForward), out hit)) {

            // True, Yes it did hit something
            // Get the distance from the player to the object that it hit.
            theDistance = hit.distance;

            // Print that distance and the name of the object that it hit.
            print(theDistance + " " + hit.collider.gameObject.name);
        }
    }
}

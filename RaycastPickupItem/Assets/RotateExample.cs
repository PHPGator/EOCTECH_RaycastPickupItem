using UnityEngine;
using System.Collections;

public class RotateExample : MonoBehaviour {

    public Transform to;
    public Transform from;
    public float speed = 0.1f;

	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
	}
}

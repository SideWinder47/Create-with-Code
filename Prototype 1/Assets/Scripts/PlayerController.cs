using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	// Variables
	[SerializeField] private float speed = 15.0f;
	[SerializeField] private float turnspeed = 25.0f;
	[SerializeField] private float horizontal;
	[SerializeField] private float forward;
	
    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
    	
		// Player Input
		horizontal = Input.GetAxis("Horizontal");
		forward = Input.GetAxis("Vertical");
		
		// Controls the forward and reverse movement
		transform.Translate(Vector3.forward * Time.deltaTime * speed * forward);
		// Controls the turning
		transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontal);
    }
}

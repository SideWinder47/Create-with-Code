using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public GameObject Player;
	[SerializeField] private Vector3 offset = new Vector3(0, 6, -8);

	// LateUpdate is called once per frame after Update()
	void LateUpdate()
	{
		// Follows the player with an offset
		transform.position = Player.transform.position + offset;
    }
}

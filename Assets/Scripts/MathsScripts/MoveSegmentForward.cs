using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSegmentForward : MonoBehaviour
{
    public Transform player;       // Reference to the player
    public float segmentLength = 20f;  // Length of each segment

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has crossed the current segment (the player is farther than segmentLength in the Z direction)
        if (player.position.z - transform.position.z > segmentLength)
        {
            // Move the segment forward by two segment lengths (this ensures it cycles after crossing the player)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 250);
        }
    }
}

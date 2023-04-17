using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeManipulator : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {

        // Flip the position of the game object horizontally.
        if (other.tag == "Right Edge" || other.tag == "Left Edge")
        {
            Debug.Log("TUCH THE RIGHT SIDE EDGE");
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        // Flip the position of the game object vertically.
        if (other.tag == "Top Edge" || other.tag == "Bottom Edge")
        {
            Debug.Log("TUCH THE RIGHT SIDE EDGE");
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
        }


    }
}

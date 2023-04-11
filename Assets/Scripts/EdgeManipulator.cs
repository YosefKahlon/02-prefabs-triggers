using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeManipulator : MonoBehaviour
{

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        // I could make one tag for both side but then it is will look wirrd on the screen
        // if(other.tag == "Edge")

        if (other.tag == "Right Edge" || other.tag == "Left Edge")
        {
            Debug.Log("TUCH THE RIGHT SIDE EDGE");
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        if (other.tag == "Top Edge" || other.tag == "Down Edge")
        {
            Debug.Log("TUCH THE RIGHT SIDE EDGE");
            transform.position = new Vector3(transform.position.x , transform.position.y * -1, transform.position.z);
        }

    }
}

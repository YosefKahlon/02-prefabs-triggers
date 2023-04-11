using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Debug.Log("Plyaer take the power");
            Destroy(this.gameObject);
        }
        var laserShooter = other.GetComponent<LaserShooter>();
        if (laserShooter != null)
        {

            laserShooter.AddLaser();
        }

    }
}
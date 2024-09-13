using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotTressure : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<PlayerMovement>().gotTressure(true);
            Destroy(gameObject);
        }
    }
}

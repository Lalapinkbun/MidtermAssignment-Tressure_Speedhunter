using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindAnyObjectByType<PlayerMovement>().isVaild())
            {
                FindAnyObjectByType<PlayerMovement>().WinningPanel();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Soldier>().health -= 25;
            Destroy(gameObject);
        }

    }
}

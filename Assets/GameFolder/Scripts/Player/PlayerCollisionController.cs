using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("MedKit"))
            {
                print("medkit");
                Destroy(other.gameObject);//destroymedkit
                                          //collecing medkit ++
                                          //playerprefs kullanılabilir

            }
            if (other.gameObject.CompareTag("Soliter"))
            {

                print(other.gameObject.tag);

                //TODO: if idleda ise heal it
            }
            if (other.gameObject.CompareTag("Bullet"))
            {
                gameObject.GetComponent<PlayerManager>().OnGameover?.Invoke(); //game over
            }
        }
    }

}

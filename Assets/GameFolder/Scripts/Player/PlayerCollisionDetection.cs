using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
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
                //TODO: velocity=0
            }
        }
    }

}

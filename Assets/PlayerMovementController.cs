using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovementController : MonoBehaviour
{
    public List<GameObject> siperler = new List<GameObject>();
    private Transform hedef;
    public bool ısAlive = true;
    private int siper;

    private void Start()
    {
        siper = Random.Range(0, siperler.Count);
        Transform pos = siperler[siper].transform;
        hedef = pos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("Yerlerini, değiştir");
            hedef.position = siperler[(Random.Range(0, siperler.Count)) % siperler.Count].transform.position;
        }
        if (ısAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(hedef.position.x, transform.position.y, hedef.position.z), 15 * Time.deltaTime);
        }
        else if (ısAlive == false)
        {

        }
    }
}
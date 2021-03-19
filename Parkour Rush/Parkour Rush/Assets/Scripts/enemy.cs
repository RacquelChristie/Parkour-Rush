using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player")
        {
            Vector3 pushDirection = other.transform.position - transform.position;

            pushDirection -= pushDirection.normalized;

            GetComponent<Rigidbody>().AddForce(pushDirection * 10);

            SoundManager.PlaySound("Damage");

        }

    }
}

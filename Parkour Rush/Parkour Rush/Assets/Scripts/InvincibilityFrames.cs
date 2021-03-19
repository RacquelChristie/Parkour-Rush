using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames : MonoBehaviour
{
    private bool isInvincible = false;

    [SerializeField]
    private float invincibilityDurationSeconds;

    [SerializeField]
    private float invincibilityDeltaTime;

    [SerializeField]
    private GameObject model;

    public float force = 1;

    public PlayerController Player;

    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Enemy")
        {
            Vector3 pushDirection = other.transform.position - transform.position;

            pushDirection -= pushDirection.normalized;

            GetComponent<Rigidbody>().AddForce(pushDirection * 10 );

            Invincible();
        }

    }

    private IEnumerator Invincibility()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        Player.speed /= 2;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            
            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }

            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        
        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        Player.speed *= 2;
        isInvincible = false;
    }

    public void Invincible()
    {
        if (isInvincible)
        {
            
            return;
        }

        if (!isInvincible)
        {
            StartCoroutine(Invincibility());

        }
    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
}

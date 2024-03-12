using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitToFall());
        }
    }

    private void FallDawn()
    {
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
    }

    IEnumerator WaitToFall() 
    {
        yield return new WaitForSeconds(.5f);
        FallDawn();
        Destroy(transform.parent.gameObject, 1);
    }
}

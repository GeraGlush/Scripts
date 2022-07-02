using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

   private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}

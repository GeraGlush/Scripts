using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;


    private void Start()
    {
        target.SetActive(false);
    }

    public bool CanCapturedTarget()
    {
        return !target.activeSelf;
    }
}

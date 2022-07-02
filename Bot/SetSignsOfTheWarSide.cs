using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSignsOfTheWarSide : MonoBehaviour
{
    public Material[] sideMaterials;
    public GameObject[] sideDesignationObjects = null;

    private void Start()
    {
        int _warSideNum = (int)GetComponent<WarSideManager>().GetWarSide();
        if (sideMaterials != null)
        {
            Material sideMaterial = sideMaterials[_warSideNum];

            foreach (GameObject obj in sideDesignationObjects)
            {
                obj.GetComponent<Renderer>().material = sideMaterial;
            }
        }
    }
}

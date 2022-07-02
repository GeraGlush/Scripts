using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarSideManager : MonoBehaviour
{
    [SerializeField]
    private WarSide _warSide;

    public WarSide GetWarSide()
    {
        return _warSide;
    }
}

public enum WarSide
{
    Attackers=0,
    Defenders=1
}

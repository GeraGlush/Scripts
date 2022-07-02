using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    [SerializeField] private KeyCode _jump;
    [SerializeField] private KeyCode _attack;
    [SerializeField] private KeyCode _addicalAttack;
    [SerializeField] private KeyCode _hideAllWeapons;
    [SerializeField] private KeyCode _interactionKey;
    [SerializeField] private KeyCode _specialAttack;
    [SerializeField] private KeyCode _blockKey;

    [SerializeField] private KeyCode[] _takeWeaponKeys;

    [SerializeField] private bool _block;



    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    public float GetHorizontal()
    {
        return _horizontal;
    }

    public float GetVertical()
    {
        return _vertical;
    }

    public bool GetButtonAttack()
    {
        return Input.GetKey(_attack);
    }

    public bool GetButtonHideWeapons()
    {
        return Input.GetKeyDown(_hideAllWeapons);
    }

    public bool GetBlock()
    {
        if (Input.GetKeyDown(_blockKey) && !_block)
        {
            _block = true;
        }
        else if (Input.GetKeyUp(_blockKey) && _block)
        {
            _block = false;
        }

        return _block;
    }

    public bool GetSpecialAttackKeyDown()
    {
       return Input.GetKeyDown(_specialAttack);
    }  

    public bool GetButtonAddicalAttack()
    {
        return Input.GetKey(_addicalAttack);
    }

    public bool TakeWeaponButton(int weaponIndex)
    {
        return Input.GetKeyDown(_takeWeaponKeys[weaponIndex]);
    }

    public bool GetButtonJump()
    {
        return Input.GetKey(_jump);
    }

    public bool GetButtonInteractionButton()
    {
        return Input.GetKey(_interactionKey);
    }
}
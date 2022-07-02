using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private bool blocking;
    [SerializeField]
    private float energyExpensesForSecond;

    public GameObject shild;

    private PlayerEnergy _playerEnergy_cs;
    private PlayerInput _playerInput_cs;
    private KnightAnimation _animation;


    private void Start()
    {
        _animation = GetComponent<KnightAnimation>();
        _playerEnergy_cs = GetComponent<PlayerEnergy>();
        _playerInput_cs = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput_cs.GetBlock())
        {
            blocking = true;
            StartCoroutine(Blocking());
        }
        else
        {
            blocking = false;
        }
    }

    private IEnumerator Blocking()
    {
        _animation.SetTrigger("Block");
        yield return new WaitForSeconds(0.5f);
        GetComponent<PlayerMove>().enabled = false;
        shild.SetActive(true);

        while (blocking)
        {
            if (_playerEnergy_cs.GetEnergy() < energyExpensesForSecond)
                break;

            yield return new WaitForSeconds(1f);
            _playerEnergy_cs.Lose(energyExpensesForSecond);
        }

        shild.SetActive(false);
        GetComponent<PlayerMove>().enabled = true;
        _animation.SetTrigger("BlockBack");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField]
    private float _energy;

    [SerializeField]
    private float _energyRegeneration;

    [SerializeField]
    private float _maxEnergy;

    public PlayerBar energyBar;


    private void Start()
    {
        StartCoroutine(RegenerationEnergy());
    }

    private void Restore(float energyToRestore)
    {
        if ((_energy + energyToRestore) < _maxEnergy)
        {
            _energy += energyToRestore;
        }
        else
        {
            _energy = _maxEnergy;
        }
        SetEnergyBar();
    }

    public void Lose(float energyToLose)
    {
        if ((_energy - energyToLose) > 0)
        {
            _energy -= energyToLose;
        }
        else
        {
            _energy = 0;
        }
        SetEnergyBar();
    }

    private void SetEnergyBar()
    {
        energyBar.SetBarValue(_energy, _maxEnergy);
    }

    public float GetEnergy()
    {
        return _energy;
    }

    private IEnumerator RegenerationEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Restore(_energyRegeneration);
        }
    }
}

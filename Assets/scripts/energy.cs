using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public int MaxEnergy = 10000;
    public float CurrentEnergy;
    [SerializeField]float EnergyRegenAmount = 100;

    private void Start()
    {
        CurrentEnergy = MaxEnergy;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, MaxEnergy);
    }
    // Update is called once per frame
    void Update()
    {
        if(CurrentEnergy<MaxEnergy)
        {
            RegenEnergy();
        }
    }


    void RegenEnergy()
    {
        CurrentEnergy += EnergyRegenAmount *Time.deltaTime;
    }

    public void UseEnergy(float amount)
    {
        CurrentEnergy -= amount;
    }
}



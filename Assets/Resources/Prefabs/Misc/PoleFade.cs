using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PoleFade : MonoBehaviour
{
    public event Action OnPlanePass;
    private Material material;

    //wtf

    internal int _planesPassed = 0;
    internal int _planesInLevel => LevelManager.levelManager.PlanesInLevel;
    void Start()
    {
        OnPlanePass += () =>
        {
            _planesPassed++;
            material.color = Color.green * (_planesPassed / (float)_planesInLevel) +
            Color.red * ((_planesInLevel - _planesPassed) / (float)_planesInLevel);

            Color color = new Color();
            color.r = _planesInLevel - _planesPassed / (float)_planesInLevel;
            color.g = _planesPassed / (float)_planesInLevel;
            color.a = 1;
            

            material.color += Color.black;
        };

        material = GetComponent<Renderer>().material;

        OnPlanePass?.Invoke();
    }

    internal void PlanePassed()
    {
        OnPlanePass?.Invoke();
    }
}

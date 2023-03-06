using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private float time;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 ) Destroy(gameObject);
    }
}

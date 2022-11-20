using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys effect prefab on scene.
/// </summary>

public class DestroyByTime : MonoBehaviour
{

    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
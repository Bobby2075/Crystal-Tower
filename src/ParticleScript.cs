using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem system;

    private void Start() {
        system.Stop();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            system.Play();
        }
        else if(Input.GetMouseButtonUp(0)) {
            system.Stop();
        }
    }
}

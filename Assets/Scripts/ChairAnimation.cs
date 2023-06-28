using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody Chair;
    [SerializeField] private Vector3 rotationForce = new Vector3(0f, 100f, 0f);
    [SerializeField] private float damping = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Chair.AddTorque(rotationForce, ForceMode.Impulse);
        }

        ApplyDamping();

    }
    private void ApplyDamping()
    {
        Chair.angularVelocity *= (1f - damping);
    }
}

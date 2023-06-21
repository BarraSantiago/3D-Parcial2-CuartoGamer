using UnityEngine;
using UnityEngine.Serialization;

public class AnimationManager : MonoBehaviour
{
    [Header("Door")] [SerializeField] private Transform door;
    [SerializeField] private float originalDoorTime = 1.5f;
    [SerializeField] private float doorSpeed = 60;
    private Vector3 doorRotation = Vector3.zero;
    private float time = 0;
    private float doorOrientation = -1;

    [Header("Handle")] [SerializeField] private Transform handle;
    private float handleAuxX;
    [SerializeField] private float originalHandleTime = 1.5f;
    [SerializeField] private float handleSpeed = 25;
    private Vector3 handleRotation = Vector3.zero;
    private float handleOrientation = -1;
    private float duration;
    private bool isLerping;

    private void Start()
    {
        handleAuxX = handle.rotation.x;

        doorRotation.y = doorSpeed;

        handleRotation.x = handleSpeed;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time < originalHandleTime)
        {
            handleRotation.x = handleSpeed;
            LowerHandle();
        }
        else if (time < originalHandleTime + originalDoorTime)
        {
            OpenDoor();
            handleRotation.x = handleSpeed * 3;

            RiseHandle();
        }
    }

    private void RotateDoor()
    {
        door.Rotate(doorRotation * (doorOrientation * Time.deltaTime));
    }

    private void OpenDoor()
    {
        doorOrientation = -1;
        RotateDoor();
    }

    private void RotateHandle()
    {
        handle.Rotate(handleRotation * (handleOrientation * Time.deltaTime));
    }

    private void LowerHandle()
    {
        handleOrientation = -1;

        RotateHandle();
    }
    
    private void RiseHandle()
    {
        handleOrientation = 1;

        if (handle.rotation.x < handleAuxX)
        {
            RotateHandle();
        }
    }
}
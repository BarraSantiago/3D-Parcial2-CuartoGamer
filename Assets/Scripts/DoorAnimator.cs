using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private Transform door;
    [SerializeField] private float originalDoorTime = 1.5f;
    [SerializeField] private float doorSpeed = 60;
    private Vector3 doorRotation = Vector3.zero;
    private float doorOrientation = -1;

    [Header("Handle")]
    [SerializeField] private Transform handle;
    private float handleAuxX;
    [SerializeField] private float originalHandleTime = 1.5f;
    [SerializeField] private float handleSpeed = 25;
    private Vector3 handleRotation = Vector3.zero;
    private float handleOrientation = -1;

    [SerializeField]private bool isAnimating;

    private void Start()
    {
        handleAuxX = handle.rotation.x;

        doorRotation.y = doorSpeed;

        handleRotation.x = handleSpeed;

        // Start the coroutine
        StartCoroutine(AnimateDoorAndHandle());
    }

    private System.Collections.IEnumerator AnimateDoorAndHandle()
    {
        isAnimating = true;

        // Lower the handle
        float handleTime = 0f;
        while (handleTime < originalHandleTime)
        {
            handleRotation.x = handleSpeed;
            LowerHandle();

            handleTime += Time.deltaTime;
            yield return null;
        }

        // Open the door and raise the handle
        float doorTime = 0f;
        while (doorTime < originalDoorTime)
        {
            OpenDoor();
            handleRotation.x = handleSpeed * 3;

            RiseHandle();

            doorTime += Time.deltaTime;
            yield return null;
        }

        // Start returning to the original positions
        float returnTime = 0f;
        Quaternion handleStartRotation = handle.rotation;
        Quaternion doorStartRotation = door.rotation;
        while (returnTime < originalDoorTime)
        {
            float t = returnTime / originalDoorTime;
            handle.rotation = Quaternion.Slerp(handleStartRotation, Quaternion.Euler(0f, handleAuxX, 0f), t);
            door.rotation = Quaternion.Slerp(doorStartRotation, Quaternion.identity, t);

            returnTime += Time.deltaTime;
            yield return null;
        }

        // Set the handle and door to the exact original positions
        handle.rotation = Quaternion.Euler(0f, handleAuxX, 0f);
        door.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isAnimating = false;
        }
        if (!isAnimating)
        {
            // Call the coroutine again when the animation is not in progress
            StartCoroutine(AnimateDoorAndHandle());
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

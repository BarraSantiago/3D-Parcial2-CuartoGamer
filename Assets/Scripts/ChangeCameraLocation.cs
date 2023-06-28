using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraLocation : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;
    [SerializeField] private Camera cam;
    private int counter;
    void Start()
    {
        cam = Camera.main;
        counter = 0;
        cam.transform.position = positions[counter].position;
        cam.transform.rotation = positions[counter].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            counter--;
            if (counter <0)
            {
                counter = positions.Count-1;
            }
            cam.transform.position = positions[counter].position;
            cam.transform.rotation = positions[counter].rotation;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            counter++;
            if (counter >positions.Count-1)
            {
                counter = 0;
            }
            cam.transform.position = positions[counter].position;
            cam.transform.rotation = positions[counter].rotation;
        }
    }
}

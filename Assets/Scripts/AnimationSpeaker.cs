using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeaker : MonoBehaviour
{
    [SerializeField] private GameObject coneSpeaker1;
    [SerializeField] private float maxExpansionSpeaker;
    [SerializeField] private float minExpansionSpeaker;
    [SerializeField] private float velocityExpansion;
    private bool expanding;

    private void Start()
    {
        expanding = true;
    }
    private void Update()
    {
        if (coneSpeaker1.transform.localScale.x > maxExpansionSpeaker && expanding)
        {
            expanding = false;
        }

        if (coneSpeaker1.transform.localScale.x < minExpansionSpeaker && !expanding)
        {
            expanding = true;
        }

        if (expanding)
        {
            coneSpeaker1.transform.localScale += new Vector3(
          x: velocityExpansion * Time.deltaTime,
          y: velocityExpansion * Time.deltaTime,
          z: velocityExpansion * Time.deltaTime);
        }
        else
        {
            coneSpeaker1.transform.localScale += new Vector3(
          x: -velocityExpansion * Time.deltaTime,
          y: -velocityExpansion * Time.deltaTime,
          z: -velocityExpansion * Time.deltaTime);
        }

    }
}

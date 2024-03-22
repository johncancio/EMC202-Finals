using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int maxWidth = 342;
    public int maxHeight = 607;

    void Start()
    {
        Screen.SetResolution(maxWidth, maxHeight, false);
    }
}

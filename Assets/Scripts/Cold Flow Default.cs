using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdFlowDefault : MonoBehaviour
{
    public InputField defaultColdFlowRate;
    // Start is called before the first frame update
    void Start()
    {
        defaultColdFlowRate = GetComponent<InputField>();
        defaultColdFlowRate.text = "200";
    }
}

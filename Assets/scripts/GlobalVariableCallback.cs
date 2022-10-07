using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableCallback : MonoBehaviour
{
    public int calltoGlobal;

    void Update()
    {
        //Debug.Log("CalltoGlobal = " + calltoGlobal);
        calltoGlobal = GlobalVariableStorage.globalVariable;
    }
}

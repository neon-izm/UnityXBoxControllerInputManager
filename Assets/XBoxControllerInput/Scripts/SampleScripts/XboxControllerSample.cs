using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBoxControllerInput;
/// <summary>
/// XBoxControllerの入力を取得するサンプルスクリプト
/// .net4.6以降じゃないと動かない(nameof演算子使ってる)ので、.net3.5の人は全部文字列に差し替えてください
/// </summary>
public class XboxControllerSample : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(nameof(XBoxButtons.XboxA)))
        {
            Debug.Log(nameof(XBoxButtons.XboxA) + " pressed");
        }

        if (Input.GetButtonDown(nameof(XBoxButtons.XboxB)))
        {
            Debug.Log(nameof(XBoxButtons.XboxB) + " pressed");
        }

        if (Input.GetButtonDown(nameof(XBoxButtons.XboxX)))
        {
            Debug.Log(nameof(XBoxButtons.XboxX) + " pressed");
        }

        if (Input.GetButtonDown(nameof(XBoxButtons.XboxY)))
        {
            Debug.Log(nameof(XBoxButtons.XboxY) + " pressed");
        }
        
        if (Input.GetButtonDown(nameof(XBoxButtons.XboxL)))
        {
            Debug.Log(nameof(XBoxButtons.XboxL) + " pressed");
        }
        
        if (Input.GetButtonDown(nameof(XBoxButtons.XboxR)))
        {
            Debug.Log(nameof(XBoxButtons.XboxR) + " pressed");
        }

        var leftStickX = Input.GetAxis(nameof(XBoxAxis.XboxLeftStickX));
        var leftStickY = Input.GetAxis(nameof(XBoxAxis.XboxLeftStickY));
        if (Mathf.Abs(leftStickX) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XboxLeftStickX)+" :" +leftStickX);            
        }
        if (Mathf.Abs(leftStickY) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XboxLeftStickY)+" :" +leftStickY);            
        }
        
        
        var rightStickX = Input.GetAxis(nameof(XBoxAxis.XboxRightStickX));
        var rightStickY = Input.GetAxis(nameof(XBoxAxis.XboxRightStickY));
        if (Mathf.Abs(rightStickX) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XboxRightStickX)+" :" +rightStickX);            
        }
        if (Mathf.Abs(rightStickY) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XboxRightStickY)+" :" +rightStickY);            
        }
        
        var leftTrigger = Input.GetAxis(nameof(XBoxAxis.XBoxLeftTrigger));
        if (Mathf.Abs(leftTrigger) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XBoxLeftTrigger)+" :" +leftTrigger);            
        }
        
        var rightTrigger = Input.GetAxis(nameof(XBoxAxis.XBoxRightTrigger));
        if (Mathf.Abs(rightTrigger) > 0.2)
        {
            Debug.Log(nameof(XBoxAxis.XBoxRightTrigger)+" :" +rightTrigger);            
        }

    }
}
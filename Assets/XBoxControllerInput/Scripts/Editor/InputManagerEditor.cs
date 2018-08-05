using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace XBoxControllerInput
{
    /// <summary>
    /// UnityEditor上からInputManagerの中身を操作するエディタ拡張
    /// </summary>
    public class InputManagerEditor 
    {
        private static List<InputSettingData> _inputSettingList = new List<InputSettingData>();

        [MenuItem("Edit/XBoxController/Add")]
        static void AddMyXBoxControllerDefinition()
        {
            Debug.Log("hello");
            InputManagerAccessor accessor = new InputManagerAccessor ();           
            _inputSettingList = accessor.GetInputSettingDataList();

            //Aボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxA))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 0"
                    };
                _inputSettingList.Add(data);
            }
            //Bボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxB))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 1"
                    };
                _inputSettingList.Add(data);
            }
            
            //Xボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxX))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 2"
                    };
                _inputSettingList.Add(data);
            }
                        
            //Yボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxY))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 3"
                    };
                _inputSettingList.Add(data);
            }
            
            //Lボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxL))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 4"
                    };
                _inputSettingList.Add(data);
            }

            //Rボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XboxR))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 5"
                    };
                _inputSettingList.Add(data);
            }

            //Backボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XBoxBack))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 6"
                    };
                _inputSettingList.Add(data);
            }
            
            //Startボタン
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XBoxStart))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 7"
                    };
                _inputSettingList.Add(data);
            }
           
            //左スティック押し込み
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XBoxLeftStickClick))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 8"
                    };
                _inputSettingList.Add(data);
            }
            
            //右スティック押し込み
            {
                var data =
                    new InputSettingData(nameof(XBoxButtons.XBoxRightStickClick))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.KeyOrMouseButton,
                        positiveButton = "joystick button 9"
                    };
                _inputSettingList.Add(data);
            }
            
            
            //スティック入力
            //左スティックX軸
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XboxLeftStickX))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType.XAxis,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }
            
            //スティック入力
            //左スティックY軸
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XboxLeftStickY))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType.YAxis,
                        invert = true,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }

            
            //スティック入力
            //右スティックX軸
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XboxRightStickX))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType._4thAxis,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }
            
            //スティック入力
            //右スティックY軸
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XboxRightStickY))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType._5thAxis,
                        invert = true,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }

            //左トリガー,0から1の値
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XBoxLeftTrigger))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType._9thAxis,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }

            //右トリガー,0から1の値
            {
                var data =
                    new InputSettingData(nameof(XBoxAxis.XBoxRightTrigger))
                    {
                        joystickNum = (int) JoystickNum.All,
                        inputType = InputType.JoystickAxis,
                        axisType = AxisType._10thAxis,
                        dead = 0.001f,
                        gravity = 3f,
                        sensitivity = 3f
                    };
                _inputSettingList.Add(data);
            }

            
            accessor.SetInputSettingData (_inputSettingList);

        }

        [MenuItem("Edit/XBoxController/Remove")]
        static void RemoveMyXBoxControllerDefinition()
        {
            InputManagerAccessor accessor = new InputManagerAccessor ();
            _inputSettingList = accessor.GetInputSettingDataList();

            foreach (var VARIABLE in  Enum.GetNames(typeof(XBoxButtons)))
            {
                var index = _inputSettingList.FindIndex((x) => x.name == VARIABLE);
                if (index>=0)
                {
                    _inputSettingList.RemoveAt(index);
                }
            }
            
            foreach (var VARIABLE in  Enum.GetNames(typeof(XBoxAxis)))
            {
                var index = _inputSettingList.FindIndex((x) => x.name == VARIABLE);
                if (index>=0)
                {
                    _inputSettingList.RemoveAt(index);
                }
            }
            accessor.SetInputSettingData (_inputSettingList);

            
            Debug.Log("exit");
        }
        
         
    }
}
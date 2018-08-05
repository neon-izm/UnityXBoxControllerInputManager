using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
/**
[InputManagerAccessor.cs]
Copyright (c) 2018 https://github.com/atori708
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
namespace XBoxControllerInput
{
    public enum InputType
    {
        KeyOrMouseButton = 0,
        MouseMovement,
        JoystickAxis,
    }

    public enum AxisType
    {
        XAxis = 0,
        YAxis,
        _3rdAxis, // joystick and scrollwheel
        _4thAxis,
        _5thAxis,
        _6thAxis,
        _7thAxis,
        _8thAxis,
        _9thAxis,
        _10thAxis,
        _11thAxis,
        _12thAxis,
        _13thAxis,
        _14thAxis,
        _15thAxis,
        _16thAxis,
        _17thAxis,
        _18thAxis,
        _19thAxis,
        _20thAxis,
        _21thAxis,
        _22thAxis,
        _23thAxis,
        _24thAxis,
        _25thAxis,
        _26thAxis,
        _27thAxis,
        _28thAxis,
    }

    public enum JoystickNum
    {
        All = 0,
        Joystick1,
        Joystick2,
        Joystick3,
        Joystick4,
        Joystick5,
        Joystick6,
        Joystick7,
        Joystick8,
        Joystick9,
        Joystick10,
        Joystick11,
        Joystick12,
        Joystick13,
        Joystick14,
        Joystick15,
        Joystick16,
    }

    /// <summary>
    /// InputManagerを設定するためのクラス
    /// </summary>
    public class InputManagerAccessor
    {
        SerializedObject serializedObject;
        SerializedProperty axesProperty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InputManagerAccessor()
        {
            // InputManager.assetをシリアライズされたオブジェクトとして読み込む
            serializedObject =
                new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            axesProperty = serializedObject.FindProperty("m_Axes");
        }

        public void SetInputSettingData(List<InputSettingData> dataList)
        {
            if (dataList == null)
            {
                return;
            }

            Clear();
            for (int iInput = 0; iInput < dataList.Count; iInput++)
            {
                InputSettingData data = dataList[iInput];
                AddAxis(data);
            }
        }

        public List<InputSettingData> GetInputSettingDataList()
        {
            List<InputSettingData> dataList = new List<InputSettingData>();
            int count = axesProperty.arraySize;
            for (int i = 0; i < axesProperty.arraySize; i++)
            {
                dataList.Add(GetInputSettingData(axesProperty.GetArrayElementAtIndex(i)));
            }

            return dataList;
        }

        /// <summary>
        /// 軸を追加します。
        /// </summary>
        /// <param name="serializedObject">Serialized object.</param>
        /// <param name="data">Axis.</param>
        void AddAxis(InputSettingData data)
        {
            // if (axis.axis < 1) Debug.LogError("Axisは1以上に設定してください。");
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");

            axesProperty.arraySize++;
            serializedObject.ApplyModifiedProperties();

            SerializedProperty axisProperty = axesProperty.GetArrayElementAtIndex(axesProperty.arraySize - 1);

            GetChildProperty(axisProperty, "m_Name").stringValue = data.name;
            GetChildProperty(axisProperty, "descriptiveName").stringValue = data.descriptive;
            GetChildProperty(axisProperty, "descriptiveNegativeName").stringValue = data.negativeDescriptive;
            GetChildProperty(axisProperty, "negativeButton").stringValue = data.negativeButton;
            GetChildProperty(axisProperty, "positiveButton").stringValue = data.positiveButton;
            GetChildProperty(axisProperty, "altNegativeButton").stringValue = data.altNegativeButton;
            GetChildProperty(axisProperty, "altPositiveButton").stringValue = data.altPositiveButton;
            GetChildProperty(axisProperty, "gravity").floatValue = data.gravity;
            GetChildProperty(axisProperty, "dead").floatValue = data.dead;
            GetChildProperty(axisProperty, "sensitivity").floatValue = data.sensitivity;
            GetChildProperty(axisProperty, "snap").boolValue = data.snap;
            GetChildProperty(axisProperty, "invert").boolValue = data.invert;
            GetChildProperty(axisProperty, "type").intValue = (int) data.inputType;
            GetChildProperty(axisProperty, "axis").intValue = (int) data.axisType;
            GetChildProperty(axisProperty, "joyNum").intValue = (int) data.joystickNum;

            serializedObject.ApplyModifiedProperties();
        }

        InputSettingData GetInputSettingData(SerializedProperty property)
        {
            InputSettingData data = new InputSettingData(GetChildProperty(property, "m_Name").stringValue, false);
            data.descriptive = GetChildProperty(property, "descriptiveName").stringValue;
            data.negativeDescriptive = GetChildProperty(property, "descriptiveNegativeName").stringValue;
            data.negativeButton = GetChildProperty(property, "negativeButton").stringValue;
            data.positiveButton = GetChildProperty(property, "positiveButton").stringValue;
            data.altNegativeButton = GetChildProperty(property, "altNegativeButton").stringValue;
            data.altPositiveButton = GetChildProperty(property, "altPositiveButton").stringValue;
            data.gravity = GetChildProperty(property, "gravity").floatValue;
            data.dead = GetChildProperty(property, "dead").floatValue;
            data.sensitivity = GetChildProperty(property, "sensitivity").floatValue;
            data.snap = GetChildProperty(property, "snap").boolValue;
            data.invert = GetChildProperty(property, "invert").boolValue;
            data.inputType = (InputType) GetChildProperty(property, "type").intValue;
            data.axisType = (AxisType) GetChildProperty(property, "axis").intValue;
            data.joystickNum = (JoystickNum) GetChildProperty(property, "joyNum").intValue;
            return data;
        }

        /// <summary>
        /// 子要素のプロパティを取得します。
        /// </summary>
        /// <returns>The child property.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="name">Name.</param>
        SerializedProperty GetChildProperty(SerializedProperty parent, string name)
        {
            SerializedProperty child = parent.Copy();
            child.Next(true);
            do
            {
                if (child.name == name) return child;
            } while (child.Next(false));

            return null;
        }

        /// <summary>
        /// 設定を全てクリアします。
        /// </summary>
        void Clear()
        {
            axesProperty.ClearArray();
            serializedObject.ApplyModifiedProperties();
        }
    }

    /// <summary>
    /// 入力の情報
    /// </summary>
    public class InputSettingData : ICloneable
    {
        public bool isDisplay;
        public bool isUp;
        public bool isDown;
        public bool isDuplicate;
        public bool isRemove;

        public string name = "";
        public string descriptive = "";
        public string negativeDescriptive = "";
        public string negativeButton = "";
        public string positiveButton = "";
        public string altNegativeButton = "";
        public string altPositiveButton = "";

        public float gravity = 0;
        public float dead = 0;
        public float sensitivity = 0;

        public bool snap = false;
        public bool invert = false;

        public InputType inputType = InputType.KeyOrMouseButton;
        public AxisType axisType;
        public JoystickNum joystickNum;

        public bool isSetNegativeButton; // 負のボタンを設定するかどうか

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public InputSettingData(string name)
        {
            this.name = name;
            isDisplay = true;
        }

        public InputSettingData(string name, bool isDisplay)
        {
            this.name = name;
            this.isDisplay = isDisplay;
        }

        public InputSettingData Clone()
        {
            return (InputSettingData) MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// 押すと1になるキーの設定データを作成する
        /// </summary>
        /// <returns>The button.</returns>
        /// <param name="name">Name.</param>
        /// <param name="positiveButton">Positive button.</param>
        /// <param name="altPositiveButton">Alternate positive button.</param>
        public static InputSettingData CreateButton(string name, string positiveButton, string altPositiveButton)
        {
            var axis = new InputSettingData(name);
            axis.name = name;
            axis.positiveButton = positiveButton;
            axis.altPositiveButton = altPositiveButton;
            axis.gravity = 1000;
            axis.dead = 0.001f;
            axis.sensitivity = 1000;
            axis.inputType = InputType.KeyOrMouseButton;

            return axis;
        }

        /// <summary>
        /// ゲームパッド用の軸の設定データを作成する
        /// </summary>
        /// <returns>The joy axis.</returns>
        /// <param name="name">Name.</param>
        /// <param name="joystickNum">Joystick number.</param>
        /// <param name="axisType">Axis number.</param>
        public static InputSettingData CreatePadAxis(string name, JoystickNum joystickNum, AxisType axisType)
        {
            var axis = new InputSettingData(name);
            axis.name = name;
            axis.dead = 0.2f;
            axis.sensitivity = 1;
            axis.inputType = InputType.JoystickAxis;
            axis.axisType = axisType;
            axis.joystickNum = joystickNum;

            return axis;
        }

        /// <summary>
        /// キーボード用の軸の設定データを作成する
        /// </summary>
        /// <returns>The key axis.</returns>
        /// <param name="name">Name.</param>
        /// <param name="negativeButton">Negative button.</param>
        /// <param name="positiveButton">Positive button.</param>
        /// <param name="axisNum">Axis number.</param>
        public static InputSettingData CreateKeyAxis(string name, string negativeButton, string positiveButton,
            string altNegativeButton, string altPositiveButton)
        {
            var axis = new InputSettingData(name);
            axis.name = name;
            axis.negativeButton = negativeButton;
            axis.positiveButton = positiveButton;
            axis.altNegativeButton = altNegativeButton;
            axis.altPositiveButton = altPositiveButton;
            axis.gravity = 3;
            axis.sensitivity = 3;
            axis.dead = 0.001f;
            axis.inputType = InputType.KeyOrMouseButton;

            return axis;
        }
    }
}
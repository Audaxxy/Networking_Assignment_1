﻿using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Shift
{
    [ExecuteInEditMode]
    public class UIManagerImage : MonoBehaviour
    {
        [Header("RESOURCES")]
        public UIManager UIManagerAsset;
        public Image imageObject;

        [Header("SETTINGS")]
        public bool keepAlphaValue = false;
        public bool useCustomColor = false;
        public ColorType colorType;

        bool dynamicUpdateEnabled;

        public enum ColorType
        {
            PRIMARY,
            SECONDARY,
            PRIMARY_REVERSED,
            NEGATIVE,
            BACKGROUND
        }

        void OnEnable()
        {
            if (UIManagerAsset == null)
            {
                try
                {
                    UIManagerAsset = Resources.Load<UIManager>("Shift UI Manager");
                }

                catch
                {
                    Debug.Log("No UI Manager found. Assign it manually, otherwise it won't work properly.");
                }
            }
        }

        void Awake()
        {
            if (dynamicUpdateEnabled == false)
            {
                this.enabled = true;
                UpdateButton();
            }

            if (imageObject == null)
                imageObject = gameObject.GetComponent<Image>();
        }

        void LateUpdate()
        {
            if (UIManagerAsset != null)
            {
                if (UIManagerAsset.enableDynamicUpdate == true)
                    dynamicUpdateEnabled = true;
                else
                    dynamicUpdateEnabled = false;

                if (dynamicUpdateEnabled == true)
                    UpdateButton();
            }
        }

        void UpdateButton()
        {
            try
            {
                if (useCustomColor == false)
                {
                    if (keepAlphaValue == false)
                    {
                        if (colorType == ColorType.PRIMARY)
                            imageObject.color = UIManagerAsset.primaryColor;

                        else if (colorType == ColorType.SECONDARY)
                            imageObject.color = UIManagerAsset.secondaryColor;

                        else if (colorType == ColorType.PRIMARY_REVERSED)
                            imageObject.color = UIManagerAsset.primaryReversed;

                        else if (colorType == ColorType.NEGATIVE)
                            imageObject.color = UIManagerAsset.negativeColor;

                        else if (colorType == ColorType.BACKGROUND)
                            imageObject.color = UIManagerAsset.backgroundColor;
                    }

                    else
                    {
                        if (colorType == ColorType.PRIMARY)
                            imageObject.color = new Color(UIManagerAsset.primaryColor.r, UIManagerAsset.primaryColor.g, UIManagerAsset.primaryColor.b, imageObject.color.a);

                        else if (colorType == ColorType.SECONDARY)
                            imageObject.color = new Color(UIManagerAsset.secondaryColor.r, UIManagerAsset.secondaryColor.g, UIManagerAsset.secondaryColor.b, imageObject.color.a);

                        else if (colorType == ColorType.PRIMARY_REVERSED)
                            imageObject.color = new Color(UIManagerAsset.primaryReversed.r, UIManagerAsset.primaryReversed.g, UIManagerAsset.primaryReversed.b, imageObject.color.a);

                        else if (colorType == ColorType.NEGATIVE)
                            imageObject.color = new Color(UIManagerAsset.negativeColor.r, UIManagerAsset.negativeColor.g, UIManagerAsset.negativeColor.b, imageObject.color.a);

                        else if (colorType == ColorType.BACKGROUND)
                            imageObject.color = new Color(UIManagerAsset.backgroundColor.r, UIManagerAsset.backgroundColor.g, UIManagerAsset.backgroundColor.b, imageObject.color.a);
                    }
                }
            }

            catch { }
        }
    }
}
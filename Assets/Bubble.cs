using UnityEngine;
using System;

namespace Bubblebeam
{
    public enum Loop
    {
        None,
        Update,
        Fixed_Update,
        Late_Update
    }

    public enum KeyAction
    {
        None,
        Key_Down,
        Key_Up,
        Key_Held
    }

    public enum ButtonAction
    {
        None,
        Button_Down,
        Button_Up,
        Button_Held
    }

    public class Bubble
    {

        public static BubbleBlower Blower()
        {
            return new BubbleBlower();
        }

        public Loop updateLoop;
        public KeyCode keyCode;
        public KeyAction keyAction;
        public string buttonName;
        public ButtonAction buttonAction;
        public CustomBubble customBubble;

        public delegate void OnPop();
        public event OnPop onPop;

        public void PopBubble()
        {
            // onPop is the delegated method outside of this class
            onPop();
        }

        public class BubbleBlower
        {
            private Bubble _bubble = new Bubble();

            internal BubbleBlower() { }

            public BubbleBlower InLoop(Loop loop)
            {
                _bubble.updateLoop = loop;
                return this;
            }

            public BubbleBlower ForKey(KeyCode keyCode, KeyAction keyAction)
            {
                _bubble.keyCode = keyCode;
                _bubble.keyAction = keyAction;
                return this;
            }

            public BubbleBlower ForButton(string buttonName, ButtonAction buttonAction)
            {
                _bubble.buttonName = buttonName;
                _bubble.buttonAction = buttonAction;
                return this;
            }

            public BubbleBlower ForCustomBubble(CustomBubble customBubble)
            {
                _bubble.customBubble = customBubble;
                return this;
            }

            public BubbleBlower OnPop(OnPop function)
            {
                _bubble.onPop = function;
                return this;
            }

            public Bubble Inflate()
            {
                if (_bubble.updateLoop == Loop.None)
                {
                    throw new NotSupportedException("A Loop must be specified for a Bubble to properly Inflate");
                }

                var keyUnset = false;
                if (_bubble.keyCode != KeyCode.None)
                {
                    if (_bubble.keyAction == KeyAction.None)
                    {
                        throw new NotSupportedException("A KeyAction must be specified when a KeyCode is to properly Inflate");
                    }
                }
                else
                {
                    keyUnset = true;
                }

                var buttonUnset = false;
                if (_bubble.buttonName != null)
                {
                    if (_bubble.buttonAction == ButtonAction.None)
                    {
                        throw new NotSupportedException("A ButtonAction must be specified when a button name is to properly Inflate");
                    }
                }
                else
                {
                    buttonUnset = true;
                }

                if (buttonUnset && keyUnset && _bubble.customBubble == null)
                {
                    throw new NotSupportedException("A key, button, or custom event need to be set to properly Inflate");
                }

                return _bubble;
            }
        }
    }
}
using UnityEngine;
using System;

namespace Bubblebeam
{
    public enum Loop
    {
        UPDATE,
        FIXED_UPDATE,
        LATE_UPDATE
    }

    public enum KeyAction
    {
        KEY_DOWN,
        KEY_UP,
        KEY_HELD
    }

    public enum ButtonAction
    {
        BUTTON_DOWN,
        BUTTON_UP,
        BUTTON_HELD
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
                return _bubble;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubblebeam
{
    public abstract class BubbleAgent : MonoBehaviour
    {

        internal Bubble bubble;
        protected internal delegate void Checks();
        protected internal event Checks checks;

        protected internal void KeyDownCheck()
        {
            if (Input.GetKeyDown(bubble.keyCode))
            {
                bubble.PopBubble();
            }
        }

        protected internal void KeyUpCheck()
        {
            if (Input.GetKeyUp(bubble.keyCode))
            {
                bubble.PopBubble();
            }
        }

        protected internal void KeyHeldCheck()
        {
            if (Input.GetKey(bubble.keyCode))
            {
                bubble.PopBubble();
            }
        }

        protected internal void ButtonDownCheck()
        {
            if (Input.GetButtonDown(bubble.buttonName))
            {
                bubble.PopBubble();
            }
        }

        protected internal void ButtonUpCheck()
        {
            if (Input.GetButtonUp(bubble.buttonName))
            {
                bubble.PopBubble();
            }
        }

        protected internal void ButtonHeldCheck()
        {
            if (Input.GetButton(bubble.buttonName))
            {
                bubble.PopBubble();
            }
        }

        protected internal void CustomBubbleCheck()
        {
            if (bubble.customBubble.ShouldPop())
            {
                bubble.PopBubble();
            }
        }

        void Awake()
        {
            enabled = false;
        }

        internal void RunChecks()
        {
            checks();
        }

        internal void InitializeWithBubble(Bubble bubble)
        {
            this.bubble = bubble;
            if (bubble.keyCode != KeyCode.None)
            {
                switch (bubble.keyAction)
                {
                    case KeyAction.Key_Down:
                        checks += KeyDownCheck;
                        break;
                    case KeyAction.Key_Up:
                        checks += KeyUpCheck;
                        break;
                    case KeyAction.Key_Held:
                        checks += KeyHeldCheck;
                        break;
                }
            }

            if (bubble.buttonName != null)
            {
                switch (bubble.buttonAction)
                {
                    case ButtonAction.Button_Down:
                        checks += ButtonDownCheck;
                        break;
                    case ButtonAction.Button_Up:
                        checks += ButtonUpCheck;
                        break;
                    case ButtonAction.Button_Held:
                        checks += ButtonHeldCheck;
                        break;
                }
            }

            if (bubble.customBubble != null) {                
                checks += CustomBubbleCheck;
            }

            enabled = true;
        }
    }

}
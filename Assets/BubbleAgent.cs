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
                    case KeyAction.KEY_DOWN:
                        checks += KeyDownCheck;
                        break;
                    case KeyAction.KEY_UP:
                        checks += KeyUpCheck;
                        break;
                    case KeyAction.KEY_HELD:
                        checks += KeyHeldCheck;
                        break;
                }
            }

            if (bubble.buttonName != null)
            {
                switch (bubble.buttonAction)
                {
                    case ButtonAction.BUTTON_DOWN:
                        checks += ButtonDownCheck;
                        break;
                    case ButtonAction.BUTTON_UP:
                        checks += ButtonUpCheck;
                        break;
                    case ButtonAction.BUTTON_HELD:
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubblebeam
{
    public class Beam : MonoBehaviour
    {
        public static Beam instance;
        void Awake()
        {
            if (instance != this)
            {
                instance = this;
            }
        }
        public void AddBubble(Bubble bubble)
        {
            switch (bubble.updateLoop)
            {
                case Loop.UPDATE:
                    instance.gameObject.AddComponent<BubbleUpdateAgent>().InitializeWithBubble(bubble);
                    break;
                case Loop.FIXED_UPDATE:
                    instance.gameObject.AddComponent<BubbleFixedUpdateAgent>().InitializeWithBubble(bubble);
                    break;
                case Loop.LATE_UPDATE:
                    instance.gameObject.AddComponent<BubbleLateUpdateAgent>().InitializeWithBubble(bubble);
                    break;
            }
        }


    }
}
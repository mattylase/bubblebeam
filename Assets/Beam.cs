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
                case Loop.Update:
                    instance.gameObject.AddComponent<BubbleUpdateAgent>().InitializeWithBubble(bubble);
                    break;
                case Loop.Fixed_Update:
                    instance.gameObject.AddComponent<BubbleFixedUpdateAgent>().InitializeWithBubble(bubble);
                    break;
                case Loop.Late_Update:
                    instance.gameObject.AddComponent<BubbleLateUpdateAgent>().InitializeWithBubble(bubble);
                    break;
            }
        }


    }
}
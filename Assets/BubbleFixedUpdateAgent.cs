using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubblebeam
{
    public class BubbleFixedUpdateAgent : BubbleAgent
    {
        void FixedUpdate()
        {
            RunChecks();
        }

    }

}
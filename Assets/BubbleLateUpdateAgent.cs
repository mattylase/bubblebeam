using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubblebeam
{
    public class BubbleLateUpdateAgent : BubbleAgent
    {
        void LateUpdate()
        {
			RunChecks();
        }
    }
}
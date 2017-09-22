using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubblebeam
{
    public class BubbleUpdateAgent : BubbleAgent
    {
        void Update()
        {
            RunChecks();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.Progression
{
    public class ProgressableEntity : MonoBehaviour
    {
        public void Progress()
        {
            foreach(IProgressable progressable in GetComponents<IProgressable>())
            {
                progressable.Progress();
            }
        }
    }
}

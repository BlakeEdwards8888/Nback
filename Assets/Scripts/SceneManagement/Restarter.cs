using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nestre.SceneManagement
{
    public class Restarter : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}

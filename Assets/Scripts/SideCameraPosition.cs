using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{ 
    public class SideCameraPosition : MonoBehaviour
    {
        #region Dependencies

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(0, transform.position.y, 20.0f);
        }

    }
}

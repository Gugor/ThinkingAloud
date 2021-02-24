using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{ 
    public class CameraSwitch : MonoBehaviour
    {
        #region Dependencies
        public Camera playerCamera;
        public Camera sideCamera;
        #endregion
        #region Private Variables
        private bool isFirstCamera;
        #endregion

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1)) 
            {
                isFirstCamera = false;
                SwitchCamera();
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                isFirstCamera = true;
                SwitchCamera();
            }
        }

        private void SwitchCamera()
        {
            if (isFirstCamera)
            {

                playerCamera.enabled = false;
                sideCamera.enabled = true;
                
            }
            else 
            {
                playerCamera.enabled = true;
                sideCamera.enabled = false;
            }
        }
    }

}

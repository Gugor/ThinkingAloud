using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SquareManShootTetris 
{ 
    public class RotateScene : MonoBehaviour
    {
        #region Dependencies

        #endregion
        #region Public Variables

        #endregion
        #region Properties
        public int[] SceneRotationAngles = { 0, 90, 180, 270 };
        public int SceneRotationAngle = 0;
        private int SceneRoationIndex = 0;
        #endregion

        #region Events
        public UnityEvent OnSceneRotation;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            SceneRotationAngle = 0;
            SceneRoationIndex = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse3)) 
            {
                Debug.Log("Mouse boton 3 press");
                SceneRoationIndex++;
                RotateRight();
            }
            if (Input.GetKeyDown(KeyCode.Mouse4))
            {
                Debug.Log("Mouse boton 4 press");
                SceneRoationIndex--;
                RotateLeft();
            }
        }

        public void RotateLeft() 
        {
            transform.Rotate(new Vector3(0, 90, 0));
            ChangeRotationIndex();
        }

        public void RotateRight() 
        {
            transform.Rotate(new Vector3(0, -90, 0));
            ChangeRotationIndex();
        }

        private void ChangeRotationIndex() 
        {
            if (SceneRoationIndex > 3) 
            {
                SceneRoationIndex = 0;
            }
            if (SceneRoationIndex < 0) 
            {
                SceneRoationIndex = 3;
            }

            SceneRotationAngle = SceneRotationAngles[SceneRoationIndex];
            OnSceneRotation.Invoke();
        }
    }

}

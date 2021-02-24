using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SquareManShootTetris 
{ 
    public class PlayerMovement : MonoBehaviour
    {
        #region Dependencies
        [Header("Dependencies")]
        public LevelBuilder levelBuilder;
        private RotateScene sceneRotation;
        #endregion
        #region Public Variables
        [Header("Settings")]
        public GameObject groundGrid;
        public float speed;
        public bool canMove;
        #endregion

        #region Private Variables
        
        private Rigidbody rb;
        private float horizontalMovement;
        private float verticalMovement;
        private bool isFalling;

        [SerializeField] private LayerMask collidingMasks;
        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            levelBuilder = FindObjectOfType<LevelBuilder>();
            sceneRotation = FindObjectOfType<RotateScene>();
        }


        // Update is called once per frame
        void Update()
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");

            if (canMove)
            {
                Move(sceneRotation.SceneRotationAngle);

                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    Debug.Log("Juming!!");
                    Jump();
                }
            }
        }

        private void Jump() 
        {
            rb.AddForce(transform.up * 9f, ForceMode.Impulse);
        }

        private void Move(int degrees) 
        {
            switch (degrees) 
            {
                case 0:
                    Debug.Log("Scene Angle:" + degrees + "º");
                    rb.transform.Translate(new Vector3(speed * horizontalMovement * Time.deltaTime, 0, speed * verticalMovement * Time.deltaTime));
                    break;
                case 90:
                    Debug.Log("Scene Angle:" + degrees + "º");
                    rb.transform.Translate(new Vector3(speed * -verticalMovement * Time.deltaTime, 0, speed *  horizontalMovement * Time.deltaTime));
                    break;
                case 180:
                    Debug.Log("Scene Angle:" + degrees + "º");
                    rb.transform.Translate(new Vector3(speed * -horizontalMovement * Time.deltaTime, 0, speed * -verticalMovement * Time.deltaTime));
                    break;
                case 270:
                    Debug.Log("Scene Angle:" + degrees + "º");
                    rb.transform.Translate(new Vector3(speed * verticalMovement * Time.deltaTime, 0, speed * -horizontalMovement * Time.deltaTime));
                    break;

            }

            ClampMovment();
        }

        //private void DetectCollisions() 
        //{
        //    Collider[] overlapColliders = new Collider[8];

        //    Physics.OverlapSphereNonAlloc(transform.position, transform.lossyScale.x, overlapColliders, collidingMasks); 
        //    { 
                
        //    }
        
        //}

        public void ClampMovment() 
        {
            float xPos = Mathf.Clamp(transform.position.x, groundGrid.transform.position.x, (groundGrid.transform.position.x + levelBuilder.gridSize.x) - (transform.lossyScale.x));
            float zPos = Mathf.Clamp(transform.position.z, groundGrid.transform.position.z, (groundGrid.transform.position.z + levelBuilder.gridSize.y) - (transform.lossyScale.z));
            rb.transform.position = new Vector3(xPos, transform.position.y, zPos);
        }
    }

}
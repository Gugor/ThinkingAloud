using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{ 
    public class PlayerShoot : MonoBehaviour
    {
        #region Dependencies
        public GameObject shotPrefab;
        public Transform shotOrigin;
        public Transform shotsContainer;
        public Statistics statistics;
        #endregion

        #region Public Vatiables

        #endregion

        #region Properties
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            statistics = FindObjectOfType<Statistics>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0)) 
            {
                GameObject shot = Instantiate(shotPrefab, shotOrigin.transform.position, Quaternion.identity);
                shot.transform.SetParent(shotsContainer);
                statistics.IncreaseNumShots();
            }

        }
    }

}

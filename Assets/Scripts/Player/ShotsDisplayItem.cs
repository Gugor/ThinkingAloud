using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SquareManShootTetris 
{ 
    public class ShotsDisplayItem : MonoBehaviour
    {

        #region Dependencies
        public TextMeshProUGUI numOfShotsDisplay;
        public Statistics statistics;
        [SerializeField] private PlayerShoot playerShoot;
        #endregion 

        #region Public Variables
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            statistics = FindObjectOfType<Statistics>();
            if (numOfShotsDisplay == null) 
            {
                numOfShotsDisplay = GetComponent<TextMeshProUGUI>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            numOfShotsDisplay.text = "Shots: " + statistics.NumShots.ToString().PadLeft(8,'0');
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SquareManShootTetris.UI 
{ 
    public class MainVariablesDisplay : MonoBehaviour
    {
        #region Dependencies
        public DifficultyManager difficultyManager;
        public TextMeshProUGUI gravityTMP;
        public TextMeshProUGUI timeBetweenWavesTMP;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            difficultyManager = FindObjectOfType<DifficultyManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (gravityTMP != null) 
            { 
                gravityTMP.text = difficultyManager.Gravity.ToString();           
            }
            if (timeBetweenWavesTMP != null) 
            { 
                timeBetweenWavesTMP.text = difficultyManager.TimeBetweenWaves.ToString();
            }
        }
    }

}

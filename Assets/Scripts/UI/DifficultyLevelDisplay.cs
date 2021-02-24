using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SquareManShootTetris.UI 
{ 
    public class DifficultyLevelDisplay : MonoBehaviour
    {
        #region Dependencies
        public DifficultyManager difficultyManager;
        public TextMeshProUGUI levelTMP;
        public TextMeshProUGUI timeToChangeDifficultyTMP;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            difficultyManager = FindObjectOfType<DifficultyManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (levelTMP != null) 
            { 
                levelTMP.text = difficultyManager.Difficulty.ToString() + " lvl";
            }
            if (timeToChangeDifficultyTMP != null) 
            { 
                timeToChangeDifficultyTMP.text = difficultyManager.TimeToChangeDifficulty.ToString() + " s";
            }
        }

}
}

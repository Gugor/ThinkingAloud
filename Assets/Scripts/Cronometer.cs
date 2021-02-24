using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SquareManShootTetris 
{ 
    public class Cronometer : MonoBehaviour
    {
        #region Dependencies
        public TextMeshProUGUI timerDisplay;
        #endregion

        private float rawTime;
        private float secs;
        private int mins;
        // Start is called before the first frame update
        void Start()
        {
            timerDisplay.text = "00:00";
        }

        // Update is called once per frame
        void Update()
        {
            rawTime += Time.deltaTime;
            SetCrono();
        }

        public void SetCrono() 
        {
            if (secs >= 59)
            {
                mins++;
                secs = 0;
            }
            else 
            {             
                secs += Time.deltaTime;
            }

            timerDisplay.text = mins.ToString().PadLeft(2, '0') +":" + Mathf.RoundToInt(secs).ToString().PadLeft(2, '0');
        }

    }

}

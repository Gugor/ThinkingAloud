using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SquareManShootTetris 
{ 
    public class DifficultyManager : MonoBehaviour
    {
        #region Dependencies
        private LevelBuilder levelBuilder;
        #endregion

        #region Public Variables
        
        #endregion

        #region Private Variables
        private int DifficultyLevel = 1;
        [SerializeField] private float timeToChangeDifficulty = 25.0f;
        [SerializeField] private float difficultyMultiplier = 1.1f;
        [Range(0f, 1f)]
        [SerializeField] private float spawningDensity = 0.3f;

        private float elapsedTimeToChangeDifficulty;
        #endregion

        #region Properties
        public int Difficulty => DifficultyLevel;
        public float TimeToChangeDifficulty => timeToChangeDifficulty;
        public float Gravity { get; private set; }
        public float TimeBetweenWaves { get; private set; }
        public int Density => Mathf.RoundToInt((levelBuilder.gridSize.x * levelBuilder.gridSize.y) * spawningDensity);
        #endregion

        #region Events
        public UnityEvent OnDifficultyChange;
        #endregion

        #region BuiltIn Methods

        private void Awake()
        {
            levelBuilder = FindObjectOfType<LevelBuilder>();
        }
        void Start()
        {
            Initilize();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ChangeDifficulty();
        }
        #endregion
        // Start is called before the first frame update
        #region Main Methods
        public void Initilize() 
        {
            Debug.Log("Initializing Difficulty Level...");
            elapsedTimeToChangeDifficulty = timeToChangeDifficulty;
            Debug.Log("Setting time to change difficulty: " + elapsedTimeToChangeDifficulty);
            Gravity = 1f;
            Debug.Log("Setting gravity to: " + Gravity);
            TimeBetweenWaves = 4;
            Debug.Log("Setting intial time between waves: " + TimeBetweenWaves);
        }
        public void ChangeDifficulty() 
        {
            elapsedTimeToChangeDifficulty -= Time.deltaTime;

            if (elapsedTimeToChangeDifficulty <= 0) 
            { 
                DifficultyLevel++;
                Gravity *= 1 + difficultyMultiplier;
                TimeBetweenWaves -= TimeBetweenWaves * difficultyMultiplier;
                elapsedTimeToChangeDifficulty = timeToChangeDifficulty;

                if (DifficultyLevel % 5 == 0) 
                {
                    spawningDensity *= difficultyMultiplier;
                }

                OnDifficultyChange.Invoke();
            }
        }

        public void SetIntialDifficulty(int _difficultyLevel) 
        {
            DifficultyLevel = _difficultyLevel;
        }

        public void Reset() 
        {
            DifficultyLevel = 1;
            Gravity = 1f;
            TimeBetweenWaves = 1;
        } 
        #endregion

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SquareManShootTetris 
{
    //SetTimeUntilNextWave 
    //CountDown to next wave V
    //Choose Active Spawners
    //Intitialize Next Wave
        //ChooseSpawneablesInWave
            //Get Blocks Weights
            //Select Type for each spawneable
            //
    //Call Next Wave
    public class SpawningManager : MonoBehaviour
    {
        #region Dependencies
        [Header("Dependencies")]
        public LevelBuilder levelBuilder;
        public GridBuilder grid;
        public Statistics statistics;
        public DifficultyManager difficultyManager;
        #endregion
        #region Public Variables
        [Header("Settings")]
        public bool isActive;
        public GameObject spawneable;
        public List<ISpawneable> spawneables;
        #endregion


        #region Private Variables
        private float elapsedTime;
        #endregion

        #region Properties

        public bool IsActive => isActive;
        #endregion

        #region Public Events
        [Space(10)]
        [Header("Events")]
        public UnityEvent OnCallSpawners = new UnityEvent();
        #endregion

        // Start is called before the first frame update
        private void Awake()
        {
            spawneables = new List<ISpawneable>();
        }
        void Start()
        {
            difficultyManager = FindObjectOfType<DifficultyManager>();
            statistics = FindObjectOfType<Statistics>();
            levelBuilder = FindObjectOfType<LevelBuilder>();
            grid = FindObjectOfType<GridBuilder>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsActive) 
            { 
                WaveCoolDown();
            }
        }

        private bool WaveCoolDown() 
        {
            if (elapsedTime >= difficultyManager.TimeBetweenWaves)
            {
                elapsedTime = 0;
                SetSpawnersOff();
                ChooseActiveSpawners();
                OnCallSpawners.Invoke();
                statistics.IncreaseNumOfWaves();
                Debug.Log("Reset Cool Down at: " + elapsedTime + " | Times: " + statistics.NumOfWaves);
                return true;
            }
            else 
            {
                elapsedTime += Time.deltaTime;
               
                //Debug.Log("Elapsed Time: " + elapsedTime);
                return false;
            }
        }
        

        /// <summary>
        /// Choose how many spawner will be active in the next wave
        /// </summary>
        private List<Spawner> ChooseActiveSpawners() 
        {
            Debug.Log("Choosing Spawners...");
                       
            //Get Density
            int density = difficultyManager.Density; //We need to activate as many Spawner as the density number is.
            
            //Save Active Tiles
            List<Spawner> activeSpawners = new List<Spawner>();

            for (int i = 0; i < density; i++) 
            {
                
                bool contains = true;

                while (contains)
                {
                    //We get a random index to choose a spawner from the SourceGrid.
                    int randIndex = Random.Range(0, grid.SourceGrid.Count -1);

                    //Check if random tile is in memoTiles
                    contains = activeSpawners.Contains(grid.SourceGrid[randIndex].GetComponent<Spawner>());

                    if (!contains)
                    {
                        Spawner spawner = grid.SourceGrid[randIndex].GetComponent<Spawner>();
                        spawner.IsActive = true;
                        spawner.Init(this);
                        spawner.LoadSpawner(spawneable.GetComponent<ISpawneable>());
                        activeSpawners.Add(grid.SourceGrid[randIndex].GetComponent<Spawner>());
                        break;
                    }


                }

            }

            Debug.Log(activeSpawners.Count + " spawners have been activated");
            return activeSpawners ;

        }

        private void SetSpawnersOff() 
        {
            Debug.Log("Desactivating Spawners...");
            foreach (Tile tile in grid.SourceGrid) 
            {
                tile.GetComponent<Spawner>().IsActive = false;
            }
        }
    }

}

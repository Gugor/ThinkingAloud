using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{ 
    public class LevelBuilder : MonoBehaviour
    {
        #region Public Dependencies
        [Header("Dependencies")]
        public GridBuilder sourceGrid;
        public GridBuilder groundGrid;
        public SpawningManager spawningManager;
        public DifficultyManager difficultyManager;
        #endregion

        #region Public Variables
        [Header("Settings")]
        public GameObject sourceTilePrefab;
        public GameObject groundTilePrefab;

        public Vector2 gridSize = new Vector2(4,1);
        #endregion

        #region Private Variables
 
        #endregion

        #region Properties
        
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            
            Debug.Log("Creating source grid...");
            sourceGrid.spawningManager = spawningManager;
            sourceGrid.Initialize(gridSize, sourceTilePrefab);
            sourceGrid.Build();

            Debug.Log("Creating ground grid...");
            groundGrid.Initialize(gridSize, groundTilePrefab);
            groundGrid.Build();
        }

  

    }
    
}

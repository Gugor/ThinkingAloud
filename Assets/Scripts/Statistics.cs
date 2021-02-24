using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{ 
   
    public class Statistics : MonoBehaviour
    {
        public float Accuracy { get => (NumShots / SpawnedBlocks) * 100; }
        public int SpawnedBlocks { get; private set; }
        public int NumShots { get; private set; }
        public int NumOfWaves { get; private set; }
    
        public void IncreaseNumSpawnedBlocks() 
        {
            SpawnedBlocks++;
        }

        public void IncreaseNumShots ()
        {
            NumShots++;
        }

        public void IncreaseNumOfWaves()
        {
            NumOfWaves++;
        }

        public void Reset()
        {
            SpawnedBlocks = 0;
            NumShots = 0;
        }
    }
}

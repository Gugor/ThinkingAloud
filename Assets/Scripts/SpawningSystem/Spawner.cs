using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{
    public class Spawner : MonoBehaviour
    {
        #region Dependencies
        public Statistics statistics;
        private SpawningManager spawningManager;
        private SpawneablesHandeler spawneablesHandeler;

        #endregion

        #region Public Varaibles
        [Header("Info")]
        public int NumOfSapwned;
        public bool IsActive;
        //[HideInInspector] public List<ISpawneable> SpawneablesSpawned;
        #endregion

        #region Private Variables
        private ISpawneable spawneable;
        #endregion

        #region Properties
        public SpawningManager SpawningManager => spawningManager;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            statistics = FindObjectOfType<Statistics>();
            spawningManager = FindObjectOfType<SpawningManager>();
            spawneablesHandeler = FindObjectOfType<SpawneablesHandeler>();
        }
        #endregion
        public void Init(SpawningManager _spawningManager) 
        {
            spawningManager = _spawningManager;

            if (spawningManager != null)
            {
                 spawningManager.OnCallSpawners.AddListener(Spawn);
            }
        }
        public void LoadSpawner(ISpawneable _spawneable) 
        {
            spawneable = _spawneable;
        }

        public void Spawn() 
        {
            if (IsActive) 
            {
                GameObject go = Instantiate(spawneable.IGameObject);
                go.transform.position = new Vector3(transform.position.x, transform.position.y - spawneable.ITransform.position.y, transform.position.z);
                go.transform.rotation = Quaternion.identity;
                go.transform.SetParent(transform);
                go.GetComponent<AbstractBlock>().Initialize(spawningManager);
                spawneablesHandeler.AddSpawneable(go.GetComponent<ISpawneable>(), SpawneableTpye.BLOCKS);
                Debug.Log(go.name + "added to Spawned Blocks list. Num of spaneables: " + spawneablesHandeler.getSpawnedItemsFrom(SpawneableTpye.BLOCKS));
                //Debug.Log(name + " spawns " + go.name);
                NumOfSapwned++;
                statistics.IncreaseNumSpawnedBlocks();
                //SpawneablesSpawned.Add(go.GetComponent<ISpawneable>());
            }

        }
    }

}

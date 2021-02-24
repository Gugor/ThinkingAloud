using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris
{
    public enum SpawneableTpye { BLOCKS, INSPIRATIONS }
    public class SpawneablesHandeler : MonoBehaviour
    {
        #region Private Variables
        private Dictionary<SpawneableTpye, List<ISpawneable>> spawneablesSpawnedList;

        #endregion

        private void Awake()
        {
            
            Initialize();
        }

        private void Initialize() 
        {
            List<ISpawneable> spawnedBlocks = new List<ISpawneable>();

            if (spawneablesSpawnedList != null) 
            { 
                spawneablesSpawnedList.Add(SpawneableTpye.BLOCKS, spawnedBlocks);
                Debug.Log(spawneablesSpawnedList + "=>" + spawneablesSpawnedList.Keys);
                List<ISpawneable> spawnedInspirations = new List<ISpawneable>();
                spawneablesSpawnedList.Add(SpawneableTpye.BLOCKS, spawnedInspirations);
                Debug.Log(spawneablesSpawnedList + "=>" + spawneablesSpawnedList.Keys);
            }
        }
        /// <summary>
        /// Retrieve a list of spawneables of given type.
        /// </summary>
        /// <param name="type">SpawneableType: The type of the list to retrieve</param>
        /// <returns></returns>
        public List<ISpawneable> getSpawnedItemsFrom(SpawneableTpye type) 
        {

            return spawneablesSpawnedList?[type];
        }

        /// <summary>
        /// Add ISpawneable to a specific list of SpawneableType. (Ej: sh.AddSpawneable(spawneable, SpawneableTpye.BLOCKS)
        /// </summary>
        /// <param name="spawneable">ISpawneable: The spawneable element to add</param>
        /// <param name="type">SpawneableType: The list to add the given ISpawneable</param>
        public void AddSpawneable(ISpawneable spawneable, SpawneableTpye type) 
        {
            if (spawneablesSpawnedList != null && spawneablesSpawnedList.ContainsKey(type)) 
            { 
                spawneablesSpawnedList[type].Add(spawneable);
            }
        }
        /// <summary>
        /// Remove a ISpawneable from a specified list of SpawneableType. (Ej: sh.RemoveRemove(spawneable, SpawneableTpye.BLOCKS)
        /// </summary>
        /// <param name="spawneable"></param>
        /// <param name="type"></param>
        public void RemoveRemove(ISpawneable spawneable, SpawneableTpye type) 
        {
            if (spawneablesSpawnedList != null && spawneablesSpawnedList.ContainsKey(type))
            {
                if (spawneablesSpawnedList[type].Contains(spawneable))
                {
                    spawneablesSpawnedList[type].Remove(spawneable);
                }
            }
        }


    }
}

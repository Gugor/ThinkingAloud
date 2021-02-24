using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris 
{
    public class GridBuilder : MonoBehaviour
    {
        #region Dependencies
        private GameObject tilePrefab;
        public SpawningManager spawningManager; //It gets instantiated in LevelBuilder
        #endregion
        #region Public Variables
        [HideInInspector] public Vector2 size;
        #endregion
        #region Private Variables
        private List<Tile> sourceGrid;
        private Vector2 gridOrigin = Vector3.zero;
        #endregion

        #region Properties
        public List<Tile> SourceGrid => sourceGrid;
        #endregion

        #region Main Methods
        public void Initialize(Vector2 _size, GameObject _tilePrefab) 
        {
            size = _size;
            tilePrefab = _tilePrefab;
            sourceGrid = new List<Tile>();
        }
        public void Build() 
        {
            Debug.Log("Building Grid...");
            //wE ASIGN TO THE PARENT OBJECT THE SIZE OF THE TILE GRID
            setParentScaleToGridScale();

            for (int row = 0; row < size.y; row++) 
            {
                for (int col = 0; col < size.x; col++) 
                {
                    
                    gridOrigin = new Vector2(col, row);
                    GameObject go = Instantiate(tilePrefab, new Vector3(gridOrigin.x, transform.position.y, gridOrigin.y), Quaternion.identity);
                    go.transform.SetParent(transform);
                    go.name = "Spawner " + (row + 1).ToString() + "_" + (col + 1).ToString() + " " + go.transform.position;
           
                    sourceGrid.Add(go.GetComponent<Tile>());


                }
            }

            CenterGridTo00();
        }

        private void setParentScaleToGridScale() 
        { 
            transform.localScale = new Vector3(size.x, tilePrefab.transform.lossyScale.y ,size.y);
        }
        private void CenterGridTo00() 
        { 
            transform.position = new Vector3(transform.position.x -( transform.localScale.x / 2), transform.position.y,transform.position.z - (transform.localScale.z / 2));
        }
        #endregion
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        }
#endif
    }

}

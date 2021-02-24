using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRenderer : MonoBehaviour
{
    #region Dependencies 
    public LayerMask noBlockingLayers;
    public Transform origin;
    public Transform source; //This is the top grid witch spawn the blocks.
    #endregion
    #region Private Variables
    private LineRenderer lineRenderer;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = origin.gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //We detect if there is somthing above the player
        float yEndPos = DetectDestructables();
        
        //We render a line up. 
        DrawAimingLine(origin.position, new Vector3(origin.position.x, yEndPos, origin.position.z));
        
    }

    /// <summary>
    /// Detects if there is an object above the player.
    /// </summary>
    /// <returns>float: Y position of the blocking objects</returns>
    private float DetectDestructables() 
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(origin.position, origin.up, out hitInfo, noBlockingLayers))
        {
            Debug.Log(hitInfo.collider.name + " is in aim.");
            return hitInfo.collider.transform.position.y;
        }
        else 
        {
            Debug.Log( "No block is in aim.");
            return source.position.y;
        }
    }
    /// <summary>
    /// Draws a line from the origin point to the end point.
    /// </summary>
    /// <param name="originPos">Vector3: position where the line begins</param>
    /// <param name="endPos">Vector3: position where the line ends</param>
    private void DrawAimingLine(Vector3 originPos, Vector3 endPos) 
    {
        Vector3[] positions = { originPos, endPos };
        
        
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        lineRenderer.SetPositions(positions);
        
    }
}

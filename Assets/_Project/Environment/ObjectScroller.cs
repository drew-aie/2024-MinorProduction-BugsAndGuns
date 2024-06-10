using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will scroll its child objects at a given speed along the positive z axis,
///   wrapping them around to the beginning when they have gone over the end.
/// 
/// The length of the scroll area is determined by the combined lengths of each child object's renderer,
///   and as such will not function if there are gaps between the objects. 
///   
/// Be precise with your positioning!
/// </summary>
public class ObjectScroller : MonoBehaviour
{
    [SerializeField, Range(0, 5), Tooltip("How quickly children should move relative to this object")]
    private float _scrollSpeed = 1;

    private List<Transform> _children = new List<Transform>();
    private float _maxDistance;

    private void Start()
    {
        float combinedLength = 0;
        // Add all children to list
        for (int i = 0; i < transform.childCount; i++)
        {
            _children.Add(transform.GetChild(i));
            // Add child renderer extents to combinedLength
            if (transform.GetChild(i).TryGetComponent(out Terrain terrain))
                combinedLength += terrain.terrainData.size.z;
        }
        _maxDistance = combinedLength;
    }

    private void Update()
    {
        foreach (Transform item in _children)
        {
            // Update item position
            item.localPosition += new Vector3(0, 0, _scrollSpeed) * Time.deltaTime;

            // If item has gone below _maxDistance, reset it to the top
            if (item.localPosition.z > _maxDistance)
            {
                Vector3 newPosition = item.localPosition;
                // We subtract _maxDistance rather than setting it to transform.position.z
                //   to preserve the small fraction that it has gone over the edge.
                // This prevents a gap from forming between objects.
                newPosition.z -= _maxDistance;
                item.localPosition = newPosition;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 end = transform.position + new Vector3(0, 0, _maxDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 10f);
        Gizmos.DrawLine(transform.position, end);
        Gizmos.DrawSphere(end, 0.1f);
    }
}

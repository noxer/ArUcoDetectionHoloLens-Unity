using System.Collections.Generic;
using UnityEngine;

public class MarkerSpawner : MonoBehaviour
{
    public GameObject MarkerPrefab;
    public float MarkerPrefabScale = 0.08f;

    private List<GameObject> markers;

    // Start is called before the first frame update
    private void Start()
    {
        // Log a warning if the MarkerPrefab has not been set
        if (MarkerPrefab == null)
            Debug.LogWarning($"Missing MarkerPrefab for the MarkerSpawner on {gameObject.name}!");
    }

    public void AddMarker(int id, Vector3 position, Quaternion rotation)
    {
        // Make sure the marker list has been instantiated
        if (markers == null)
            markers = new List<GameObject>();

        // Instantiate the marker prefab and scale it
        var marker = Instantiate(MarkerPrefab, position, rotation);
        marker.transform.localScale = Vector3.one * MarkerPrefabScale;

        // Add the prefab to the list
        markers.Add(marker);
    }

    public void RemoveMarkers()
    {
        // A null list is always empty
        if (markers == null)
            return;

        // Destroy each marker and clear the list
        foreach (var marker in markers)
        {
            Destroy(marker);
        }

        markers.Clear();
    }
}

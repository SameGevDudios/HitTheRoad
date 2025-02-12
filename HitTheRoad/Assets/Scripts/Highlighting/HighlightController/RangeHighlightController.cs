using UnityEngine;

public class RangeHighlightController : IHighlightController
{
    private Transform _searchTransform;
    private float _searchRadius;
    private bool _pickupFound;

    public RangeHighlightController(Transform searchTransform, float searchRadius)
    {
        _searchTransform = searchTransform;
        _searchRadius = searchRadius;
    }
    public void Search()
    {
        Collider[] col = Physics.OverlapSphere(_searchTransform.position, _searchRadius);
        _pickupFound = col.Length > 0;
        Highlight(col);
    }
    private void Highlight(Collider[] col)
    {
        foreach (Collider c in col)
            c.GetComponent<IHighlighter>().Highlight();
    }
    public bool PickupInRange() =>
        _pickupFound;
}

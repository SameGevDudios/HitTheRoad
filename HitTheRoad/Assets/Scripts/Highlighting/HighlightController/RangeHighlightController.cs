using UnityEngine;

public class RangeHighlightController : IHighlightController
{
    private Transform _searchTransform;
    private float _searchRadius;
    private bool _pickupFound;
    private LayerMask _searchMask;

    public RangeHighlightController(Transform searchTransform, float searchRadius, LayerMask searchMask)
    {
        _searchTransform = searchTransform;
        _searchRadius = searchRadius;
        _searchMask = searchMask;
    }
    public void SearchForPickups()
    {
        float radiusOffset = 0.1f;
        Collider[] colliderOutside = Physics.OverlapSphere(_searchTransform.position, _searchRadius + radiusOffset, _searchMask);
        Collider[] colliderInside = Physics.OverlapSphere(_searchTransform.position, _searchRadius, _searchMask);
        _pickupFound = colliderInside.Length > 0;
        Highlight(colliderOutside, false); // Lowlight pickups outside (but not too far) of search radius
        Highlight(colliderInside, true); // hightlights pickups inside search radius
    }
    private void Highlight(Collider[] col, bool inRange)
    {
        foreach (Collider c in col)
            c.GetComponent<IHighlighter>().Highlight(inRange);
    }
    public bool PickupInRange() =>
        _pickupFound;
}

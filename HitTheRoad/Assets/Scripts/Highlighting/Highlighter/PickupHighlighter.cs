using UnityEngine;

public class PickupHighlighter : MonoBehaviour, IHighlighter
{
    [SerializeField] Outline _outline;
    [SerializeField] private Color _inRangeColor, _outRangeColor;
    public void Highlight(bool inRange)
    {
        _outline.UpdateColor(inRange ? _inRangeColor : _outRangeColor);
    }
}

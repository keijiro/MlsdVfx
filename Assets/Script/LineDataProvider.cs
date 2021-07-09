using UnityEngine;
using UnityEngine.VFX;

sealed class LineDataProvider : MonoBehaviour
{
    [SerializeField] RenderTexture _source = null;
    [SerializeField, Range(0.001f, 1)] float _threshold = 0.1f;
    [SerializeField] Mlsd.ResourceSet _resources = null;

    Mlsd.LineSegmentDetector _detector;

    public Texture LineData => _detector.BakedTexture;
    public int MaxDetection => Mlsd.LineSegmentDetector.MaxDetection;

    void Start()
      => _detector = new Mlsd.LineSegmentDetector(_resources);

    void OnDestroy()
      => _detector.Dispose();

    void LateUpdate()
      => _detector.ProcessImage(_source, _threshold);
}

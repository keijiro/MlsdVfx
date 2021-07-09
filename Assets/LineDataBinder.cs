using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[VFXBinder("MLSD/Line Data")]
sealed class LineDataBinder : VFXBinderBase
{
    public string LineDataProperty
      { get => (string)_lineDataProperty;
        set => _lineDataProperty = value; }

    public string MaxCountProperty
      { get => (string)_maxCountProperty;
        set => _maxCountProperty = value; }

    [SerializeField, VFXPropertyBinding("UnityEngine.Texture2D")]
    ExposedProperty _lineDataProperty = "LineData";

    [SerializeField, VFXPropertyBinding("System.UInt32")]
    ExposedProperty _maxCountProperty = "MaxCount";

    public LineDataProvider Target = null;

    public override bool IsValid(VisualEffect component)
      => Target != null
       && component.HasTexture(_lineDataProperty)
       && component.HasUInt(_maxCountProperty);

    public override void UpdateBinding(VisualEffect component)
    {
        if (!Application.isPlaying) return;
        component.SetTexture(_lineDataProperty, Target.LineData);
        component.SetUInt(_maxCountProperty, (uint)Target.MaxDetection);
    }

    public override string ToString()
      => $"LineData : {_lineDataProperty} => {Target?.name}";
}

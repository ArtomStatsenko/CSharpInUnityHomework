using UnityEngine.UI;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class MakeRadarObject : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private void OnValidate()
        {
            _icon = Resources.Load<Image>("MiniMap/RadarObject");
        }

        private void OnEnable()
        {
            Radar.RegisterRadarObject(gameObject, _icon);
        }

        private void OnDisable()
        {
            Radar.RemoveRadarObject(gameObject);
        }

    }
}
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class Radar : MonoBehaviour
    {
        public static List<RadarObject> RadarObjects = new List<RadarObject>();

        private Transform _playerPosition;
        private readonly float _mapScale = 2f;

        private void Start()
        {
            _playerPosition = Camera.main.transform;
        }

        public static void RegisterRadarObject(GameObject obj, Image im)
        {
            Image image = Instantiate(im);
            RadarObjects.Add(new RadarObject { Owner = obj, Icon = image });
        }

        public static void RemoveRadarObject(GameObject obj)
        {
            List<RadarObject> newList = new List<RadarObject>();

            foreach (RadarObject radarObject in RadarObjects)
            {
                if (radarObject.Owner == obj)
                {
                    Destroy(radarObject.Icon);
                    continue;
                }
                newList.Add(radarObject);
            }
            RadarObjects.RemoveRange(0, RadarObjects.Count);
            RadarObjects.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            foreach (RadarObject radarObject in RadarObjects)
            {
                Vector3 radarPosition = (radarObject.Owner.transform.position -
                                    _playerPosition.position);
                float distToObject = Vector3.Distance(_playerPosition.position,
                                         radarObject.Owner.transform.position) * _mapScale;
                float deltay = Mathf.Atan2(radarPosition.x, radarPosition.z) * Mathf.Rad2Deg -
                               270 - _playerPosition.eulerAngles.y;
                radarPosition.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
                radarPosition.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
                radarObject.Icon.transform.SetParent(transform);
                radarObject.Icon.transform.position = new Vector3(radarPosition.x,
                                                        radarPosition.z, 0) + transform.position;
            }
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }
}
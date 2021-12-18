using UnityEditor;
using UnityEngine;


namespace ArtomStatsenko
{
    [CustomEditor(typeof(Player))]
    public sealed class PlayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();

            Player player = (Player)target;

            GUILayout.Label("Speed");
            player.Speed = EditorGUILayout.Slider(player.Speed, 0.5f, 5.0f);
            GUILayout.Label("Acceleration Ratio");
            player.AccelerationRatio = 
                EditorGUILayout.Slider(player.AccelerationRatio, 0.5f, 2.0f);
            GUILayout.Label("Deceleration Ratio");
            player.DecelerationRatio =
                EditorGUILayout.Slider(player.DecelerationRatio, 0.5f, 2.0f);
        }
    }
}

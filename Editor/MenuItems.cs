using UnityEditor;


namespace ArtomStatsenko
{
    public sealed class MenuItems
    {
        [MenuItem("MyMenuItems/FirstItem %#j")]
        private static void FirstMenuOption()
        {
            EditorWindow.GetWindow(typeof(NewWindow), false, "New Window");
        }
    }
}

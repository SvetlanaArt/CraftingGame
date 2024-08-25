using UnityEngine;
using UnityEditor;
using CraftingModule.Items;

namespace CraftingModule.Editor
{

#if UNITY_EDITOR
    /// <summary>
    /// Allow configurating items and crafting options 
    /// </summary>
    public class ItemEditor : AbstractConfigEditor<Item>
    {
        const string DEFAULT_PATH = "Assets/Game/Items";
        const string DEFAULT_NAME = "NewItem";

        private string savePath = DEFAULT_PATH;
        private string configName = DEFAULT_NAME;

        protected override string SavePath { get => savePath; set => savePath = value; }
        protected override string ConfigName { get => configName; set => configName = value; }

        [MenuItem("GameEditor/ItemConfig")]
        private static void ShowWindow()
        {
            var window = GetWindow<ItemEditor>();

            window.titleContent = new GUIContent("Items Configuration");
            window.Show();
        }
     
    }
#endif

}




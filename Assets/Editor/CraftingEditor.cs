using UnityEngine;
using UnityEditor;
using CraftingModule.Crafting;


namespace CraftingModule.Editor
{

#if UNITY_EDITOR
    /// <summary>
    /// Allow configurating items and crafting options 
    /// </summary>
    public class CraftingEditor : AbstractConfigEditor<CraftingConfig>
    {
        const string DEFAULT_PATH = "Assets/Game/Crafting";
        const string DEFAULT_NAME = "NewCraftConfig";

        private string savePath = DEFAULT_PATH;
        private string configName = DEFAULT_NAME;

        protected override string SavePath {get => savePath; set => savePath = value;}
        protected override string ConfigName { get => configName; set => configName = value; }

        private static CraftingConfig staticCraftingConfig;

        [MenuItem("GameEditor/CraftingConfig")]
        private static void ShowWindow()
        {
            var window = GetWindow<CraftingEditor>();

            window.titleContent = new GUIContent("Crafting Configuration");
            window.Show();
        }

        protected override void ShowPropertiesFromConfigObject()
        {
            staticCraftingConfig = configObject;
            base.ShowPropertiesFromConfigObject();
        }

        public static CraftingConfig GetCraftingConfig()
        {
            return staticCraftingConfig;
        }
    }
#endif

}



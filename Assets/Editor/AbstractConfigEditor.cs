using UnityEditor;
using UnityEngine;

namespace CraftingModule.Editor
{

#if UNITY_EDITOR

    /// <summary>
    /// Abstract class for custom editor window to configure ScriptableObject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractConfigEditor<T> : EditorWindow where T : ScriptableObject
    {

        protected T configObject;
        protected T prevConfigObject;
        protected SerializedObject serializedConfig;
        protected SerializedProperty serializedProperty;

        protected abstract string SavePath { get; set; }
        protected abstract string ConfigName { get; set; }
        protected static string windowTitle = "";

        private Vector2 scrollPosition = Vector2.zero;

        protected virtual void OnGUI()
        {
            ConfigName = EditorGUILayout.TextField("Config Name", ConfigName);
            SavePath = EditorGUILayout.TextField("Save Path", SavePath);

            if (GUILayout.Button("Create new config"))
            {
                CreateConfig();
            }

            GUILayout.Space(20);
            configObject = (T)EditorGUILayout.ObjectField(
                                    "Selected config", configObject, typeof(T), false);

            GUILayout.Space(10);

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            ShowPropertiesFromConfigObject();

            EditorGUILayout.EndScrollView();

        }

        private void CreateConfig()
        {
            if (SavePath.Equals("") || !AssetDatabase.IsValidFolder(SavePath))
            {
                AssetDatabase.CreateFolder("Assets", SavePath.Substring(SavePath.IndexOf('/') + 1));
            }
            configObject = ScriptableObject.CreateInstance<T>();
            string assetPath = AssetDatabase.GenerateUniqueAssetPath($"{SavePath}/{ConfigName}.asset");

            AssetDatabase.CreateAsset(configObject, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        protected virtual void ShowPropertiesFromConfigObject()
        {
            if (prevConfigObject != configObject)
            {
                prevConfigObject = configObject;
                if (configObject != null)
                {
                    serializedConfig = new SerializedObject(configObject);
                }
            }

            if (configObject != null && serializedConfig != null)
            {
                serializedConfig.Update();

                SerializedProperty property = serializedConfig.GetIterator();
                property.NextVisible(true);

                while (property.NextVisible(false))
                {
                    if (property != null)
                        EditorGUILayout.PropertyField(property, true);
                }

                serializedConfig.ApplyModifiedProperties();
            }

        }

    }
#endif
}


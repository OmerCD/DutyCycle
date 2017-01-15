using System;
using UnityEditor;
using UnityEngine;
public class SystemEditor : EditorWindow
{
    private static readonly float WINDOWS_MIN_HEIGHT = 200;
    private static readonly float WINDOWS_MIN_WIDTH = 300;
    private LanguageManager memberManager;
    private int memberIndex;
    [MenuItem("Window/Language Editor")]
    public static void GetWindows()
    {
        SystemEditor window = GetWindow<SystemEditor>("Language Editor", true);
        window.minSize = new Vector2(WINDOWS_MIN_WIDTH, WINDOWS_MIN_HEIGHT);
    }

    void OnEnable()
    {
        memberManager = LanguageManager.Load();
        memberIndex = 0;
    }
    void OnDisable() { memberManager.Save(); }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        if (memberManager.Translations.Count != 0)
        {
            EditorGUILayout.LabelField(string.Format("Translation {0} Out of {1}", memberIndex + 1, memberManager.Translations.Count));
            memberManager.Translations[memberIndex].Key = EditorGUILayout.TextField("Key : ", memberManager.Translations[memberIndex].Key);
            memberManager.Translations[memberIndex].English = EditorGUILayout.TextField("English : ", memberManager.Translations[memberIndex].English);
            memberManager.Translations[memberIndex].Turkish = EditorGUILayout.TextField("Turkish : ", memberManager.Translations[memberIndex].Turkish);
        }
        else
        {
            EditorGUILayout.LabelField("No Translations Found");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
        if (GUILayout.Button("New Entry"))
        {
            EditorGUI.FocusTextInControl(null);
            memberManager.AddTranslation(new Translation());
            memberIndex = memberManager.Translations.Count - 1;
            memberManager.Save();
        }
        if (GUILayout.Button("Delete Entry") && memberManager.Translations.Count != 0)
        {
            EditorGUI.FocusTextInControl(null);
            memberManager.Remove(memberIndex);
            memberIndex = Mathf.Clamp(memberIndex, 0, memberManager.Translations.Count - 1);
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
        if(GUILayout.Button("Previous Entry") && memberManager.Translations.Count != 0)
        {
            EditorGUI.FocusTextInControl(null);
            memberIndex = memberIndex == 0 ? 0 : memberIndex - 1;
        }
        if (GUILayout.Button("Next Entry") && memberManager.Translations.Count != 0)
        {
            EditorGUI.FocusTextInControl(null);
            memberIndex =
                memberIndex >=
                    memberManager.Translations.Count - 1 ? memberManager.Translations.Count - 1 : memberIndex + 1;
        }

        EditorGUILayout.EndHorizontal();
    }
}

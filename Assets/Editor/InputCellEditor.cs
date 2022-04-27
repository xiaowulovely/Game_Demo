using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputCellEditor : Editor
{
    private static string inputCellPath = "Assets/Resources/Prefabs/MyTools/CustomInputCell.prefab";
    [MenuItem("GameObject/MyTools/InputCell",priority =0)]
    public static void CreatInputCell()
    {
        GameObject inputCell_go = AssetDatabase.LoadAssetAtPath<GameObject>(inputCellPath);
        if(inputCell_go != null)
        {
            Instantiate(inputCell_go, Selection.activeTransform).name = "Input Cell";
        }
    }
}

using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Weapon))]
public class WeaponCustomEditor : Editor {

    void OnSceneGUI()
    {
        var weapon = target as Weapon;
        weapon.BulletSpawnPosition = Handles.PositionHandle(weapon.transform.position + weapon.BulletSpawnPosition, Quaternion.identity) - weapon.transform.position;
        if (GUI.changed)
        {
            EditorUtility.SetDirty (target);
        }
    }
}

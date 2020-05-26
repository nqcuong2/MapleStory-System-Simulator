using UnityEditor;

[CustomEditor(typeof(CustomButton))]
public class CustomButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Show default inspector property editor
        DrawDefaultInspector();
    }
}

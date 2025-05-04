using UnityEngine;

public class CheckVertexColors : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>()?.mesh;
        if (mesh != null)
        {
            if (mesh.colors != null && mesh.colors.Length > 0)
            {
                Debug.Log($"✅ Vertex Colors are present! Colors count: {mesh.colors.Length}");
            }
            else
            {
                Debug.LogWarning("⚠️ No Vertex Colors found on this mesh!");
            }
        }
        else
        {
            Debug.LogError("❌ No Mesh found on this GameObject.");
        }
    }
}

// Inspiriert von [Q https://youtu.be/_aeYq5BmDMg?t=585]

using UnityEngine;

public class LabyrinthSkript : MonoBehaviour
{
    public GameObject wallPrefab;

    public int mazeWidth = 5;

    public int mazeHeight = 5;

    public float wallHeight = 5f;

    public float wallThickness = 0.1f;

    public Color wallColor = Color.red;

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                // Platzierung der Wand an der Position (i, j)
                Vector3 wallPosition = new Vector3(i, wallHeight / 2, j);

                // Instanziierung der Wand
                GameObject wall = Instantiate(wallPrefab, wallPosition, Quaternion.identity);
                wall.transform.localScale = new Vector3(1f, wallHeight, wallThickness);

                // Setzt die Farbe der Wand
                SetWallColor(wall, wallColor);
            }
        }
    }

    void SetWallColor(GameObject wall, Color color)
    {
        Renderer wallRenderer = wall.GetComponent<Renderer>();

        if (wallRenderer != null)
        {
            Material wallMaterial = new Material(wallRenderer.material);
            wallMaterial.color = color;
            wallMaterial.SetFloat("_Mode", 2f);  // Setze den Rendermodus auf Fade
            wallMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            wallMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            wallMaterial.SetInt("_ZWrite", 0);
            wallMaterial.DisableKeyword("_ALPHATEST_ON");
            wallMaterial.EnableKeyword("_ALPHABLEND_ON");
            wallMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            wallMaterial.renderQueue = 3000;

            wallRenderer.material = wallMaterial;
        }
    }
}

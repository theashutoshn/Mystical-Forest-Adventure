using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class AtlasLoader : MonoBehaviour
{
    public TextAsset atlasFile;  // Assign the .txt file in the inspector
    public Texture2D textureAtlas;  // Assign the texture atlas in the inspector

    void Start()
    {
        if (atlasFile != null && textureAtlas != null)
        {
            ParseAtlasFile(atlasFile.text);
        }
        else
        {
            Debug.LogError("Atlas file or texture atlas is not assigned.");
        }
    }

    void ParseAtlasFile(string atlasText)
    {
        StringReader reader = new StringReader(atlasText);
        string line;
        List<Sprite> sprites = new List<Sprite>();

        while ((line = reader.ReadLine()) != null)
        {
            if (line.Trim().Length == 0 || line.Contains("size:") || line.Contains("format:"))
                continue; // Skip empty lines and non-sprite lines

            // Read sprite name
            string spriteName = line.Trim();
            line = reader.ReadLine();

            // Read position and size
            line = reader.ReadLine();
            string[] parts = line.Split(new char[] { ':', ',' });
            int x = int.Parse(parts[1].Trim());
            int y = int.Parse(parts[2].Trim());
            int width = int.Parse(parts[3].Trim());
            int height = int.Parse(parts[4].Trim());

            // Read offset (skip it)
            line = reader.ReadLine();

            // Read original size (skip it)
            line = reader.ReadLine();

            // Read index (skip it)
            line = reader.ReadLine();

            // Create a sprite
            Sprite sprite = Sprite.Create(textureAtlas, new Rect(x, textureAtlas.height - y - height, width, height), new Vector2(0.5f, 0.5f));
            sprite.name = spriteName;
            sprites.Add(sprite);
        }

        // Example: create a background GameObject and assign a sprite
        GameObject background = new GameObject("Background");
        SpriteRenderer renderer = background.AddComponent<SpriteRenderer>();
        renderer.sprite = sprites[0]; // Assign the first sprite as an example
    }
}

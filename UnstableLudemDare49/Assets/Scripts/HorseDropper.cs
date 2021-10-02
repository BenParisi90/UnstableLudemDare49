using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseDropper : MonoBehaviour
{
    public GameObject horsePrefab;
    public List<Texture> horseTextures;
    List<Material> horseMaterials;
    public int horseMaterialCount = 50;
    public Shader horseShader;
    public Transform horsePile;

    public List<Horse> horses;
    

    void Start()
    {
        horseMaterials = new List<Material>();
        for(int i = 0; i < horseMaterialCount; i ++)
        {
            Material newHorseMaterial = new Material(horseShader);
            newHorseMaterial.SetTexture("_Texture", horseTextures[Random.Range(0, horseTextures.Count)]);
            newHorseMaterial.SetTexture("_Pulse", horseTextures[Random.Range(0, horseTextures.Count)]);
            horseMaterials.Add(newHorseMaterial);
        }
    }

    void Update()
    {
        //spawn a horse when we click
        if(Input.GetMouseButtonDown(0))
        {
            Material horseMaterial = horseMaterials[Random.Range(0, horseMaterials.Count)];
            Material maineMaterial = horseMaterials[Random.Range(0, horseMaterials.Count)];
            Horse newHorse = Instantiate(horsePrefab, transform.position, Random.rotation, horsePile).GetComponent<Horse>();
            horses.Add(newHorse);

            foreach(Renderer renderer in newHorse.bodyRenderers)
            {
                renderer.sharedMaterial = horseMaterial;
            }
            foreach(Renderer renderer in newHorse.maineRenderers)
            {
                renderer.sharedMaterial = maineMaterial;
            }
        }
    }

    public float PileHeight()
    {
        float pileHeight = 0;
        foreach(Horse horse in horses)
        {
            pileHeight = Mathf.Max(pileHeight, horse.bodyRenderers[0].bounds.max.y);
        }
        return pileHeight;
    }
}

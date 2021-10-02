using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LayerMask mask;
    public Transform helecopter;

    public GameObject horsePrefab;

    private Vector3 helecopterStartPoint;

    public Transform cameraPivot;

    public List<Texture> horseTextures;
    public List<Material> horseMaterials;
    public int horseMaterialCount = 50;
    public Shader horseShader;

    void Start()
    {
        helecopterStartPoint = helecopter.transform.position;
        mask = LayerMask.GetMask("RaycastTarget");
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
        //move the helecopter
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit, float.PositiveInfinity, mask)) 
        {
            helecopter.transform.position = new Vector3(hit.point.x, helecopter.transform.position.y, hit.point.z);
            helecopter.transform.rotation = cameraPivot.rotation;
        }

        //spawn a horse when we click
        if(Input.GetMouseButtonDown(0))
        {
            Material horseMaterial = horseMaterials[Random.Range(0, horseMaterials.Count)];
            Material maineMaterial = horseMaterials[Random.Range(0, horseMaterials.Count)];
            Horse newHorse = Instantiate(horsePrefab, helecopter.position, Random.rotation).GetComponent<Horse>();
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
}

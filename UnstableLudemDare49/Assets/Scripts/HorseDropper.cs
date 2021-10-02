using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseDropper : MonoBehaviour
{
    public GameObject horsePrefab;
    public List<Texture> horseTextures;
    //List<Material> horseMaterials;
    int horseCount = 1000;
    public Shader horseShader;
    public Transform horsePile;
    public Transform horsePool;

    public List<Horse> horses;

    public float maxHeightThisRound = 0;
    public float currentPileHeight = 0;
    [SerializeField] Collider groundCollider;
    

    void Start()
    {
        for(int i = 0; i < horseCount; i ++)
        {
            Material bodyMaterial = new Material(horseShader);
            bodyMaterial.SetTexture("_Texture", horseTextures[Random.Range(0, horseTextures.Count)]);
            bodyMaterial.SetTexture("_Pulse", horseTextures[Random.Range(0, horseTextures.Count)]);
            Material maineMaterial = new Material(horseShader);
            maineMaterial.SetTexture("_Texture", horseTextures[Random.Range(0, horseTextures.Count)]);
            maineMaterial.SetTexture("_Pulse", horseTextures[Random.Range(0, horseTextures.Count)]);
            Horse newHorse = Instantiate(horsePrefab, Vector3.zero, Quaternion.identity, horsePool).GetComponent<Horse>();
            newHorse.groundCollider = groundCollider;
            horses.Add(newHorse);

            foreach(Renderer renderer in newHorse.bodyRenderers)
            {
                renderer.sharedMaterial = bodyMaterial;
            }
            foreach(Renderer renderer in newHorse.maineRenderers)
            {
                renderer.sharedMaterial = maineMaterial;
            }
        }
    }

    void Update()
    {
        if(!GameManager.gameActive)
        {
            return;
        }
        currentPileHeight = PileHeight();
        maxHeightThisRound = Mathf.Max(maxHeightThisRound, currentPileHeight);
        //spawn a horse when we click
        if(Input.GetMouseButtonDown(0))
        {
            //Horse newHorse = Instantiate(horsePrefab, transform.position, Random.rotation, horsePile).GetComponent<Horse>();
            Horse newHorse = GetNextHorse();
            newHorse.transform.position = transform.position;
            newHorse.transform.rotation = Random.rotation;
            newHorse.transform.parent = horsePile;
            newHorse.rigidbody.angularVelocity = Random.rotation.eulerAngles;
        }
    }

    float PileHeight()
    {
        float pileHeight = 0;
        foreach(Horse horse in horses)
        {
            if(!horse.touchedGround)
            {
                continue;
            }
            pileHeight = Mathf.Max(pileHeight, horse.bodyRenderers[0].bounds.max.y);
        }
        return pileHeight;
    }

    Horse GetNextHorse()
    {
        foreach(Horse horse in horses)
        {
            if(!horse.gameObject.activeInHierarchy)
            {
                return horse;
            }
        }
        return null;
    }

    public void ReturnAllHorses()
    {
        foreach(Horse horse in horses)
        {
            horse.transform.parent = horsePool;
            horse.ResetProperties();
        }
    }
}

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

    public List<Horse> allHorses;

    public float maxHeightThisRound = 0;
    public float currentPileHeight = 0;
    int horseSoundCount = 50;
    [SerializeField] List<AudioClip> horseDropClips;
    List<AudioSource> horseSounds;
    bool canPlayHorseSound = true;
    
    [SerializeField] AudioSource horseHitSound;
    [SerializeField] List<AudioClip> horseHitClips;
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
            newHorse.horseDropper = this;
            allHorses.Add(newHorse);

            foreach(Renderer renderer in newHorse.bodyRenderers)
            {
                renderer.sharedMaterial = bodyMaterial;
            }
            foreach(Renderer renderer in newHorse.maineRenderers)
            {
                renderer.sharedMaterial = maineMaterial;
            }
        }

        horseSounds = new List<AudioSource>();
        for(int i = 0; i < horseSoundCount; i ++)
        {
            GameObject newHorseSound = new GameObject();
            AudioSource newAudioSource = newHorseSound.AddComponent<AudioSource>();
            newAudioSource.clip = horseDropClips[Random.Range(0, horseDropClips.Count)];
            horseSounds.Add(newAudioSource);
            newHorseSound.transform.parent = transform;
        }
    }

    public void PlayHorseHitSound()
    {
        horseHitSound.clip = horseHitClips[Random.Range(0, horseDropClips.Count)];
        horseHitSound.Play();
    }

    void Update()
    {
        if(GameManager.gameState != GameState.GAMEPLAY)
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
            if(canPlayHorseSound)
            {
                horseSounds[Random.Range(0, horseSounds.Count)].Play();     
                StartCoroutine(HorseSoundCooldown());
            }
                       
        }
    }

    IEnumerator HorseSoundCooldown()
    {
        canPlayHorseSound = false;
        yield return new WaitForSeconds(.5f);
        canPlayHorseSound = true;
    }

    float PileHeight()
    {
        float pileHeight = 0;
        foreach(Horse horse in allHorses)
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
        foreach(Horse horse in allHorses)
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
        foreach(Horse horse in allHorses)
        {
            horse.transform.parent = horsePool;
            horse.ResetProperties();
        }
    }

    public void FreezeLiveHorses()
    {
        for(int i = 0; i < horsePile.childCount; i ++)
        {
            Horse horse = horsePile.GetChild(i).GetComponent<Horse>();
            horse.rigidbody.isKinematic = true;
        }
    }
}

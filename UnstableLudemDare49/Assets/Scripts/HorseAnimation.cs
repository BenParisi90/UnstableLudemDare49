using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAnimation : MonoBehaviour
{
    public List<Transform> horseParts;
    List<Vector3> horsePartTargetRotations;
    List<Vector3> horsePartStartRotations;
    List<float> horsePartAnimPercentages;
    List<float> horsePartAnimSpeeds;

    float horseAnimMinSpeed = .01f;
    float horseAnimMaxSpeed = .04f;

    float maxHorsePartRotation = .2f;

    void Start()
    {
        horsePartTargetRotations = new List<Vector3>();
        horsePartStartRotations = new List<Vector3>();
        horsePartAnimPercentages = new List<float>();
        horsePartAnimSpeeds = new List<float>();
        for(int i = 0; i < horseParts.Count; i ++)
        {
            horsePartStartRotations.Add(Vector3.zero);
            horsePartAnimSpeeds.Add(Random.Range(horseAnimMinSpeed, horseAnimMaxSpeed));
            horsePartTargetRotations.Add(new Vector3(RandomRot(),RandomRot(),RandomRot()));
            horsePartAnimPercentages.Add(0);
        }
    }

    void Update()
    {
        for(int i = 0; i < horseParts.Count; i ++)
        {
            Transform part = horseParts[i];
            Debug.Log(horsePartAnimPercentages[i] + ", " + horsePartAnimSpeeds[i]);
            horsePartAnimPercentages[i] += horsePartAnimSpeeds[i];
            if(horsePartAnimPercentages[i] >= 1)
            {
                horsePartStartRotations[i] = part.rotation.eulerAngles;
                horsePartAnimSpeeds[i] = Random.Range(horseAnimMinSpeed, horseAnimMaxSpeed);
                horsePartTargetRotations[i] = new Vector3(RandomRot(),RandomRot(),RandomRot());
                horsePartAnimPercentages[i] = 0;
            }
            part.rotation = Quaternion.Lerp(Quaternion.Euler(horsePartStartRotations[i]), Quaternion.Euler(horsePartTargetRotations[i]), horsePartAnimPercentages[i]);
        }
    }

    float RandomRot()
    {
        return Random.Range(horseAnimMinSpeed, horseAnimMaxSpeed);
    }
}

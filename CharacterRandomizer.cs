using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizer : MonoBehaviour
{
    public List<RandomGroup> groups;
    public bool keepCurrentModel = false;

    private void Start()
    {
        if (groups.Count == 0 || keepCurrentModel) return;

        foreach (RandomGroup group in groups) 
        {
            if (group.objects.Count == 0) return;

            for (int i = 0; i < group.objects.Count; i++)
            {
                if (group.objects[i].activeSelf)
                    group.objects[i].SetActive(false);
            }

            int random = UnityEngine.Random.Range(0,group.objects.Count);

            ActivateModelAt(group, random);

            if (group.objects[random].GetComponent<SkinnedMeshRenderer>() != null)
            {
                SkinnedMeshRenderer renderer = group.objects[random].GetComponent<SkinnedMeshRenderer>();

                UpdateBlendShape(renderer, 1, UnityEngine.Random.Range(0, 100));
                UpdateBlendShape(renderer, 4, UnityEngine.Random.Range(0, 100));
                UpdateBlendShape(renderer, 7, UnityEngine.Random.Range(0, 100));
            }
        }
    }

    private void ActivateModelAt(RandomGroup group,int modelIndex)
    {
        group.objects[modelIndex].SetActive(true);
    }

    private void UpdateBlendShape(SkinnedMeshRenderer mesh, int shape, int strength)
    {
        mesh.SetBlendShapeWeight(shape, strength);
    }
}

[Serializable]
public class RandomGroup
{
    public string string_name;
    public List<GameObject> objects;
}
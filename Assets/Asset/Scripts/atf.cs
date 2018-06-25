using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    [System.Serializable]
    public class ArtifactCurrency
    {
        public string name;
        public GameObject items;
    }

    public List<ArtifactCurrency> normalArtifact = new List<ArtifactCurrency>();
    public List<ArtifactCurrency> rareArtifact = new List<ArtifactCurrency>();
    public List<ArtifactCurrency> veryRareArtifact = new List<ArtifactCurrency>();
    public int normalRarity;
    public int rareRarity;
    public int veryRareRarity;

    public void calArtifact()
    {
        int calArtifactChance = Random.Range(0, 100);

        if (calArtifactChance <= normalRarity )
        {
            int randNum = Random.Range(0, normalArtifact.Count);
            Instantiate(normalArtifact[randNum].items, transform.position, Quaternion.identity);
        }
        else if (calArtifactChance > normalRarity && calArtifactChance <= veryRareRarity)
        {
            int randNum = Random.Range(0, rareArtifact.Count);
            Instantiate(rareArtifact[randNum].items, transform.position, Quaternion.identity);
        }
        else if(calArtifactChance > rareRarity && calArtifactChance <= veryRareRarity)
        {
            int randNum = Random.Range(0, veryRareArtifact.Count);
            Instantiate(veryRareArtifact[randNum].items, transform.position, Quaternion.identity);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class AssetProvider 
{

    public List<Card> LoadCardVariantsPrefabs()
    {
        List<Card> cardVariants = Resources.LoadAll<Card>(AssetPaths.CARD_VARIANTS).ToList();
        return cardVariants;
    }
    

    public GameObject Instantiate(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return GameObject.Instantiate(prefab);
    }
}
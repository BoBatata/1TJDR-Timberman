using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrunkPool : MonoBehaviour
{
    public static Action OnTrunkHitted;

    [SerializeField] private GameObject trunkPrebab;
    [SerializeField] private List<TrunkBase> activeTrunks;
    [SerializeField] private List<TrunkBase> pooledTrunks;

    private void Awake()
    {
        foreach(TrunkBase trunk in pooledTrunks) 
        { 
            trunk.gameObject.SetActive(false);
        }

        GameManager.instance.trunkPool = this;
    }


    private void RentTruck()
    {
        TrunkBase trunk;

        if (pooledTrunks.Count() < 1)
        {
            trunk = InstantiateTrunk();
        }
        else
        {
            int randoTrunk = Random.Range(0, pooledTrunks.Count());
            trunk = pooledTrunks[randoTrunk];
            pooledTrunks.Remove(trunk);
        }

        trunk.transform.position = new Vector2 (0, 6.6f);
        trunk.gameObject.SetActive(true);
        activeTrunks.Add(trunk);
    }
    public void TrunkHit()
    {
        TrunkBase hittedTrunk = activeTrunks.FirstOrDefault();

        hittedTrunk.TrunkHitted();
        ReturnTrunkToPool(hittedTrunk);
        RentTruck();
    }

    private void ReturnTrunkToPool(TrunkBase trunk)
    {
        trunk.gameObject.SetActive(false);
        activeTrunks.Remove(trunk);
        pooledTrunks.Add(trunk);
    }

    private TrunkBase InstantiateTrunk()
    {
        GameObject trunkObject = Instantiate(trunkPrebab);

        return trunkObject.GetComponent<TrunkBase>();
    }
}

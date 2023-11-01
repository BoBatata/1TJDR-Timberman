using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrunkPool : MonoBehaviour
{
    public static Action OnTrunkHitted;

    [SerializeField] private GameObject trunkPrebab;
    [SerializeField] private List<TrunkBase> activeTrunks;

    private List<TrunkBase> pooledTrunks;

    private void Awake()
    {
        pooledTrunks = new List<TrunkBase>();
    }

    private void TrunkHit()
    {
        TrunkBase hittedTrunk = activeTrunks[activeTrunks.Count - 1];

        hittedTrunk.TrunkHitted();
    }

    private void RentTruck()
    {
        TrunkBase trunk;

        if (pooledTrunks.FirstOrDefault() == null)
        {
            trunk = InstantiateTrunk();
        }
        else
        {
            trunk = pooledTrunks.FirstOrDefault();
            pooledTrunks.Remove(trunk);
        }

        trunk.gameObject.SetActive(true);
        activeTrunks.Add(trunk);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrunkBase : MonoBehaviour
{
    [SerializeField] private float moveOffSet;

    private void OnEnable()
    {
        TrunkPool.OnTrunkHitted += TrunkFall;
    }

    private void TrunkFall()
    {
        transform.position = new Vector2(x: 0, y:transform.position.y - moveOffSet);
    }

    public void TrunkHitted()
    {
        TrunkPool.OnTrunkHitted -= TrunkFall;
        TrunkPool.OnTrunkHitted?.Invoke();
    }
}

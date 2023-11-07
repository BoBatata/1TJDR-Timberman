using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public abstract class TrunkBase : MonoBehaviour
{
    [SerializeField] private float moveOffSet;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        TrunkPool.OnTrunkHitted += TrunkFall;
        int randoNum = Random.Range(0, 2);
        spriteRenderer.flipX = randoNum == 0;
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

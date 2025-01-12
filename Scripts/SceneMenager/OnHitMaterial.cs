using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitMaterial : MonoBehaviour
{
    [SerializeField] private Material onHitMaterial;
    private Material ogMaterial;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ogMaterial = spriteRenderer.material;
    }


   private IEnumerator ChangeMaterial()
    {
        spriteRenderer.material = onHitMaterial;

        yield return new WaitForSeconds(.1f);

        spriteRenderer.material = ogMaterial;


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarcaneController : MonoBehaviour
{
    public bool isChopped; // flag for whether sugarcane is chopped or not
    [SerializeField] GameObject chop;
    [SerializeField] GameObject collect;
    private SpriteRenderer _sr;

    [SerializeField] SugarcaneManager sugarcaneManager;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sugarcaneManager.isAllChopped()) // all sugarcane chopped
        {
            collect.SetActive(true);
        }
    }

    public void ChopSugarcane()
    {
        if (!isChopped)
        {
            isChopped = true;
            _sr.color = Color.black; // chopped

            chop.SetActive(false);

            // update sugarcane chopped HUD
            sugarcaneManager.incrementSugarcaneChopped();
        }
    }

    public void CollectSugarcane()
    {
        if (isChopped)
        {
            Destroy(gameObject);

            // update sugarcane collected HUD
            sugarcaneManager.incrementSugarcaneColl();
        }
    }

    public void BurnSugarcane()
    {
        Destroy(gameObject);

        // update sugarcane burned HUD
        sugarcaneManager.incrementSugarcaneBurned();
    }
}

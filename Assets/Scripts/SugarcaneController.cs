using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarcaneController : MonoBehaviour
{
    public bool isChopped; // flag for whether sugarcane is chopped or not
    [SerializeField] GameObject chop;
    [SerializeField] GameObject collect;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void ChopSugarcane()
    {
        if (!isChopped)
        {
            isChopped = true;
            _sr.color = Color.black; // chopped
            collect.SetActive(true);
            chop.SetActive(false);
        }
    }

    public void CollectSugarcane()
    {
        if (isChopped)
        {
            Destroy(gameObject);
        }
    }
}

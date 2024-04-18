using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarcaneController : MonoBehaviour
{
    public bool isChopped; // flag for whether sugarcane is chopped or not
    [SerializeField] GameObject Chop;
    [SerializeField] GameObject Collect;
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
            Collect.SetActive(true);
        }
    }

    public void CollectSugarcane()
    {
        if (isChopped)
        {
            Destroy(gameObject);
            Chop.SetActive(true);
        }
    }
}

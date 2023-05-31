using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dices : MonoBehaviour
{
    public List<SpriteRenderer> dices;
    [SerializeField] private Sprite[] spr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    List<int> data = new List<int>();

    public void GenerateData()
    {
        data.Clear();
        dices.ForEach(x =>
        {
            var randomColor = Random.Range(0, spr.Length);
            data.Add(randomColor);
            x.sprite = spr[randomColor];
        });
    }
}

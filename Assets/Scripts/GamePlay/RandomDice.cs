    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomDice : MonoBehaviour
{

    public List<SpriteRenderer> dices;

    [SerializeField] private Color[] colors;

    //public GameObject[] evenButtons;
    //public GameObject[] oddButtons;
    // vcl, 3 cái kia còn éo phải cái nút.
    public List<SpriteRenderer> oddButtons;
    public List<SpriteRenderer> evenButtons;

    //int w_count;
    //int r_count;

    // Start is called before the first frame update
    void Start()
    {
        //CheckColor();
        //dices = GameObject.FindGameObjectsWithTag("Dice");
    }
    /// <summary>
    /// Cái này là data đã random nhá
    /// </summary>
    List<int> data = new List<int>();

    /// <summary>
    /// Event chỉ call vào 1 method thôi, từ cái này call sang các method nhỏ khác
    /// </summary>
    public void OnClick()
    {
        // đầu tiên khởi tạo data
        // có mấy loại giá trị cho dice? Trắng với đỏ thôi đúng ko? Éo quan trọng. Quan trọng là nó sẽ là một giá trị trong array colors. Vậy data sẽ là index của color
        GenerateData();
        // check color
        // cơ bản là éo cần check color nữa vì đã có data rồi.
        // Ví dụ, cần lấy ra dice có màu là colors[0] (hay ở ngoài là màu trắng ấy), làm như thế này
        Debug.Log("Số dice có màu trắng là : " + data.Count(x => x == 0));
        // hoặc màu đỏ
        Debug.Log("Số dice có màu đỏ là : " + data.Count(x => x == 1));
        ChangeBGEvenOrOdd();
    }

    /// <summary>
    /// Method này bao gồm việc random data và set color cho dice
    /// Cho thêm màu xanh đỏ tím vàng vào nó cũng ăn nhé
    /// </summary>
    void GenerateData()
    {
        data.Clear();
        dices.ForEach(x =>
        {
            var randomColor = Random.Range(0, colors.Length);
            data.Add(randomColor);
            x.color = colors[randomColor];
        });
    }
    /// <summary>
    /// Show kết quả
    /// nếu chẵn thì 3 ô bên trái chuyển màu green, 3 ô phải blue và ngược lại
    /// </summary>
    void ChangeBGEvenOrOdd()
    {
        oddButtons.ForEach(x=>x.color = IsOdd ? Color.green : Color.blue);
        evenButtons.ForEach(x=>x.color = IsOdd ? Color.blue : Color.green);
    }

    /// <summary>
    /// Getter này trả về true nếu chẵn
    /// số dice luôn là số chẵn, check cả 2 màu làm éo gì?
    /// </summary>
    bool IsOdd => data.Count(x => x == 0) % 2 != 0;


    //public void ChangeColor()
    //{
    //    dices[0].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
    //    dices[1].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
    //    dices[2].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
    //    dices[3].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];

    //}

    //public void CheckColor()
    //{
    //    foreach (GameObject a in dices)
    //    {
    //        if (a.GetComponent<Renderer>().material.color == colors[0])
    //        {
    //            w_count++;
    //            Debug.Log(w_count);
    //            return;
    //        }
    //    }
    //}

    //public void ChangeBGEvenOrOdd()
    //{
    //    if (w_count % 2 == 0 && r_count % 2 == 0)
    //    {
    //        oddButtons[0].GetComponent<Renderer>().material.color = Color.blue;
    //        oddButtons[1].GetComponent<Renderer>().material.color = Color.blue;
    //        oddButtons[2].GetComponent<Renderer>().material.color = Color.blue;

    //        evenButtons[0].GetComponent<Renderer>().material.color = Color.green;
    //        evenButtons[1].GetComponent<Renderer>().material.color = Color.green;
    //        evenButtons[2].GetComponent<Renderer>().material.color = Color.green;
    //    }
    //    else if (w_count % 2 != 0 && r_count % 2 !=0  )
    //    {
    //        oddButtons[0].GetComponent<Renderer>().material.color = Color.green;
    //        oddButtons[1].GetComponent<Renderer>().material.color = Color.green;
    //        oddButtons[2].GetComponent<Renderer>().material.color = Color.green;

    //        evenButtons[0].GetComponent<Renderer>().material.color = Color.blue;
    //        evenButtons[1].GetComponent<Renderer>().material.color = Color.blue;
    //        evenButtons[2].GetComponent<Renderer>().material.color = Color.blue;
    //    }
    //}
}                //else if (w_count == 1 && w_count == 3)
                //{
                //    oddButtons[0].GetComponent<Renderer>().material.color = Color.green;
                //    oddButtons[1].GetComponent<Renderer>().material.color = Color.green;
                //    oddButtons[2].GetComponent<Renderer>().material.color = Color.green;

                //    evenButtons[0].GetComponent<Renderer>().material.color = Color.blue;
                //    evenButtons[1].GetComponent<Renderer>().material.color = Color.blue;
                //    evenButtons[2].GetComponent<Renderer>().material.color = Color.blue;
                //    Debug.Log(w_count + "White");
                //    return;
                //}
 

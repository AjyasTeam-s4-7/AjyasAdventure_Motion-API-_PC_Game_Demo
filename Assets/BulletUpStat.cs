using UnityEngine;
using UnityEngine.UI;

public class BulletUpStat : MonoBehaviour
{
    public Text item1up;
    public Text item2up;
    public Text item3up;
    public Text item4up;
    public Text item5up;
    public Text item6up;
    private int Count1;
    private int Count2;
    private int Count3;
    private int Count4;
    private int Count5;
    private int Count6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Count1 = PlayerPrefs.GetInt("ItemBullet1", 0);
        Count2 = PlayerPrefs.GetInt("ItemBullet2", 0);
        Count3 = PlayerPrefs.GetInt("ItemBullet3", 0);
        Count4 = PlayerPrefs.GetInt("ItemBullet4", 0);
        Count5 = PlayerPrefs.GetInt("ItemBullet5", 0);
        Count6 = PlayerPrefs.GetInt("ItemBullet6", 0);
        item1up.text = Count1 + "/14";
        item2up.text = Count2 + "/14";
        item3up.text = Count3 + "/14";
        item4up.text = Count4 + "/14";
        item5up.text = Count5 + "/14";
        item6up.text = Count6 + "/14";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

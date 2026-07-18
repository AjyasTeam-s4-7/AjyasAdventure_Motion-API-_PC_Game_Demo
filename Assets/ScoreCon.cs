using UnityEngine;
using UnityEngine.UI;

public class ScoreCon : MonoBehaviour
{
    public Text Score;
    private int Scr = 0;
    public static ScoreCon Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scr = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Score : " + Scr);
        Score.text = "Score : " + Scr;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Score", Scr);
    }
    public void Get_Score(int gscr)
    {
        Scr += gscr;
        Score.text = "Score : " + Scr;
    }
}

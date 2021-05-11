using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEvent : MonoBehaviour
{
    int ComboVum = 0, Score = 0;
    public bool b = false;
    public GameObject CollideObj;
    public Text ComboText, RatingText, MessageText, ScoreText;
    public AudioSource TouchAudio;
    public ParticleSystem TouchEffect;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (b)
            {
                TouchAudio.GetComponent<AudioSource>().Play();
                TouchEffect.Play();
                ComboVum++;
                SetText();
                CollideObj.transform.position = new Vector2(99999, 99999);
            }
            else {
                ComboVum = 0;
                ComboText.text = "";
                MessageText.text = "";
                RatingText.text = "Miss";
                RatingText.color = Color.white;
            }
            b = false;
        }
    }

    public class RatingObj
    {
        public RatingObj(string _RatingText, Color _RatingColor, int _Level)
        {
            this._RatingText = _RatingText;
            this._RatingColor = _RatingColor;
            this._Level = _Level;
        }
        public string _RatingText { get; set; }
        public Color _RatingColor { get; set; }
        public int _Level { get; set; }
    }

    public void SetText() {
        var distance = Vector2.Distance(this.transform.position, CollideObj.transform.position);
        var _RatingObj = new RatingObj("", Color.white, 0);
        if (distance >= 0 && distance < 0.1f)
            _RatingObj = new RatingObj("Perfect", Color.yellow, 10);
        else if (distance >= 0.1f && distance < 0.5f)
            _RatingObj = new RatingObj("Good", new Color32(128, 255, 128, 255), 5);
        else if (distance >= 0.5f && distance < 1f)
            _RatingObj = new RatingObj("Bad", Color.red, 1);
        Score += _RatingObj._Level;

        ComboText.text = ComboVum.ToString();
        MessageText.text = distance.ToString();
        ScoreText.text = Score.ToString();
        RatingText.color = _RatingObj._RatingColor;
        RatingText.text = _RatingObj._RatingText;
        RatingText.GetComponent<Animation>().Play();
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Circle")
        {
            b = true;
            CollideObj = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Circle")
        {
            b = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float _Time = 0f;
    public GameObject Circle;
    public Vector2 ClonePosition;
    List<MusicObj> MusicScore;
    int Index = 1;

    // Start is called before the first frame update
    void Start()
    {
        var ThisPosition = this.transform.position;
        ClonePosition = new Vector2(ThisPosition.x, ThisPosition.y);
        MusicScore = GetList();
    }

    // Update is called once per frame
    void Update()
    {
        _Time += Time.deltaTime;
        if (MusicScore.Count > Index &&
            _Time > MusicScore[Index]._Time) {
            print(_Time);
            GameObject temp = Instantiate(Circle, transform.position, new Quaternion(0,0,0,0));
            Destroy(temp, 4f);

            Index ++;
        }
    }

    public class MusicObj {
        public MusicObj(float _Time, string _Lyrics) {
            this._Time = _Time;
            this._Lyrics = _Lyrics;
        }
        public float _Time { get; set; }
        public string _Lyrics { get; set; }
    }

    public List<MusicObj> GetList()
    {
        var _MusicScore = new List<MusicObj>();
        var Min = 0f;
        var str = "";
        for (int i = 0; i < 100; i++)
        {
            str += Min + ",";
            Min = Random.Range(Min + .3f, Min + 1.5f);
            _MusicScore.Add(new MusicObj(Min, ""));
        }
        print(str);
        return _MusicScore;
    }
}

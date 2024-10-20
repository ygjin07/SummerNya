using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class QuizForm
{
    public string question;
    public string[] choices = new string[4];
    public int correct;

    public QuizForm(string q, string c1, string c2, string c3, string c4, int corr)
    {
        question = q;
        choices[0] = c1;
        choices[1] = c2;
        choices[2] = c3;
        choices[3] = c4;
        correct = corr;
    }
}

public class Quiz : MonoBehaviour
{
    public Text[] QuizText;
    public Image TimeImg;
    List<QuizForm> forms = new List<QuizForm>();
    int ans;
    float time = 5;
    bool isQuiz = false;
    int check_tick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isQuiz)
        {
            time -= Time.deltaTime;
            TimeImg.fillAmount = 1f / 5f * time;
            if (time <= check_tick)
            {
                check_tick--;
                QuizManager.QM.TimeSound.Play();
            }
            if (time <= 0)
            {
                isQuiz = false;
                StartCoroutine(QuizManager.QM.EndQuizProcess(false));
            }
        }
    }

    public void AddForms()
    {
        forms.Add(new QuizForm("여름마다 일어나는 전쟁은?", "매워", "더워", "차가워", "그리워", 2));
        forms.Add(new QuizForm("바닷가에서 해도 되는 욕은?", "목욕", "뉴욕", "식욕", "해수욕", 4));
        forms.Add(new QuizForm("태양이 잠에 들면?", "낮잠", "선잠", "해수면", "렘수면", 3));
        forms.Add(new QuizForm("갈매기가 좋아하는 패션은?", "끼룩", "시무룩", "벼룩", "얼룩", 1));
        forms.Add(new QuizForm("바다가 뜨거우면?", "열바다", "소리바다", "아나바다", "노인과바다", 1));
        forms.Add(new QuizForm("가장 공부를 잘 하는 물고기는?", "고등어", "목적어", "닥터피쉬", "미디어", 3));
        forms.Add(new QuizForm("마실 수 없지만 먹을 수 있는 물은? ", "나물", "선물", "준비물", "핵분열생성물", 1));
        forms.Add(new QuizForm("돌고래는 영어로 돌핀이다. 그렇다면 고래는 영어로 무엇일까?", "Whale", "핀", "그리핀", "엔돌핀", 2));
    }

    void SetQuizTime()
    {
        check_tick = 5;
        time = 5;
        isQuiz = true;
    }

    public void MakeQuiz()
    {
        if(forms.Count == 0)
        {
            AddForms();
        }

        int ran = Random.Range(0, forms.Count);
        QuizText[0].text = forms[ran].question;
        QuizText[1].text = forms[ran].choices[0];
        QuizText[2].text = forms[ran].choices[1];
        QuizText[3].text = forms[ran].choices[2];
        QuizText[4].text = forms[ran].choices[3];
        ans = forms[ran].correct;
        forms.RemoveAt(ran);
        SetQuizTime();
    }

    public void CheckAnswer(int a)
    {
        isQuiz = false;
        if(a == ans)
        {
            StartCoroutine(QuizManager.QM.EndQuizProcess(true));
            StartCoroutine(GameManager.GM.Accel(1.3f, 7f));
        }
        else
        {
            StartCoroutine(QuizManager.QM.EndQuizProcess(false));
        }
    }
}

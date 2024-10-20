using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Quiz QuizPanel;
    public static QuizManager QM;
    public GameObject ReadyObj, QuizObj, OObj, XObj, CountObj;
    public Text ReadyText, CountText;
    public AudioSource ReadySound, StartSound, OSound, XSound, TimeSound, CountSound, GoSound, ChangePhaseSound;
    public AudioClip[] PhaseClips;

    // Start is called before the first frame update
    void Start()
    {
        if(QM == null)
        {
            QM = this;
        }
        else
        {
            Destroy(this);
        }

        StartCoroutine(CheckPhase());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quiz()
    {
        StartCoroutine(StartQuizProcess());
    }

    public void NextPhase()
    {
        GameManager.GM.StartMove();
        StartCoroutine(CheckPhase());
        QuizPanel.gameObject.SetActive(false);
        GameManager.GM.ChangeMainSound(GameManager.GM.Phase);
        ChangePhaseSound.clip = PhaseClips[GameManager.GM.Phase];
        ChangePhaseSound.Play();
        GameManager.GM.p.SetCatSprite();
        GameManager.GM.p.CheckJumpTurtle();
    }

    public IEnumerator CheckPhase()
    {
        yield return new WaitForSeconds(60f);
        if(GameManager.GM.Phase == 3)
        {
            SceneManager.LoadScene("FinishScene");
        }
        Quiz();
        GameManager.GM.StopMove();
    }

    public IEnumerator StartQuizProcess()
    {
        QuizPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        ReadyObj.SetActive(true);
        ReadySound.Play();
        switch (GameManager.GM.Phase)
        {
            case 0:
                {
                    ReadyText.text = "Second Phase!";
                    break;
                }
            case 1:
                {
                    ReadyText.text = "Third Phase!";
                    break;
                }
            case 2:
                {
                    ReadyText.text = "Final Phase!";
                    break;
                }
        }

        yield return new WaitForSeconds(2f);
        ReadyObj.SetActive(false);
        QuizObj.SetActive(true);
        QuizPanel.MakeQuiz();
        StartSound.Play();
    }

    public IEnumerator EndQuizProcess(bool ans)
    {
        GameObject obj;
        QuizObj.SetActive(false);
        if (ans)
        {
            OSound.Play();
            obj = OObj;
        }
        else
        {
            XSound.Play();
            obj = XObj;
        }
        GameManager.GM.Phase++;
        obj.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj.SetActive(false);
        CountObj.SetActive(true);
        CountText.text = "3";
        CountSound.Play();
        yield return new WaitForSeconds(1f);
        CountText.text = "2";
        CountSound.Play();
        yield return new WaitForSeconds(1f);
        CountText.text = "1";
        CountSound.Play();
        yield return new WaitForSeconds(1f);
        CountText.text = "GO!";
        GoSound.Play();
        yield return new WaitForSeconds(1f);
        CountObj.SetActive(false);
        NextPhase();
    }
}

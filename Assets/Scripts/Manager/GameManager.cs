using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerAction p;
    public static GameManager GM;
    public GameObject GameOverPanel;
    public AudioSource GameOverSound, MainSound;
    public AudioClip[] MainClips;
    public float AddSpeed = 1.0f;
    public float stop_move = 1f;
    public int Phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(GM == null)
        {
            GM = this;
        }
        else
        {
            Destroy(this);
        }

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMainSound(int phase)
    {
        MainSound.clip = MainClips[phase];
        MainSound.Play();
    }

    public bool CheckDive()
    {
        if (p.GetDiveState() != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GameOVer()
    {
        GameOverPanel.SetActive(true);
        GameOverSound.Play();
        Time.timeScale = 0f;
    }

    public void StopMove()
    {
        stop_move = 0f;
    }

    public void StartMove()
    {
        stop_move = 1f;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Accel(float speed, float time)
    {
        AddSpeed = speed;
        yield return new WaitForSeconds(time);
        AddSpeed = 1f;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    [SerializeField] private Image spriteRenderer;
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.Completed;
    private bool canSkip = false;
    private float cooldown = 0f;
    private float maxCooldown = 2.0f;

    private enum State
    {
        Playing,
        Completed
    }

    void Update()
    {
        if(cooldown >= maxCooldown)
        {
            canSkip = true;
        } else if (cooldown < maxCooldown)
        {
            cooldown += Time.deltaTime;
            //print(cooldown);
        }
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        spriteRenderer.sprite = currentScene.sentences[sentenceIndex].visual;
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        return state == State.Completed;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        AudioManager.Instance.StopDialogue();
        AudioManager.Instance.PlayDialogue(currentScene.sentences[sentenceIndex].clip);
        barText.text = "";
        state = State.Playing;
        int wordIndex = 0;
        //cooldown = 0f;

        while (state != State.Completed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && canSkip)
            {
                //print("registering click");
                for (int i = wordIndex; i < (text.Length - wordIndex); i++)
                {
                    barText.text += text[i];
                    //print(i + " out of " + (text.Length - wordIndex - 2).ToString());
                }
                state = State.Completed;
                cooldown = 0f;
                canSkip = false;
                yield return new WaitForSeconds(0.1f);
                break;
            }

            barText.text += text[wordIndex];

            yield return new WaitForSeconds(0.05f);

            if (++wordIndex == text.Length)
            {
                state = State.Completed;
                break;
            }
        }
    }

    public int getIndex()
    {
        return sentenceIndex;
    }
}

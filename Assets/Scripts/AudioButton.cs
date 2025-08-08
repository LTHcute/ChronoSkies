using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Image spriteButton;

    private void Start()
    {
        SetButton();
    }

    public void OnButtonClick()
    {
        AudioManager.Instance.ToggleMute();
        AudioManager.Instance.PlayEffects(AudioManager.Instance.buttonClick);
        SetButton();
    }

    private void SetButton()
    {
        spriteButton.sprite = AudioManager.Instance.IsMuted() ? soundOffSprite : soundOnSprite;
    }
}

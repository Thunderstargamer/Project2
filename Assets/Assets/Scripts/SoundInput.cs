using UnityEngine;
using UnityEngine.InputSystem;

public class SoundInput : MonoBehaviour
{ 

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.upArrowKey.wasPressedThisFrame)
            AudioManager.Instance.ChangeMusicVolume(0.1f);

        if (kb.downArrowKey.wasPressedThisFrame)
            AudioManager.Instance.ChangeMusicVolume(-0.1f);
    }
}

using System;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    private Action<RandomBubble> _killAction;
    
    public void Init(Action<RandomBubble> killAction)
    {
        _killAction = killAction;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Bubble Wall"))
        {
            SoundManager.PlaySound(SoundType.BubbleBurst);
            _killAction(this);
        }
    }
}

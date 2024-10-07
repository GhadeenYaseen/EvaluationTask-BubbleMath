using System;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    private Action<RandomBubble> _killAction;
    private float _speed = 4;

    private void Start() 
    {
        _speed = UnityEngine.Random.Range(1f,3.5f);
    }

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

    private void Update() 
    {
        Vector3 vec3 = new(0, _speed * Time.deltaTime, 0f);
        transform.Translate(vec3);
    }
}

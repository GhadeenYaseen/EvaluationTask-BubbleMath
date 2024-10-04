using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    private Action<RandomBubble> _killAction;
    private TextMeshPro _numberText;
    private float _speed = 4;

    private void Start() 
    {
        _numberText = GetComponentInChildren<TextMeshPro>();
        _numberText.text = Mathf.FloorToInt(UnityEngine.Random.Range(0f, 10f)).ToString();

        _speed = UnityEngine.Random.Range(2f,5f);
    }

    public void Init(Action<RandomBubble> killAction)
    {
        _killAction = killAction;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Bubble Wall"))
        {
            _killAction(this);
            Debug.Log("wall collided");
        }
    }

    private void Update() 
    {
        Vector3 vec3 = new(0, _speed * Time.deltaTime, 0f);
        transform.Translate(vec3);
    }
}

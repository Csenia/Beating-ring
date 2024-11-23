using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnumationEnemy : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private List<RuntimeAnimatorController> _controls = new List<RuntimeAnimatorController>();

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}

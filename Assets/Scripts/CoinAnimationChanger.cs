using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinAnimationChanger : MonoBehaviour
{    
    private Animator animator;    
    private void Start()
    {
       animator = GetComponent<Animator>();
       animator.SetInteger("CoinColor", SceneManager.GetActiveScene().buildIndex);
    }
}

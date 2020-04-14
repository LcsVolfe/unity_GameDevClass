using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource _audioSource;
    public static AudioSource instance;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        instance = _audioSource;
    }
    
}

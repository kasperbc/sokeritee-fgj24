using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animation _animation;

    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        //_animation.Play("CameraAnimation");
    }
}

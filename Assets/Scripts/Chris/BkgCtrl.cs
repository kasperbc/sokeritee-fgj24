using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


[RequireComponent(typeof(VideoPlayer))]

public class BkgCtrl : MonoBehaviour
{
    private VideoPlayer _vid;
    [SerializeField] private VideoClip _clip;
    private RawImage _image;

    [SerializeField]
    [Range(0f, 1f)] public float _fadeSpeed = 1f;

    private void Awake()
    {
        _vid = GetComponent<VideoPlayer>();
        _image = GetComponent<RawImage>();
        //_vid.frame = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        _vid.isLooping = true;
        _vid.clip = _clip;
    }

    // Update is called once per frame
    void Update()
    {
        _image.texture = _vid.texture;
        VideoFade();
    }

    public void VideoFade()
    {
        _vid.Play();
        //_image.color = Color.Lerp(_image.color, Color.white, _fadeSpeed * Time.deltaTime);
    }
}

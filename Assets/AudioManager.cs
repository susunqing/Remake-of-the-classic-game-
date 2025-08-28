
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class AudioManager : MonoBehaviour
{
    public AudioClip birdCollision;
    public AudioClip birdSelect;
    public AudioClip birdFlying;
    public AudioClip[] pigCollision;
    public AudioClip title_Theme;
    public System.Action<Vector3> BirdCollisionDelegate;
    public System.Action<Vector3> TitleThemeDelegate;
    public System.Action<Vector3> BirdSelectDelegate;
    public System.Action<Vector3> BirdFlyingDelegate;
    public System.Action<Vector3> PigCollisionDelegate;




    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {

        BirdCollisionDelegate += PlayBirdCollision;
        TitleThemeDelegate+= PlayTitleTheme;
        BirdSelectDelegate += BirdSelect;
        BirdFlyingDelegate += BirdFluing;
        PigCollisionDelegate += PlayPigCollision;

    }
    private void OnDisable()
    {BirdCollisionDelegate -= PlayBirdCollision;
        TitleThemeDelegate -= PlayTitleTheme;
        BirdSelectDelegate -= BirdSelect;
        BirdFlyingDelegate -= BirdFluing;
        PigCollisionDelegate -= PlayPigCollision;


    }

    private void Start()
    {
    
    }
    public void PlayBirdCollision(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(birdCollision, pos,1f);
    }
    public void PlayTitleTheme(Vector3 pos)
    {
            AudioSource.PlayClipAtPoint(title_Theme,pos, 1f);
    }
    public void BirdSelect(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(birdSelect, pos, 1f);
    }
    /// <summary>
    /// 播放小鸟飞行音效
    /// </summary>
    /// <param name="pos">播放位置</param>
    public void BirdFluing(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(birdFlying, pos, 1f);
    }
    public void PlayPigCollision(Vector3 pos)
    {
        int index = Random.Range(0, pigCollision.Length);
        AudioSource.PlayClipAtPoint(pigCollision[index], pos, 1f);
    }
}

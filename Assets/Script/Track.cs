using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;

    public List<GameObject> list1 = new List<GameObject>(); // 이미지 위에 나타날 오브젝트
    public List<AudioClip> list2 = new List<AudioClip>(); // 첫 번째 소리 리스트

    public GameObject effectPrefab; // 이펙트 프리팹

    private Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> dict2 = new Dictionary<string, AudioClip>();

    private Dictionary<string, GameObject> instantiatedEffects = new Dictionary<string, GameObject>(); // 이펙트를 위한 딕셔너리

    private string currentTrackedImageName; // 현재 트래킹된 이미지 이름

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject o in list1)
        {
            dict1.Add(o.name, o);
            o.SetActive(false);  // 초기에는 비활성화
        }

        foreach (AudioClip o in list2)
        {
            dict2.Add(o.name, o);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        if (dict1.TryGetValue(name, out GameObject o))
        {
            if (t.trackingState == TrackingState.Tracking)
            {
                o.transform.rotation = t.transform.rotation;
                o.SetActive(true);

                //// 이펙트 추가
                //if (!instantiatedEffects.ContainsKey(name))
                //{
                //    GameObject effect = Instantiate(effectPrefab, t.transform.position, t.transform.rotation);
                //    effect.transform.SetParent(o.transform);
                //    ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
                //    if (particleSystem != null)
                //    {
                //        particleSystem.Play();
                //    }
                //    instantiatedEffects[name] = effect;
                //}

                currentTrackedImageName = name; // 현재 트래킹된 이미지 업데이트
            }
            else
            {
                o.SetActive(false);

                if (currentTrackedImageName == name)
                {
                    currentTrackedImageName = null; // 이미지가 트래킹되지 않을 경우 초기화
                }
            }
        }
    }

    void UpdateSound1(string name)
    {
        if (dict2.TryGetValue(name, out AudioClip sound))
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage t in args.added)
        {
            UpdateImage(t);

        }

        foreach (ARTrackedImage t in args.updated)
        {
            UpdateImage(t);
        }
    }

    private void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

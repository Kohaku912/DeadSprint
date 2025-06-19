using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject targetToDeactivate; // インスペクターで指定する

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックされたら
        {
            if (targetToDeactivate != null && targetToDeactivate.activeSelf)
            {
                targetToDeactivate.SetActive(false);
                Debug.Log($"{targetToDeactivate.name} を非表示にしました。");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform loadingBar;

    [SerializeField] float currentValue = 0f, speed = 30f, maxValue = 100f;
    // Update is called once per frame
    void Update()
    {
        if (currentValue <= maxValue)
        {
            currentValue += speed * Time.deltaTime;

            Debug.Log((int)currentValue);
        }
        else
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("Gameplay-Nurul");
        }
        loadingBar.GetComponent<Image>().fillAmount = currentValue / maxValue;
    }
}

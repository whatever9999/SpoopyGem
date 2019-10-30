using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioSource cricket;
    public int maxSeconds;

    IEnumerator Cricket()
    {
        cricket.Play();
        float randSeconds = Random.Range(0, maxSeconds);
        yield return new WaitForSeconds(randSeconds);
    }
}

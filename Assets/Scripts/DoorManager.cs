using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static bool canBeOpen = true;
    public GameObject blockingPlane;
    private float timer = 5;
    private float fadeSpeed = 0.35f;

    public List<GameObject> transparentPlatforms;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canBeOpen)
            {
                if (timer>0)
                {
                    blockingPlane.SetActive(false);
                    this.transform.Rotate( 0, 0, -20 * Time.deltaTime);
                    timer -= Time.deltaTime;

                    foreach(GameObject platform in transparentPlatforms)
                    {
                        Material platformMaterial = platform.GetComponent<MeshRenderer>().material;
                        Color color = platformMaterial.color;
                        if (color.a < 1f)
                        {
                            color.a += fadeSpeed * Time.deltaTime;
                            color.a = Mathf.Clamp01(color.a);
                            platformMaterial.color = color;
                        }
                        else
                        {
                            platformMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                            platformMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                            platformMaterial.SetInt("_ZWrite", 1);
                            platformMaterial.DisableKeyword("_ALPHATEST_ON");
                            platformMaterial.DisableKeyword("_ALPHABLEND_ON");
                            platformMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                            platformMaterial.renderQueue = -1;
                        }
                            
                    }
                }
                else
                {
                    canBeOpen = false;
                }
            }
        }
        
    }
}


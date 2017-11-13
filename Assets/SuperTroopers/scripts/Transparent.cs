using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Transparent : MonoBehaviour
{
    public Transform tar;//角色
    public List<Renderer> listLastRend = new List<Renderer>();
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < listLastRend.Count; i++)
        {
            setDefault(listLastRend[i], 1.0f);//更新为全部不透明
        }
        Vector3 tarDir = (tar.position - transform.position).normalized;
        Debug.DrawLine(tar.position, transform.position, Color.red);

        float tarDis = Vector3.Distance(tar.position, transform.position);
        RaycastHit[] listHitObj = Physics.RaycastAll(transform.position, tarDir, tarDis);
        Debug.Log(listHitObj.Length);
        for (int i = 0; i < listHitObj.Length; i++)
        {
            RaycastHit hit = listHitObj[i];
            if (hit.transform == tar.transform)
            {
                continue;
            }
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            listLastRend.Clear();

            if (renderer)
            {
                listLastRend.Add(renderer);
                TransparencySet(renderer, 0.3f);
            }
        }

    }

    void TransparencySet(Renderer renderer, float a)
    {
        renderer.material.shader = Shader.Find("Transparent/Diffuse");
        //
        //Standard
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, a);
    }

    void setDefault(Renderer renderer, float a)
    {
        renderer.material.shader = Shader.Find("Standard");
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, a);
    }
}
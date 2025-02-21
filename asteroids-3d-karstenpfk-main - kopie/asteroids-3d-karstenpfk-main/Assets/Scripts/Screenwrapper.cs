using UnityEngine;
using UnityEngine.Rendering;

public class Screenwrapper : MonoBehaviour
{
    Vector3 righttop;
    Vector3 bottomleft;


    void Start()
    {
        righttop = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 20f));
        bottomleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 20f));

        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = righttop;

        GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go2.transform.position = bottomleft;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > righttop.x)
        {
            transform.position = new Vector3(bottomleft.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < bottomleft.x)
        {
            transform.position = new Vector3(righttop.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.z >= righttop.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomleft.z);
        }
        else if (transform.position.z <= bottomleft.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, righttop.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoagulationScript : MonoBehaviour {

    private float gravity;

	// Use this for initialization
	void Start () {
        gravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;

    }
	
	// Update is called once per frame
	void Update () {
        if (CheckCloseToTag(gameObject.tag, gameObject.GetComponent<CircleCollider2D>().radius*3))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity*(-1);
            Debug.Log("reversed gravity");
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
            Debug.Log("normal gravity");
        }
	}

    bool CheckCloseToTag(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

        

        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance &&
                Vector3.Distance(transform.position, goWithTag[i].transform.position) > 0)
                return true;
        }

        return false;
    }
}

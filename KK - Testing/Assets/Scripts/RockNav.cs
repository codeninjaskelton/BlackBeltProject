using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNav : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private GameObject rock;
    public bool touchingPlayer = false;
    public bool touchingRock;
    public float translateSpeed;
    public float time;
    public AnimationCurve curve;

    private void Start()
    {
        player = GameObject.Find("Bean");
        rock = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        time += translateSpeed / 1000;
        if (touchingPlayer)
        {
            rock.GetComponent<Rigidbody>().isKinematic = false;
            rock.GetComponent<Rigidbody>().AddForce((player.transform.position - rock.transform.position).normalized * speed * 0.1f);
            if (rock.GetComponent<Rigidbody>().velocity.magnitude > speed)
            {
                rock.GetComponent<Rigidbody>().velocity = rock.GetComponent<Rigidbody>().velocity.normalized * speed;
            }
        }
        else
        {
            rock.GetComponent<Rigidbody>().isKinematic = true;
            rock.GetComponent<Rigidbody>().MovePosition(Vector2.Lerp(rock.transform.position, transform.position, curve.Evaluate(time)));
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }
        if (other.gameObject.name == "Rock")
        {
            touchingRock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && touchingPlayer)
        {
            touchingPlayer = false;
        }
        if (other.gameObject.name == "Rock" && touchingRock)
        {
            touchingRock = false;
        }
    }
}

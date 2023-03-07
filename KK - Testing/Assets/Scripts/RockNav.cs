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
        float number = transform.GetChild(1).transform.localScale.x;
        time += translateSpeed / 1000;
        while (number < 0)
        {
            number *= -1;
        }
        if (touchingPlayer)
        {

            if (Vector3.Distance(rock.transform.position, transform.position) >= number / 2)
            {
                
                rock.GetComponent<Rigidbody>().isKinematic = true;
                rock.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                
                
                rock.GetComponent<Rigidbody>().MovePosition(Vector2.Lerp(rock.transform.position, transform.position + ((player.transform.position - rock.transform.position).normalized * number / 2) , curve.Evaluate(1) * 0.1f));
            }
            else
            {
                rock.GetComponent<Rigidbody>().isKinematic = false;
                rock.GetComponent<Rigidbody>().AddForce((player.transform.position - rock.transform.position).normalized * speed * 0.1f);
                if (rock.GetComponent<Rigidbody>().velocity.magnitude > speed)
                {
                    rock.GetComponent<Rigidbody>().velocity = rock.GetComponent<Rigidbody>().velocity.normalized * speed;
                }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditorObject : MonoBehaviour
{
    public enum ObjectType { Block, Star, Bean, Portal, Wind };

    [Serializable]
    public struct Data
    {
        public Vector3 pos;
        public Quaternion rot;
        public ObjectType objectType;
        public Vector3 rotationSpeed;
    }

    public Data data;
    public void Start()
    {
        data.pos = transform.position;
        data.rot = transform.rotation;
    }
}

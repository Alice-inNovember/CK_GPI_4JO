using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_NM<T> where T : class, new()
{
    static T _instance = null;
    public static T Instance => _instance ??= new T();
}

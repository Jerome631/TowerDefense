using UnityEngine;
using System.Collections;
/// <summary>
/// A singleton is a class that ensures there is only one instance of any object at any time.
/// So this baically ensures there aren't any copies.
/// </summary>
/// <typeparam name="T">The type of MonoBehaviour the singleton needs to be</typeparam>
public abstract class Singleton<T>  : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// The instance of the singleton
    /// </summary>
    private static T instance;

    /// <summary>
    /// Property for accessing the singleton
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null) //If the instance is null then we need to find it
            {
                instance = FindObjectOfType<T>();
            }

            //Returns the instance
            return instance;
        }

    }
}

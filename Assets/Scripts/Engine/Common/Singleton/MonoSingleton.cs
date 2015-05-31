using UnityEngine;

namespace Runner.Engine
{
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		private static T instance = null;
    	public static T Instance
    	{
			get {
				if (instance == null) {
					instance = GameObject.FindObjectOfType(typeof(T)) as T;
                	if (instance == null) {
						instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T> ();
                    
						if (instance == null)
                        	Debug.LogError("Problem during the creation of " + typeof(T).ToString());
						else
							instance.Init ();
                	} else
						instance.Init ();
            	}
            	return instance;
        	}
    	}

		// If no other monobehaviour request the instance in an awake function
    	// executing before this one, no need to search the object.
		private void Awake ()
    	{
        	if( instance == null )
            	instance = this as T;
    	}

		protected virtual void Init () {}
 		
		private void OnApplicationQuit()
    	{
        	instance = null;
    	}
	}
}
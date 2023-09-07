using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.genericSingleton
{
    public class GenericMonoSingleTon<T> : MonoBehaviour where T : GenericMonoSingleTon<T>
    {
        private static T Instance;
        public static T instance { get { return Instance; } }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}

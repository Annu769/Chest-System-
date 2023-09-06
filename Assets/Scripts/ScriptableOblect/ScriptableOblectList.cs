using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestScriptableObjectList", menuName = "ScriptableObjectList/ NewChestList")]
    public class ScriptableOblectList : ScriptableObject
    {
        public ChestScriptableObject[] chests;
    }
    
}

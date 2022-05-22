using System;
using System.Collections.Generic;
using UnityEngine;
namespace Utils.Save
{
    public class Savable : MonoBehaviour
    {
        [SerializeField] private string id = string.Empty;

        public string Id => id;

        [ContextMenu("Generate ID")]
        private void GenerateId() => id = Guid.NewGuid().ToString();

        public object CaptureState()
        {
            var state = new Dictionary<string, object>();
            foreach (var saveable in GetComponents<ISavable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            var stateDic = (Dictionary<string, object>) state;

            foreach (var savable in GetComponents<ISavable>())
            {
                string type = savable.GetType().ToString();

                if (stateDic.TryGetValue(type, out object value))
                {
                    savable.RestoreState(value);
                }
            }
        }
    }
}
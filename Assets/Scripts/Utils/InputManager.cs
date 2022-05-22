using System;
using System.Collections.Generic;
using UnityEngine;
namespace Utils
{
    public class InputManager : GenericSingleton<InputManager>
    {
        private List<Action> functions;
        private void Update()
        {
            functions.ForEach(func => func());

        }

        private void Add(Action func)
        {
            functions.Add(func);
        }

        public void CreateKeyCodeAction(KeyCode keyCode, Action onKeyDown)
        {
            Add(() =>
            {
                if (Input.GetKeyDown(keyCode))
                {
                    onKeyDown();
                }
            });
        }
        public void CreateAction(Action action)
        {
            Add(action);
        }
        
        protected override void InternalInit()
        {

        }
        protected override void InternalOnDestroy()
        {
        }
    }
}
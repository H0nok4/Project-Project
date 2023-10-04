using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoSingleton<UIManager> {
        public readonly Stack<UIPanel> UIStack = new Stack<UIPanel>();
        public Canvas UICanvas;

        public void Init() {
            UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        }

        public void Show(int uiUID) {

        }

        public void Show(UIPanel uiPanel) {
            if (UIStack.Count > 0) {
                var topPanel = UIStack.Peek();
                topPanel.Hide();
            }
            UIStack.Push(uiPanel);
            uiPanel.Show();
        }

        public void CloseCurrent() {
            if (UIStack.Count > 0) {
                var topPanel = UIStack.Pop();
                topPanel.Hide();
            }

            if (UIStack.Count > 0) {
                var topPanel = UIStack.Peek();
                topPanel.Show();
            }
        }

    }

}


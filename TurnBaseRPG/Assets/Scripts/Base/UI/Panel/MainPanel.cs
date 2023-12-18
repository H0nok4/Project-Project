using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UI.UserInterface;
using UnityEngine;

namespace Assets.Scripts.Base.UI.Panel {
    public class MainPanel : UIPanel {
        public UIList ListInteract;
        public override void InitInstance() {
            ListInteract = GetUIListAtChildIndex(1);
        }

        public override void OnShow() {
            base.OnShow();
            EventManager.Instance.AddListener(EventDef.OnAddInteract,OnAddInteract);
            EventManager.Instance.AddListener(EventDef.OnRemoveInteract,OnRemoveInteract);
        }

        private void OnAddInteract() {
            //ListInteract.gameObject.transform.position = PlayerObject
            //var findPlayer = GameObject.Find("PlayerObject").GetComponent<PlayerObject>();
            ListInteract.gameObject.SetActive(true);
            ListInteract.ChildCount = InteractiveManager.Instance.InteractiveObject.Count;
            for (int i = 0; i < ListInteract.ChildCount; i++) {
                var btnInteract = (BtnInteract)ListInteract.ChildList[i];
                RefreshBtnInteract(btnInteract,i);
            }
        }

        public void RefreshBtnInteract(BtnInteract btn,int index) {
            btn.TxtName.text = InteractiveManager.Instance.InteractiveObject[index].ShowName;
        }

        private void OnRemoveInteract() {
            ListInteract.ChildCount = InteractiveManager.Instance.InteractiveObject.Count;
            if (ListInteract.ChildCount == 0) {
                ListInteract.gameObject.SetActive(false);
            }
        }
    }
}

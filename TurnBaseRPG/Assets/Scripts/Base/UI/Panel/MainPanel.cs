using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

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
            ListInteract.AddChild();
            //ListInteract.gameObject.transform.position = PlayerObject
        }

        private void OnRemoveInteract() {

        }
    }
}

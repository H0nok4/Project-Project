using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IInteractive {

    public string ShowName { get; }
    public bool CanContact { get; }
    public void OnTrigger() {

    }
}


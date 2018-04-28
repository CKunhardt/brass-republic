using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Neighbor1Door : Interaction, IInteractable {

    public override void Interact() {
        ExecuteEvents.Execute<IEventMessageHandler>(GameManager.Instance.EMH, null, (x, y) => x.CheckDialogueEvents("Neighbor 1"));
    }

}

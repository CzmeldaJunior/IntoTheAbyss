using UnityEngine;

public interface IInteractable
{
    void Interact(InteractionManager interactor);

    string GetInteractionPrompt();
}

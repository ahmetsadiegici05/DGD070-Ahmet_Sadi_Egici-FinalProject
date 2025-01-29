using Entitas;
using System.Linq;
using UnityEngine;

public class WinConditionSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public WinConditionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var pads = _contexts.game.GetGroup(GameMatcher.Pad);
        if (pads.GetEntities().All(pad => pad.isTouched))
        {
            if (!_contexts.game.isGameWon)
            {
                _contexts.game.isGameWon = true; 

                Debug.Log(" Oyun Tamamlandý! ");

                
                var winText = new GameObject("WinText");
                var textMesh = winText.AddComponent<TextMesh>();
                textMesh.text = " WINRAR IS YOU! ";
                textMesh.fontSize = 15;
                textMesh.color = Color.yellow;
                textMesh.alignment = TextAlignment.Center;
                textMesh.anchor = TextAnchor.MiddleCenter;
                winText.transform.position = new Vector3(0, 0, -1);

                
                var player = _contexts.game.GetGroup(GameMatcher.Player).GetSingleEntity();
                if (player != null)
                {
                    if (player.hasView) 
                    {
                        GameObject.Destroy(player.view.gameObject);
                    }
                    player.Destroy();
                }
            }
        }
    }
}

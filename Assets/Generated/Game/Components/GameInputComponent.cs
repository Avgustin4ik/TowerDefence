//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity inputEntity { get { return GetGroup(GameMatcher.Input).GetSingleEntity(); } }
    public InputComponent input { get { return inputEntity.input; } }
    public bool hasInput { get { return inputEntity != null; } }

    public GameEntity SetInput(UnityEngine.Vector2 newValue) {
        if (hasInput) {
            throw new Entitas.EntitasException("Could not set Input!\n" + this + " already has an entity with InputComponent!",
                "You should check if the context already has a inputEntity before setting it or use context.ReplaceInput().");
        }
        var entity = CreateEntity();
        entity.AddInput(newValue);
        return entity;
    }

    public void ReplaceInput(UnityEngine.Vector2 newValue) {
        var entity = inputEntity;
        if (entity == null) {
            entity = SetInput(newValue);
        } else {
            entity.ReplaceInput(newValue);
        }
    }

    public void RemoveInput() {
        inputEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InputComponent input { get { return (InputComponent)GetComponent(GameComponentsLookup.Input); } }
    public bool hasInput { get { return HasComponent(GameComponentsLookup.Input); } }

    public void AddInput(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Input;
        var component = (InputComponent)CreateComponent(index, typeof(InputComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInput(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Input;
        var component = (InputComponent)CreateComponent(index, typeof(InputComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInput() {
        RemoveComponent(GameComponentsLookup.Input);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInput;

    public static Entitas.IMatcher<GameEntity> Input {
        get {
            if (_matcherInput == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Input);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInput = matcher;
            }

            return _matcherInput;
        }
    }
}

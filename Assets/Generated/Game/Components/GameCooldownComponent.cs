//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _GameLogic_.Common.CooldownComponent cooldown { get { return (_GameLogic_.Common.CooldownComponent)GetComponent(GameComponentsLookup.Cooldown); } }
    public bool hasCooldown { get { return HasComponent(GameComponentsLookup.Cooldown); } }

    public void AddCooldown(float newValue) {
        var index = GameComponentsLookup.Cooldown;
        var component = (_GameLogic_.Common.CooldownComponent)CreateComponent(index, typeof(_GameLogic_.Common.CooldownComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCooldown(float newValue) {
        var index = GameComponentsLookup.Cooldown;
        var component = (_GameLogic_.Common.CooldownComponent)CreateComponent(index, typeof(_GameLogic_.Common.CooldownComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCooldown() {
        RemoveComponent(GameComponentsLookup.Cooldown);
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

    static Entitas.IMatcher<GameEntity> _matcherCooldown;

    public static Entitas.IMatcher<GameEntity> Cooldown {
        get {
            if (_matcherCooldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Cooldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCooldown = matcher;
            }

            return _matcherCooldown;
        }
    }
}

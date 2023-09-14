//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _GameLogic_.Input.Components.ClickedComponent clickedComponent = new _GameLogic_.Input.Components.ClickedComponent();

    public bool isClicked {
        get { return HasComponent(GameComponentsLookup.Clicked); }
        set {
            if (value != isClicked) {
                var index = GameComponentsLookup.Clicked;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : clickedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherClicked;

    public static Entitas.IMatcher<GameEntity> Clicked {
        get {
            if (_matcherClicked == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Clicked);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherClicked = matcher;
            }

            return _matcherClicked;
        }
    }
}

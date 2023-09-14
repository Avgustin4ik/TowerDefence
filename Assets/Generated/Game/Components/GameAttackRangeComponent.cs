//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _GameLogic_.Common.AttackRangeComponent attackRangeComponent = new _GameLogic_.Common.AttackRangeComponent();

    public bool isAttackRange {
        get { return HasComponent(GameComponentsLookup.AttackRange); }
        set {
            if (value != isAttackRange) {
                var index = GameComponentsLookup.AttackRange;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : attackRangeComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherAttackRange;

    public static Entitas.IMatcher<GameEntity> AttackRange {
        get {
            if (_matcherAttackRange == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackRange);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackRange = matcher;
            }

            return _matcherAttackRange;
        }
    }
}

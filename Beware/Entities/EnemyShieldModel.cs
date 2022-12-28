namespace Beware.Entities {
    public class EnemyShieldModel : ShieldModel {
        public EnemyShieldModel(int startingHealth = 20, int startingImpactDamage = 15) : base(startingHealth, startingImpactDamage) { }

        public override void Update() {
            base.Update();
        }
    }
}

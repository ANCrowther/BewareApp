using Beware.Behaviours;
using Beware.EntityFeatures;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        private readonly IBehaviour switchSpecial;
        private readonly IBehaviour switchSpeed;

        public int ShieldCountdown { get; private set; }
        private int previousShieldSecond = 0;
        public int BoostCountdown { get; private set; }
        private int previousBoostSecond = 0;

        public static PlayerModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerModel();
                }
                return instance;
            }
        }

        private PlayerModel(int startingHealth = 20, int startingImpactDamage = 5) 
            : base(new Engine(ViewportManager.GetWindowSize(View.GamePlay) / 2, Vector2.Zero), new Sprite(EntityArt.Player1, 0.3f), startingHealth, startingImpactDamage) {
            Health.OnDeath += delegate { this.Die(); };
            Health.OnHit += delegate { this.Health.ResetHealthBarFramesUntilColorChange(); };
            switchSpecial = new SwitchSpecialBehaviour();
            switchSpeed = new SwitchSpeedBehaviour();
            ShieldCountdown = PlayerStatus.MaxShieldCountdown;
            BoostCountdown = PlayerStatus.MaxBoostWaitCountdown;
            MainGun = new PlayerGun(this);
        }

        public override void Update() {
            UpdateShieldStatus();

            Health.Update();
            MainGun.Update();
            switchSpecial.Update(null);
            switchSpeed.Update(this);

            base.Update();
        }

        public override void Hit(int damage = 1) {
            base.Hit(damage);
        }

        private void UpdateShieldStatus() {
            if (Shield != null && Shield.IsExpired == true) {
                Shield = null;
                ShieldCountdown = PlayerStatus.MaxShieldCountdown;
            }
            if (TimeKeeper.Seconds != previousShieldSecond) {
                previousShieldSecond = TimeKeeper.Seconds;
                ShieldCountdown--;
            }
            if (TimeKeeper.Seconds != previousBoostSecond) {
                previousBoostSecond = TimeKeeper.Seconds;
                BoostCountdown--;
            }

            ((PlayerShield)Shield)?.Update();
        }

        public override void SetBehaviour(BehaviourCategory category, IBehaviour behaviour) {
            if (behaviour is PlayerRapidFireBehaviour p) {
                p.OnUse += delegate { ((PlayerGun)MainGun).UpdateDrawColor(); };
                base.SetBehaviour(category, p);
                return;
            } else if (behaviour is PlayerSabotShootBehaviour q) {
                q.OnUse += delegate { ((PlayerGun)MainGun).UpdateDrawColor(); };
                q.OnEmpty += delegate { RemoveBehaviour(category); };
                base.SetBehaviour(category, q);
                return;
            } else if (behaviour is PlayerBoostBehaviour r) {
                r.OnUse += delegate { BoostCountdown = PlayerStatus.MaxBoostCountdown; };
                r.OnTimesUp += delegate { BoostCountdown = PlayerStatus.MaxBoostWaitCountdown; };
                base.SetBehaviour(category, r);
                return;
            } else {
                base.SetBehaviour(category, behaviour);
            }
        }

        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Engine.Position.X, Engine.Position.Y + (Sprite.Size.Y * Sprite.Scale) / 2 + 15);
                Health.Draw(position);
                base.Draw();
                MainGun.Draw();
            }
        }

        protected override void Die() {
            SceneManager.SwitchScene(SceneManager.GameOverWindow);
        }

        public void ResetPlayer() {
            SetBehaviours();
            Health.ResetHealth();
            IsExpired = false;
            Engine.Position = ViewportManager.GetWindowSize(View.GamePlay) / 2;
            Engine.Velocity = Vector2.Zero;
            Shield = null;
            ShieldCountdown = PlayerStatus.MaxShieldCountdown;
            BoostCountdown = PlayerStatus.MaxBoostWaitCountdown;

            // TODO: remove the following line when able to pickup ammo reloads.
            PlayerStatus.SpecialAmmoCount = 10;
        }

        private void SetBehaviours() {
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Shoot, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.RapidFire));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Move, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerBasicMove));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.SpecialDefensive, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerShield));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.SpecialOffensive, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.SabotShoot));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Boost, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerBoost));
        }
    }
}

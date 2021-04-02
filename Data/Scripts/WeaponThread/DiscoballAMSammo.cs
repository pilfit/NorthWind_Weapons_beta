using System.IO;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef.SpawnType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef.PushPullDef.Force;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.Texture;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.TracerBaseDef;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AmmoDef AMSLaser => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "AMSLaser",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 2f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 7,
            Mass = 0.0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			HardPointUsable = true,
            EnergyMagazineSize = 10,             

            Shape = new ShapeDef //defines SphereShape LineShape the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 0,
				Reverse = false,
				RandomizeDir = false,
                Degrees = 120, // 0 - 360
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.15f, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = 0.15f,
				FallOff = new FallOffDef
                {
                 Distance = 100f, // Distance at which max damage begins falling off.
                 MinMultipler = 0.1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },				
                Grids = new GridSizeDef
                {
                    Large = 0.1f,
                    Small = 0.1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = 0f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = -1f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "LargeHeavyBlockArmorBlock",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0f,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = true,
                    NoSound = true,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 0,
                    DetonationRadius = 0,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 600,
                    StackDuration = true,
                    Depletable = true,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 0,
                MaxTrajectory = 1500f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 0, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = true,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        Color = Color(red: 255, green: 60, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LaserHitParticlesNW",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 10f, green: 2f, blue: 1f, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 1000,
                            MaxDuration = 0,
                            Scale = 1f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.75f, end: 5f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0.04f, end: 0.05f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = 0.05f,
                        Color = Color(red: 5.0f, green: 0.40f, blue: 0.08f, alpha: 0.1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 600,
                        Color = Color(red: 6, green: 10, blue: 80, alpha: 1f),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 5f,
                        MaxLength = 15,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 1f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 

    }
}

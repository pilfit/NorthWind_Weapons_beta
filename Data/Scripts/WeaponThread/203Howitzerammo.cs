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
        private AmmoDef H203mmammoS => new AmmoDef
        {
            AmmoMagazine = "H203Ammo",
            AmmoRound = "H203mmammoS",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.3f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1f,
            Mass = 90f, // in kilograms
            Health = 8, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 55000f,
			HardPointUsable = true,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0.2,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "H203ShrapBase",
                Fragments = 1,
				Reverse = false,
				RandomizeDir = false,
                Degrees = 360, // 0 - 360
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },				
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                VoxelHitModifier = 2f,					
				FallOff = new FallOffDef
                {
                 Distance = 1000f, // Distance at which max damage begins falling off.
                 MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = 0.3f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = 0.4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1.2f,
                    Type = Kinetic,
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
                            Modifier = 2f,
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
                AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                Base = new AreaInfluence
                {
                    Radius = 0f, // the sphere of influence of area effects
                    EffectStrength = 0f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = true,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 15,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = true,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 1500,
                    DetonationRadius = 15,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)					
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = TravelTo,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 1800, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 125,
                MaxTrajectory = 30000f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
				GravityMultiplier = 1f, // Gravity influences the trajectory of the projectile.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "\\Models\\203HowitzerRound.mwm",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        Color = Color(red: 50, green: 6, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LargeArtExplosion",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 1f, green: 1f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 10f,
                        Width = 0.1f,
                        Color = Color(red: 50.80f, green: 16.20f, blue: 1.6f, alpha: 1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 25,
                        Color = Color(red: 5.585f, green: 3.562f, blue: 0.21f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.15f,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "ArcWepLrgWarheadExpl",
                HitPlayChance = 1f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 
        private AmmoDef H203mmammoM => new AmmoDef
        {
            AmmoMagazine = "H203Ammo",
            AmmoRound = "H203mmammoM",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.3f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1f,
            Mass = 20f, // in kilograms
            Health = 8, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 100000f,
			HardPointUsable = true,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0.2,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "H203ShrapBase",
                Fragments = 1,
				Reverse = false,
				RandomizeDir = false,
                Degrees = 360, // 0 - 360
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },				
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                VoxelHitModifier = 10,					
				FallOff = new FallOffDef
                {
                 Distance = 1000f, // Distance at which max damage begins falling off.
                 MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = 0.3f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = 0.4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1.2f,
                    Type = Kinetic,
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
                            Modifier = 2f,
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
                AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                Base = new AreaInfluence
                {
                    Radius = 0f, // the sphere of influence of area effects
                    EffectStrength = 0f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = true,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = true,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 1500,
                    DetonationRadius = 15,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)					
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = TravelTo,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 2760, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 225,
                MaxTrajectory = 30000f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
				GravityMultiplier = 1f, // Gravity influences the trajectory of the projectile.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "\\Models\\203HowitzerRound.mwm",
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
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LargeArtExplosion",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 1f, green: 1f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 10f,
                        Width = 0.1f,
                        Color = Color(red: 50.80f, green: 16.20f, blue: 1.6f, alpha: 1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 25,
                        Color = Color(red: 5.585f, green: 3.562f, blue: 0.21f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.15f,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "ArcWepLrgWarheadExpl",
                HitPlayChance = 1f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };

        private AmmoDef H203mmammoL => new AmmoDef
        {
            AmmoMagazine = "H203Ammo",
            AmmoRound = "H203mmammoL",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.3f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1f,
            Mass = 20f, // in kilograms
            Health = 8, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 180000f,
			HardPointUsable = true,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0.2,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "H203ShrapBase",
                Fragments = 1,
				Reverse = false,
				RandomizeDir = false,
                Degrees = 360, // 0 - 360
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },				
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                VoxelHitModifier = 10,					
				FallOff = new FallOffDef
                {
                 Distance = 1000f, // Distance at which max damage begins falling off.
                 MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = 0.3f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = 0.4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1.2f,
                    Type = Kinetic,
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
                            Modifier = 2f,
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
                AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                Base = new AreaInfluence
                {
                    Radius = 0f, // the sphere of influence of area effects
                    EffectStrength = 0f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = true,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = true,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 1500,
                    DetonationRadius = 15,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)					
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = TravelTo,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 4020, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 325,
                MaxTrajectory = 30000f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
				GravityMultiplier = 1f, // Gravity influences the trajectory of the projectile.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "\\Models\\203HowitzerRound.mwm",
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
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LargeArtExplosion",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 1f, green: 1f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 10f,
                        Width = 0.1f,
                        Color = Color(red: 50.80f, green: 16.20f, blue: 1.6f, alpha: 1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 25,
                        Color = Color(red: 5.585f, green: 3.562f, blue: 0.21f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.15f,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "ArcWepLrgWarheadExpl",
                HitPlayChance = 1f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };

        private AmmoDef H203mmammoShrap => new AmmoDef
        {
            AmmoMagazine = "H203Ammo",
            AmmoRound = "H203mmammoShrap",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.3f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 300f,
            Mass = 2f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 60000f,
			HardPointUsable = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0.2,
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
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },				
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                VoxelHitModifier = 10,					
				FallOff = new FallOffDef
                {
                 Distance = 1000f, // Distance at which max damage begins falling off.
                 MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = 0.5f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = 0.6f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 0.2f,
                    Type = Kinetic,
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
                Base = new AreaInfluence
                {
                    Radius = 0f, // the sphere of influence of area effects
                    EffectStrength = 0f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = true,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 0,
                    DetonationRadius = 0,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)					
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 250,
                MaxTrajectory = 75f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
				GravityMultiplier = 0f, // Gravity influences the trajectory of the projectile.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
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
                        Color = Color(red: 5, green: 5, blue: 5, alpha: 0),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.5f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 1f, green: 1f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 0.1f,
                            Scale = 1.2f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 5f,
                        Width = 0.1f,
                        Color = Color(red: 50.0f, green: 5.20f, blue: 1.1f, alpha: 1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 10,
                        Color = Color(red: 5.585f, green: 3.562f, blue: 2.21f, alpha: 1f),
                        Back = false,
                        CustomWidth = 0.3f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
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

          private AmmoDef H203ShrapBase => new AmmoDef
        {
            AmmoMagazine = "H203Ammo",
            AmmoRound = "H203ShrapBase",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.0001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 10f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
            DecayPerShot = 0f,			
			HardPointUsable = true,
            IgnoreWater = false,			

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0.5,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "H203mmammoShrap",
                Fragments = 150,
				Reverse = false,
				RandomizeDir = false,
                Degrees = 360, // 0 - 360
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },			
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                VoxelHitModifier = 10,				
                Characters = -1f,
				FallOff = new FallOffDef
                {
                 Distance = 1000f, // Distance at which max damage begins falling off.
                 MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
		        },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = 0.2f,
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
                    Modifier = 1.2f,
                    Type = Kinetic,
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
                            Modifier = 2f,
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
                AreaEffect = DotField, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                Base = new AreaInfluence
                {
                    Radius = 10f, // the sphere of influence of area effects
                    EffectStrength = 100f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 6,
                    PulseChance = 100,
                    GrowTime = 1,
                    HideModel = false,
                    ShowParticle = true,
                    Particle = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 0.3f,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = true,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 1,
                    DetonationRadius = 1f,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = false,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 6, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 500f,
                DesiredSpeed = 10,
                MaxTrajectory = 1f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
				GravityMultiplier = 1f, // Gravity influences the trajectory of the projectile.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 0.1f,
                ShieldHitDraw = false,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        Color = Color(red: 255, green: 60, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = false,
                        ShrinkByDistance = true,
                        Color = Color(red: 255, green: 60, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 0.2f,
                            Scale = 0.2f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 5f,
                        Width = 0.1f,
                        Color = Color(red: 5.80f, green: 0.0f, blue: 0.0f, alpha: 1f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 8,
                        Color = Color(red: 18.985f, green: 18.162f, blue: 0.81f, alpha: 1f),
                        Back = false,
                        CustomWidth = 0.1f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 1f,
                HitPlayShield = false,
            }, // Don't edit below this line
        };

    }
}

﻿using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
        // Don't edit above this line
        WeaponDefinition RailgunxturretS => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "RailgunxTurretS",
                        AimPartId = "None",
                        MuzzlePartId = "ElS",
                        AzimuthPartId = "AzS",
                        ElevationPartId = "ElS",
                    },

                },
                Barrels = new [] {
                    "muzzle_missile_1",

                },
            },
            Targeting = new TargetingDef  
            {
                Threats = new[] {
                    Grids,
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any,
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 2, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "75mm Railgun Turret", // name of weapon in terminal
                DeviateShotAngle = 0.4f,
                AimingTolerance = 0.15f, // 0 - 180 firing angle
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = false,
                    EnableOverload =  false,
                },
                Ai = new AiDef {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef {
                    RotateRate = 0.004f,
                    ElevateRate = 0.004f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -10,
                    MaxElevation = 44,
                    FixedOffset = false,
                    InventorySize = 0.041f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef {
                    RateOfFire = 30,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 180, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 7600, //heat generated per shot
                    MaxHeat = 70000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .50f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 1000, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "ArcWepExplSmall", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "WepShipGatlingRotation",
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "Railgunmuzzleflash_NW", // Smoke_LargeGunShot
                        Color = Color(red: 255, green: 155, blue: 51, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 300,
                            MaxDuration = 10,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "Railgunmuzzlesparks_NW",//Muzzle_Flash_Large
                        Color = Color(red: 10, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 350,
                            MaxDuration = 15,
                            Scale = 0.3f,
                        },
                    },
                },
            },
            Ammos = new [] {
                R75ammo,
				railgunShrapnel,
                RailFXshots,
                RailFXshots2                

            },
            Animations = RailgunxturretS_Animation,
            // Don't edit below this line
        };
    }
}
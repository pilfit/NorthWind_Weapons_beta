﻿using static Scripts.Structure;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.ModelAssignmentsDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.Prediction;
using static Scripts.Structure.WeaponDefinition.TargetingDef.BlockTypes;
using static Scripts.Structure.WeaponDefinition.TargetingDef.Threat;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef.HardwareType;

namespace Scripts {   
    partial class Parts {
        // Don't edit above this line
        WeaponDefinition C30mmSingleT => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "C30mmSingleT",
                        SpinPartId = "None", // For weapons with a spinning barrel such as Gatling Guns.
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
                    },

                },
                Muzzles = new[] {
                    "muzzle_missile_01",
					

                },
            },
            Targeting = new TargetingDef  
            {
                Threats = new[] {
                    Grids, Projectiles, Meteors,
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any,
                },
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                IgnoreDumbProjectiles = false, // Don't fire at non-smart projectiles.
                LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.				
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                MaxTargetDistance = 1200, // 0 = unlimited, Maximum target distance that targets will be automatically shot at.
                MinTargetDistance = 0, // 0 = unlimited, Min target distance that targets will be automatically shot at.				
                TopTargets = 8, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1500, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                PartName = "30mm RevolverCannon CIWS", // name of weapon in terminal
                DeviateShotAngle = 0.4f,
                AimingTolerance = 4.15f, // 0 - 180 firing angle
                AimLeadingPrediction = Accurate, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 30, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

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
                    RotateRate = 0.035f,
                    ElevateRate = 0.028f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -30,
                    MaxElevation = 89,
                    FixedOffset = false,
                    InventorySize = 0.6f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                    Type = BlockWeapon, // What type of weapon this is; BlockWeapon, HandWeapon, Phantom 
                },
                Other = new OtherDef {
                    ConstructPartCap = 0, // Maximum number of blocks with this weapon on a grid; 0 = unlimited.
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                    RestrictionRadius = 2.5f, // Meters, radius of sphere disable this gun if another is present
                    CheckInflatedBox = true, // if true, the bounding box of the gun is expanded by the RestrictionRadius
                    CheckForAnyWeapon = false, // if true, the check will fail if ANY gun is present, false only looks for this subtype					
                },
                Loading = new LoadingDef {
                    RateOfFire = 600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 180, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 276, //heat generated per shot
                    MaxHeat = 70000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .50f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 6800, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "C30mmFiring", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef {

                    Effect1 = new ParticleDef {
                        Name = "RotaryCannonFlash", // Smoke_LargeGunShot
                        Color = Color(red: 15, green: 2, blue: 1, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = true,
                            Restart = true,
                            MaxDistance = 300,
                            MaxDuration = 0f,
                            Scale = 1f,
                        },
                    },
                    Effect2 = new ParticleDef {
                        Name = "RotarycannonSmoke",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1f),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 350,
                            MaxDuration = 6f,
                            Scale = 1.0f,
                        },
                    },
                },
            },
            Ammos = new [] {
               C30mmAmmo, C30mmAmmoAP, C30mmAmmoHE, C30mmAmmoAT, C30mmAmmoDU, C30mmCRAMAmmo, C30mmCRAMAmmoS, C30mmAmmoR,

            },
            
            // Don't edit below this line
        };
    }
}
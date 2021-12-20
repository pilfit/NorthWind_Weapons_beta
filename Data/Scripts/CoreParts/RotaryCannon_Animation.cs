using System.Collections.Generic;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AnimationDef;
using static Scripts.Structure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove;
namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AnimationDef RotaryCannonAnimation => new AnimationDef
        {
			

            //Emissives = new []
            //{

            //    Emissive(
            //        EmissiveName: "TurnOn",
            //        Colors: new []
            //        {
            //            Color(red:0, green: 0, blue:0, alpha: 1),//will transitions form one color to the next if more than one
            //            Color(red:0, green: .051f, blue:.051f, alpha: .05f),

            //        },
            //        IntensityFrom:0, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
            //        IntensityTo:1,
            //        CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
            //        LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
            //        EmissivePartNames: new []
            //        {
            //            "Emissive3"
            //        }),

            //    Emissive(
            //        EmissiveName: "TurnOff",
            //        Colors: new []
            //        {
            //            Color(red:0, green: .051f, blue:.051f, alpha: .05f),//will transitions form one color to the next if more than one
            //            Color(red:0, green: 0, blue: 0, alpha: 1),//will transitions form one color to the next if more than one
                        

            //        },
            //        IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
            //        IntensityTo:0,
            //        CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
            //        LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
            //        EmissivePartNames: new []
            //        {
            //            "Emissive3"
            //        }),




            //    Emissive(
            //        EmissiveName: "PowerUp", 
            //        Colors: new []
            //        {
            //            Color(red:0, green: .051f, blue:.051f, alpha: .05f),//will transitions form one color to the next if more than one
            //            Color(red:0, green: 1, blue:1, alpha: 1),
                        
            //        }, 
            //        IntensityFrom:0, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
            //        IntensityTo:1, 
            //        CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
            //        LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
            //        EmissivePartNames: new []
            //        {
            //            "Emissive3"
            //        }),

            //    Emissive(
            //        EmissiveName: "ShootPulse",
            //        Colors: new []
            //        {

                        
            //            Color(red:0, green: 250, blue: 250, alpha: 1),

            //        },
            //        IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
            //        IntensityTo:1,
            //        CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
            //        LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
            //        EmissivePartNames: new []
            //        {
            //            "Emissive3"
            //        }),
            //    Emissive(
            //        EmissiveName: "PowerDown",
            //        Colors: new []
            //        {

            //            Color(red:0, green: 250, blue:250, alpha: 1),
            //            Color(red:0, green: .051f, blue:.051f, alpha: .05f),

            //        },
            //        IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
            //        IntensityTo:1,
            //        CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
            //        LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
            //        EmissivePartNames: new []
            //        {
            //            "Emissive3"
            //        }),

            //},
            AnimationSets = new[]
            {
				#region Barrels Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("RotaryCannonBarrel"),
                    BarrelId = "muzzle_projectile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(Firing),
					TriggerOnce = Events(PreFire,Firing,StopFiring),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        [PreFire] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 15, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = ExpoGrowth, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    //EmissiveName = "BarrelHeatUp",//name of defined emissive 
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 100f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                }
                            },
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, TurnOn, TurnOff, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    //EmissiveName = "LaserEmissive",//name of defined emissive 
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 50f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
                        [StopFiring] =
                            new[] //Firing, Reloading, Overheated, Tracking, TurnOn, TurnOff, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 15, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    //EmissiveName = "BarrelCoolDown",
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 225f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 15, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    //EmissiveName = "BarrelCoolDown",
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 200f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 15, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    //EmissiveName = "BarrelCoolDown",
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 100f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
                    }
                },
               
				#endregion


            }
        };
    }
}

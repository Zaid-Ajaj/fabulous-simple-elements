// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.iOS

open System
open UIKit
open Foundation
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit FormsApplicationDelegate ()

    override this.FinishedLaunching (app, options) =
        Forms.SetFlags("CollectionView_Experimental")
        Forms.Init()
        this.LoadApplication (new SimpleFabimals.SimpleFabimalsApp())
        base.FinishedLaunching(app, options)

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main(args, null, "AppDelegate")
        0


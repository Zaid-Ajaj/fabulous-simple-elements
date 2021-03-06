﻿// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Views

open SimpleFabimals.Data
open SimpleFabimals.Components

module Bears =
    let init () =
        AnimalList.init "Bears" false Bears.data

    let update msg model =
        AnimalList.update msg model

    let view model dispatch =
        AnimalList.view model dispatch
        
module BearDetails =
    let init bear =
        AnimalDetails.init bear
    
    let view model =
        AnimalDetails.view model
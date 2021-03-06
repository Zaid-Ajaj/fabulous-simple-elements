﻿// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Views

open SimpleFabimals.Data
open SimpleFabimals.Components

module Elephants =
    let init () =
        AnimalList.init "Elephants" false Elephants.data

    let update msg model =
        AnimalList.update msg model

    let view model dispatch =
        AnimalList.view model dispatch
        
module ElephantDetails =
    let init elephant =
        AnimalDetails.init elephant
    
    let view model =
        AnimalDetails.view model
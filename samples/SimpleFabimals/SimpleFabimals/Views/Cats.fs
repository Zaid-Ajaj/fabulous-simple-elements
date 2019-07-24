// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Views

open SimpleFabimals.Data
open SimpleFabimals.Components

module Cats =
    let init () =
        AnimalList.init "Cats" true Cats.data

    let update msg model =
        AnimalList.update msg model

    let view model dispatch =
        AnimalList.view model dispatch
        
module CatDetails =
    let init cat =
        AnimalDetails.init cat
    
    let view model =
        AnimalDetails.view model
﻿module ParserTests
open NUnit.Framework
open Relay.Prelude
open FSharp.Data.Experimental.ODataProvider

[<Test>]
let ``should fail if metadata is unavailable`` () =
  match Fetch.downloadMetadata(null) with
  | Failure _ -> Assert.Pass()
  | _ -> Assert.Fail()

[<Test>]
let ``should fail if metadata does not parse`` () =
  match ODataParser.parseMetadata "" with
  | Failure _ -> Assert.Pass()
  | _ -> Assert.Fail()


[<Test>]
let ``should fail if metadata is not v4.0 or v4.01`` () =
  match ODataParser.parseMetadata Inputs.version3 with
  | Failure _ -> Assert.Pass()
  | _ -> Assert.Fail()

[<Test>]
let ``should succeed if metadata is v4.0 or v4.01`` () =
  match ODataParser.parseMetadata Inputs.version4, ODataParser.parseMetadata Inputs.version401 with
  | Success _, Success _ -> Assert.Pass()
  | _ -> Assert.Fail()
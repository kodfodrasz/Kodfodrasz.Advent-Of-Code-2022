module Kodfodrasz.AoC.Year2022.Tests.Day5Tests

open Xunit
open Swensen.Unquote.Assertions

open Kodfodrasz.AoC.Year2022
open Kodfodrasz.AoC.Year2022.Day5
open System.Collections.Generic


[<Fact>]
let ``RotateCCW works as expected`` () =
  let input = "abc\ndef\nghi"
  let expected = "cfi\nbeh\nadg"

  test
    <@ let actual = rotateCCW input
      actual = expected @>

[<Fact>]
let ``RotateCW works as expected`` () =
  let input = "abc\ndef\nghi"
  let expected = "gda\nheb\nifc"

  test
    <@ let actual = rotateCW input
      actual = expected @>

let exampleInput = """
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
"""

[<Fact>]
let ``Parsing example input (Stacks)`` () =
  let expected = [|
    new Stack<char>([ 'Z'; 'N' ]);
    new Stack<char>([ 'M'; 'C'; 'D' ]);
    new Stack<char>([ 'P' ]);
  |]

  let get = (Result.toOption >> Option.get)
  
  test
    <@ 
      let actualMaybe = parseInput exampleInput
      let actual = get actualMaybe

      actual.Stacks.Length = 3
      Seq.toList actual.Stacks[0] = Seq.toList expected[0]
      Seq.toList actual.Stacks[1] = Seq.toList expected[1]
      Seq.toList actual.Stacks[2] = Seq.toList expected[2]
    @>

// [<Fact>]
// let ``Answer 1 for example input`` () =
//   let input = parseInput exampleInput

//   test
//     <@ let actual = Result.bind answer1 input
//        let expected: Result<int, string> = Ok 157
//        actual = expected @>

// [<Theory>]
// [<InlineData('p', 16)>]
// [<InlineData('L', 38)>]
// [<InlineData('P', 42)>]
// [<InlineData('v', 22)>]
// [<InlineData('t', 20)>]
// [<InlineData('s', 19)>]
// let ``Item value`` (c, expected) =
//   let input = parseInput exampleInput

//   test
//     <@ let actual = ItemValue c
//        actual = expected @>

// [<Fact>]
// let ``Answer 2 for example input`` () =
//   let input = parseInput exampleInput

//   test
//     <@ let actual = Result.bind answer2 input
//        let expected: Result<int, string> = Ok 70
//        actual = expected @>

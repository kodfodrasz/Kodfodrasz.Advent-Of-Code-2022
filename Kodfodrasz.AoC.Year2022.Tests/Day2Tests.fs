module Kodfodrasz.AoC.Year2022.Tests.Day2Tests

open Xunit
open Swensen.Unquote.Assertions

open Kodfodrasz.AoC.Year2022
open Kodfodrasz.AoC.Year2022.Day2


let exampleInput = """
A Y
B X
C Z
  """

[<Fact>]
let ``Parsing example input`` () =
  let expected: Result<(RPSHandSign * RPSHandSign) list, string> 
    = Ok [ 
        Rock, Paper;
        Paper, Rock;
        Scissor, Scissor;
    ]

  test
    <@ let actual = parseInput exampleInput
       actual = expected @>

[<Fact>]
let ``Answer 1 for example input`` () =
  let input = parseInput exampleInput

  test
    <@ let actual = Result.bind answer1 input
       let expected: Result<int, string> = Ok 15
       actual = expected @>

[<Fact>]
let ``Answer 2 for example input`` () =
  let input = parseInput exampleInput

  test
    <@ let actual = Result.bind answer2 input
       let expected: Result<int, string> = Ok 12
       actual = expected @>

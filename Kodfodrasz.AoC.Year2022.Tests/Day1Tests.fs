module Kodfodrasz.AoC.Year2022.Tests.Day1Tests

open Xunit
open Swensen.Unquote.Assertions

open Kodfodrasz.AoC.Year2022
open Kodfodrasz.AoC.Year2022.Day1


let exampleInput = """
  1721
  979
  366
  299
  675
  1456
  """

[<Fact>]
let ``Parsing example input`` () =
  let expected: Result<int list, string> = Ok [ 1721; 979; 366; 299; 675; 1456 ]

  test
    <@ let actual = parseInput exampleInput
       actual = expected @>

[<Fact>]
let ``Answer 1 for example input`` () =
  let input = parseInput exampleInput

  test
    <@ let actual = Result.bind answer1 input
       let expected: Result<int, string> = Ok 514579
       actual = expected @>

[<Fact>]
let ``Answer 2 for example input`` () =
  let input = parseInput exampleInput

  test
    <@ let actual = Result.bind answer2 input
       let expected: Result<int, string> = Ok 241861950
       actual = expected @>

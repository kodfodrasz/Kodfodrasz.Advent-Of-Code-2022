module Kodfodrasz.AoC.Year2022.Tests.Day4Tests

open Xunit
open Swensen.Unquote.Assertions

open Kodfodrasz.AoC.Year2022
open Kodfodrasz.AoC.Year2022.Day4


let exampleInput = """
2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
"""

// [<Fact>]
// let ``Parsing example input`` () =
//   let expected: Result<Rucksack list, string> 
//     = Ok [ 
//         { FirstCompartment = (chrl "vJrwpWtwJgWr")
//           SecondCompartment = (chrl "hcsFMMfFFhFp")};
//         { FirstCompartment = (chrl "jqHRNqRjqzjGDLGL")
//           SecondCompartment = (chrl "rsFMfFZSrLrFZsSL")};
//         { FirstCompartment = (chrl "PmmdzqPrV")
//           SecondCompartment = (chrl "vPwwTWBwg")};
//         { FirstCompartment = (chrl "wMqvLMZHhHMvwLH")
//           SecondCompartment = (chrl "jbvcjnnSBnvTQFn")};
//         { FirstCompartment = (chrl "ttgJtRGJ")
//           SecondCompartment = (chrl "QctTZtZT")};
//         { FirstCompartment = (chrl "CrZsJsPPZsGz")
//           SecondCompartment = (chrl "wwsLwLmpwMDw")};
//     ]

//   test
//     <@ let actual = parseInput exampleInput
//        actual = expected @>

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

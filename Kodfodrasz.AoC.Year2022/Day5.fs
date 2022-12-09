module Kodfodrasz.AoC.Year2022.Day5

open System
open Kodfodrasz.AoC


let parseInput (input: string): Result<obj list, string> =
    // input.Split('\n')
    // |> Seq.map String.trim
    // |> Seq.where String.notNullOrWhiteSpace
    // |> Seq.map parseLine
    // |> Seq.toList
    // |> Ok
  Error "TODO"

let answer1 input =
  Error "TODO"

let answer2 input =
  Error "TODO"
  
type Solver() =
  inherit SolverBase("Supply Stacks")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1;  answer2  ] input

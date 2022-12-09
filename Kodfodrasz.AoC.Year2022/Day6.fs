module Kodfodrasz.AoC.Year2022.Day6

open System
open Kodfodrasz.AoC


let parseInput (input: string) : Result<_, string> =
    input.Split('\n')
    |> Seq.map String.trim
    |> Seq.where String.notNullOrWhiteSpace
    |> Seq.exactlyOne
    |> (fun s -> s.ToCharArray())
    |> Ok

let uniqueRunFinder uniqueCount symbols : Result<_, string> =
  let nums = Seq.initInfinite ((+) 1)
  let windowSize = uniqueCount

  let UniqueSymbolCount grp =
    let s = Array.map snd grp |> Set.ofArray
    (Set.count s)

  Seq.zip nums symbols 
  |> Seq.windowed windowSize
  |> Seq.choose (fun grp -> 
    match (UniqueSymbolCount grp) with
    | x when x = windowSize -> grp |> Seq.rev |> Seq.head |> fst |> Some
    | _ -> None)
  |> Seq.head
  |> Ok  

let answer1 = uniqueRunFinder 4

let answer2 = uniqueRunFinder 14

type Solver() =
  inherit SolverBase("Tuning Trouble")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1;  answer2  ] input

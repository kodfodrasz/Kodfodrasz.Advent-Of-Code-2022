module Kodfodrasz.AoC.Year2022.Day5

open System
open Kodfodrasz.AoC
open System.Collections.Generic

type PuzzleInput = {
  Stacks : Stack<char> array
}

let rotateCW (str:string) : string = 
  str.Split("\n")
  |> Seq.map (fun s -> s.TrimEnd('\r'))
  |> Seq.transpose
  |> Seq.map (Seq.rev >> Seq.toArray >> String)
  |> String.join "\n"

let rotateCCW (str:string) : string = 
  str.Split("\n")
  |> Seq.map (fun s -> s.TrimEnd('\r'))
  |> Seq.transpose
  |> Seq.rev
  |> Seq.map (Seq.toArray >> String)
  |> String.join "\n"

let parseInput (input: string): Result<PuzzleInput, string> =
  let parts = 
    input.Split('\n')
    |> Seq.skipWhile String.notNullOrWhiteSpace
    // stack initial definition 
    |> Seq.batchByPredicate String.IsNullOrWhiteSpace
    |> Seq.toList

  let p1str = 
    Seq.head parts
    |> String.join "\n"

  let stacks = 
    rotateCW p1str
    |> String.split [|'\n'|]
    |> Seq.map (fun l -> l.Replace("[", " ").Replace("]", " "))
    |> Seq.where String.notNullOrWhiteSpace
    |> Seq.map (fun line -> line.Trim() |> Seq.tail |> Seq.toList)
    |> Seq.toList
    |> Seq.map Stack<char>
    |> Seq.toArray
  
  Ok {
    Stacks = stacks
  }


let answer1 input =
  Error "TODO"

let answer2 input =
  Error "TODO"
  
type Solver() =
  inherit SolverBase("Supply Stacks")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1;  answer2  ] input

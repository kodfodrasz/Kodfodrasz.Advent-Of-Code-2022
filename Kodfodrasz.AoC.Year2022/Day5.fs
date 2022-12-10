module Kodfodrasz.AoC.Year2022.Day5

open System
open Kodfodrasz.AoC
open System.Collections.Generic
open System.Text.RegularExpressions

type MoveCommand = {
  Count: int
  From : int
  To   : int
}

type PuzzleInput = {
  // stacks listed from bottom up, in push order!
  Stacks : char list list
  Moves  : MoveCommand list
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

let parseMoveCommandLine (line: string) =
  Regex.Match(line, @"^move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)")
  |> function
  | m when m.Success ->
      let countMaybe = m.Groups.["count"].Value |> Parse.parseInt

      let fromMaybe =
        m.Groups.["from"].Value |> Parse.parseInt

      let toMaybe =
        m.Groups.["to"].Value |> Parse.parseInt

      (countMaybe, fromMaybe, toMaybe)
      |||> Option.map3
             (fun count from to_ -> 
               { Count = count
                 From  = from
                 To    = to_ })
  | _ -> None

let parseInput (input: string): Result<PuzzleInput, string> =
  let parts = 
    input.Split('\n')
    |> Seq.skipWhile String.isNullOrWhiteSpace
    // stack initial definition 
    // TODO: rename this batching function to a more meaningful name
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
    //|> Seq.map Stack<char>
    //|> Seq.toArray
  
  let moves = 
    Seq.tail parts
    |> Seq.exactlyOne
    |> Seq.where String.notNullOrWhiteSpace
    |> Seq.map parseMoveCommandLine
    // no error checking now
    |> Seq.choose id
    |> Seq.toList

  Ok {
    Stacks = stacks
    Moves  = moves
  }


let answer1 input =
  // use 1-based array indexing to match the stack-indexes used in the problem
  // this is supported conveniently only Array2D, not in 1-dimensional arrays, so it is used
  let arr  = Array2D.createBased<Stack<char>> 0 1 1 (Seq.length input.Stacks) null
  
  // load the data to the array in the form of stacks
  input.Stacks
  |> Seq.iteri (fun idx s -> arr[0,(idx+1)] <- Stack s)

  input.Moves
  |> Seq.iter (fun move -> 
     [1..move.Count] 
     |> Seq.iter (fun i ->
        let c = arr[0,move.From].Pop()
        arr[0,move.To].Push(c)
     )
  )

  let top = 
    arr
    |> Seq.cast<Stack<char>>
    |> Seq.map (fun stack -> stack.Peek())
    |> Seq.toArray
    |> String

  Ok top

let answer2 input =
  Error "TODO"
  
type Solver() =
  inherit SolverBase("Supply Stacks")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1;  answer2  ] input

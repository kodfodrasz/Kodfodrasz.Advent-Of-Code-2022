module Kodfodrasz.AoC.Year2022.Day3

open System
open Kodfodrasz.AoC

type Rucksack = 
  {
    FirstCompartment : char list
    SecondCompartment : char list
  }

let parseLine (line: string) =
  let items = line.Length / 2
  
  let first = 
    line
     |> Seq.take items
     |> Seq.toList
  let second =
    line
    |> Seq.skip items
    |> Seq.take items
    |> Seq.toList

  { 
    FirstCompartment = first;
    SecondCompartment = second}

let parseInput (input: string): Result<Rucksack list, string> =
    input.Split('\n')
    |> Seq.map String.trim
    |> Seq.where String.notNullOrWhiteSpace
    |> Seq.map parseLine
    |> Seq.toList
    |> Ok


let ItemValue (item :char) : int =
  let a = 'a'
  if Char.IsAsciiLetter(item) then
    if Char.IsLower(item) then
      1 + ((int item) - (int 'a'))
    else
      27 + ((int item) - (int 'A'))    
  else
    0

let answer1 rucksacks  =
  rucksacks
  |> Seq.map (fun (r :Rucksack) -> 
       let first = Set.ofList r.FirstCompartment
       let second = Set.ofList r.SecondCompartment
       
       Set.intersect first second
       |> Set.toSeq
       |> Seq.map ItemValue
       |> Seq.exactlyOne       
    )
  |> Seq.sum
  |> Ok


let answer2 rucksacks =
  rucksacks
  |> Seq.chunkBySize 3
  |> Seq.map (fun (grp :Rucksack array) -> 
      let ru r =
        Set.union (Set.ofList r.FirstCompartment) (Set.ofList r.SecondCompartment)

      let first = ru grp[0]
      let second = ru grp[1]
      let third = ru grp[2]

      Set.intersectMany [ first; second; third ]
      |> Set.toSeq
      |> Seq.exactlyOne
      |> ItemValue
    )
  |> Seq.sum
  |> Ok
  
type Solver() =
  inherit SolverBase("Rucksack Reorganization")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1; answer2 ] input

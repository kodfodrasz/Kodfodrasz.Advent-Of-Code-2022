module Kodfodrasz.AoC.Year2022.Day1

open Kodfodrasz.AoC


let parseInput (input: string): Result<int list, string> =
  let numbersMaybe =
    input.Split('\n')
    |> Seq.map String.trim
    |> Seq.filter String.notNullOrWhiteSpace
    |> Seq.map (fun line -> (line, Parse.parseInt line))
    |> Seq.toList

  let errorMaybe =
    Seq.tryFind (fun (_, numMaybe) -> Option.isNone numMaybe) numbersMaybe

  match errorMaybe with
  | None ->
      numbersMaybe
      |> Seq.map (fun (_, num) -> Option.get num)
      |> Seq.toList
      |> Ok
  | Some (line, _) ->
      sprintf "Input line could not be parsed to integer: %s" line
      |> Error

let answer1 numbers =
  let pair =
    Sets.descartes2 numbers numbers
    |> Seq.filter (fun (a, b) -> a <> b)
    |> Seq.distinctBy (fun (a, b) -> ((min a b), (max a b)))
    |> Seq.filter (fun (a, b) -> a + b = 2020)
    |> Seq.tryExactlyOne
    |> Result.ofOption "Not exactly one matching number pair found"

  pair |> Result.map (fun (a, b) -> a * b)

let answer2 numbers =
  let triplet =
    Sets.descartes3 numbers numbers numbers
    |> Seq.filter (fun (a, b, c) -> a <> b && a <> c && b <> c)
    |> Seq.distinctBy (fun (a, b, c) -> List.sort [ a; b; c ])
    |> Seq.filter (fun (a, b, c) -> a + b + c = 2020)
    |> Seq.tryExactlyOne
    |> Result.ofOption "Not exactly one matching number triplet found"

  triplet |> Result.map (fun (a, b, c) -> a * b * c)

type Solver() =
  inherit SolverBase("Report Repair")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1; answer2 ] input

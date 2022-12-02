module Kodfodrasz.AoC.Year2022.Day2

open System
open Kodfodrasz.AoC

type RPSHandSign = 
| Rock
| Paper
| Scissor

let parseLine (line: string) =
  let parts = line.Split(" ", (StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries))
  
  let opponent = 
    match(parts[0]) with
    | "A" -> Some Rock
    | "B" -> Some Paper
    | "C" -> Some Scissor
    | _ -> None
  let me = 
    match(parts[1]) with
    | "X" -> Some Rock
    | "Y" -> Some Paper
    | "Z" -> Some Scissor
    | _ -> None

  Option.map2 (fun o m -> (o,m)) opponent me 
  

let parseInput (input: string): Result<(RPSHandSign * RPSHandSign) list, string> =
  let numbersMaybe =
    input.Split('\n')
    |> Seq.map String.trim
    |> Seq.where String.notNullOrWhiteSpace
    |> Seq.map (fun line -> (line, parseLine line))
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
      sprintf "Input line cloud not be parsed to integer: %s" line
      |> Error


type Outcome =
| Win
| Loose
| Draw

let Eval opponent me =
  match (me, opponent) with
  | Paper, Rock    -> Win
  | Scissor, Paper -> Win
  | Rock, Scissor  -> Win
  | Rock, Paper    -> Loose
  | Paper, Scissor -> Loose
  | Scissor, Rock  -> Loose
  | _ -> Draw

let BetValue bet = 
  match bet with
  | Rock    -> 1
  | Paper   -> 2
  | Scissor -> 3

let OutcomeValue outcome = 
  match outcome with
  | Win   -> 6
  | Loose -> 0
  | Draw  -> 3

let answer1 (numbers : (RPSHandSign * RPSHandSign) list) =
  numbers
  |> Seq.map (fun (opp, me) -> (BetValue me) + ((Eval opp me |> OutcomeValue)))
  |> Seq.sum
  |> Ok

let ReparseSecondColumn bet =
  match bet with
  | Rock    ->  Loose
  | Paper   ->  Draw
  | Scissor ->  Win

let DeduceBet opponent outcome = 
  match outcome, opponent with
  | Draw, _ -> opponent
  | Win, Rock -> Paper
  | Win, Paper -> Scissor
  | Win, Scissor -> Rock
  | Loose, Rock -> Scissor
  | Loose, Paper -> Rock
  | Loose, Scissor -> Paper

let answer2 numbers =
  numbers
  |> Seq.map (fun (opp, result) -> 
    let outcome = ReparseSecondColumn result
    let me = DeduceBet opp outcome
    (BetValue me) + (OutcomeValue outcome))
  |> Seq.sum
  |> Ok

type Solver() =
  inherit SolverBase("Rock Paper Scissors")
  with
    override this.Solve input =
      this.DoSolve parseInput [ answer1; answer2 ] input

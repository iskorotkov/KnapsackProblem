namespace KnapsackProblem.Implementation.FSharp

open Knapsack
open System

type public MySuperSolver() =
  interface ISolver with
    member _this.GetName() = "Точный переборный алгоритм Ивана"
    member _this.Solve(max, w, c) =
      let weights = List.ofArray w
      let costs = List.ofArray c
      let rec solve available (weights, costs) (curCost, curFlags) =
        if available <= 0 then (0, [])
        else match (weights, costs) with
              | ([], []) -> (curCost, curFlags)
              | (weight::wtail, cost::ctail) ->
                  let res1 = solve available (wtail, ctail) (curCost, false::curFlags)
                  let res2 = solve (available-weight) (wtail, ctail) (curCost+cost, true::curFlags)
                  if fst res1 > fst res2 then res1 else res2
              | _ -> (0, [])
      solve max (weights, costs) (0, [])
      |> snd
      |> List.rev
      |> List.toArray

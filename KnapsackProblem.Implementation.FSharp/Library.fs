namespace KnapsackProblem.Implementation.FSharp

open Knapsack
open System

type public MySuperSolver() =
  interface ISolver with
    member _this.GetName() = "Самый лучший алгоритм"
    member _this.Solve(M, m, c) =
      let weights = List.ofArray m
      let costs = List.ofArray c
      let rec solve max (weights, costs) (curWeight, curCost, curFlags) =
        if curWeight > max then (0, [])
        else match (weights, costs) with
              | ([], []) -> (curCost, curFlags)
              | (wh::wt, ch::ct) ->
                  let res1 = solve max (wt, ct) (curWeight, curCost, false::curFlags)
                  let res2 = solve max (wt, ct) (curWeight+wh, curCost+ch, true::curFlags)
                  if fst res1 > fst res2 then res1 else res2
              | _ -> (0, [])
      let represent max weights costs = List.rev (snd (solve max (weights, costs) (0, 0, [])))
      List.toArray (represent M weights costs)

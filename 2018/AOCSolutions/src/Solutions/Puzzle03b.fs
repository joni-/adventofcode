// --- Part Two ---
// Amidst the chaos, you notice that exactly one claim doesn't overlap by even a single square inch of fabric with any other claim. If you can somehow draw attention to it, maybe the Elves will be able to make Santa's suit after all!

// For example, in the claims above, only claim 3 is intact after all claims are made.

// What is the ID of the only claim that doesn't overlap?

namespace Solutions

open System
open System.IO

module Puzzle03b =
    type Size = int * int
    type Position = int * int

    let parseSize (sizeString: string): Size =
      let parts = sizeString.Trim().Split [|'x'|]
      let width = Int32.Parse (Seq.head parts)
      let height = Int32.Parse (Seq.last parts)
      (width, height)

    let parsePosition (positionString: string): Position =
      let parts = positionString.Trim().Split [|','|]
      let x = Int32.Parse (Seq.head parts)
      let y = Int32.Parse (Seq.last parts)
      (x, y)

    let parseSingleClaim(claim: string): seq<Position> =
      let splitted = claim.Split [|'@'|]
      let positionAndSizeString = Seq.last splitted
      let positionAndSizeParts = positionAndSizeString.Split [|':'|]
      let size = parseSize(Seq.last positionAndSizeParts)
      let position = parsePosition(Seq.head positionAndSizeParts)

      let xs = { fst position .. fst position + fst size - 1 }
      let ys = { snd position .. snd position + snd size - 1 }
      Seq.allPairs xs ys

    let increaseCount(m: Map<Position, int>, position: Position): Map<Position, int> =
      let maybeValue = m.TryFind(position)
      let newValue = match maybeValue with
                      | Some x -> x + 1
                      | None -> 1
      m.Add(position, newValue)


    let solve (input: string) =
      let claims = Seq.map (fun (s: string) -> s.Trim()) (input.Split [|'\n'|])
      let occupiedPositions = Seq.fold Seq.append Seq.empty (Seq.map parseSingleClaim claims)
      let countsAtPositions = Seq.fold (fun acc pos -> increaseCount(acc, pos)) Map.empty occupiedPositions
      let claimsToPositions = Seq.map (fun claim -> (claim, parseSingleClaim(claim))) claims

      let nonConflictingClaim = Seq.find (fun (claim, positions) ->
                                    Seq.forall (fun position -> countsAtPositions.[position] = 1) positions
                                ) claimsToPositions

      fst nonConflictingClaim

    let readFileAndSolve (file: string) = solve(File.ReadAllText(file))

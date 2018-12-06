// --- Day 3: No Matter How You Slice It ---
// The Elves managed to locate the chimney-squeeze prototype fabric for Santa's suit (thanks to someone who helpfully wrote its box IDs on the wall of the warehouse in the middle of the night). Unfortunately, anomalies are still affecting them - nobody can even agree on how to cut the fabric.

// The whole piece of fabric they're working on is a very large square - at least 1000 inches on each side.

// Each Elf has made a claim about which area of fabric would be ideal for Santa's suit. All claims have an ID and consist of a single rectangle with edges parallel to the edges of the fabric. Each claim's rectangle is defined as follows:

// The number of inches between the left edge of the fabric and the left edge of the rectangle.
// The number of inches between the top edge of the fabric and the top edge of the rectangle.
// The width of the rectangle in inches.
// The height of the rectangle in inches.
// A claim like #123 @ 3,2: 5x4 means that claim ID 123 specifies a rectangle 3 inches from the left edge, 2 inches from the top edge, 5 inches wide, and 4 inches tall. Visually, it claims the square inches of fabric represented by # (and ignores the square inches of fabric represented by .) in the diagram below:

// ...........
// ...........
// ...#####...
// ...#####...
// ...#####...
// ...#####...
// ...........
// ...........
// ...........
// The problem is that many of the claims overlap, causing two or more claims to cover part of the same areas. For example, consider the following claims:

// #1 @ 1,3: 4x4
// #2 @ 3,1: 4x4
// #3 @ 5,5: 2x2
// Visually, these claim the following areas:

// ........
// ...2222.
// ...2222.
// .11XX22.
// .11XX22.
// .111133.
// .111133.
// ........
// The four square inches marked with X are claimed by both 1 and 2. (Claim 3, while adjacent to the others, does not overlap either of them.)

// If the Elves all proceed with their own plans, none of them will have enough fabric. How many square inches of fabric are within two or more claims?

namespace Solutions

open System

module Puzzle03a =
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
      let conflictingPositions = Map.filter (fun k v -> v > 1) countsAtPositions
      Map.count conflictingPositions

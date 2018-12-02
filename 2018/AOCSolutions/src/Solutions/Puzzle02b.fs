// --- Part Two ---
// Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.

// The boxes will have IDs which differ by exactly one character at the same position in both strings. For example, given the following box IDs:

// abcde
// fghij
// klmno
// pqrst
// fguij
// axcye
// wvxyz
// The IDs abcde and axcye are close, but they differ by two characters (the second and fourth). However, the IDs fghij and fguij differ by exactly one character, the third (h and u). Those must be the correct boxes.

// What letters are common between the two correct box IDs? (In the example above, this is found by removing the differing character from either ID, producing fgij.)

namespace Solutions

open System
open System.IO

module Puzzle02b =
    let createInfiniteSeq (ids: string[]) = Seq.initInfinite (fun index ->
      let lookupIDs = Seq.map (fun (s: string) -> s.Remove(index, 1)) ids
      Seq.countBy id lookupIDs
    )

    let hasIt (input: seq<string * int>) =
      Seq.exists (fun (_, count) -> count = 2) input

    let getIt (input: seq<string * int>) =
      let group = Seq.find (fun (_, count) -> count = 2) input
      fst group

    let solve (input: string) =
      let ids = input.Split [|'\n'|]
      let infiniteSeq = createInfiniteSeq(ids)

      let group = Seq.find hasIt infiniteSeq
      getIt group

    let readFileAndSolve (file: string) = solve(File.ReadAllText(file))

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

module Puzzle02b =
    let createLookupTables (ids: string[]) = Seq.initInfinite (fun index ->
      let idsWithOneCharRemoved = ids |> Seq.map (fun s -> s.Remove(index, 1))
      Seq.countBy id idsWithOneCharRemoved
    )

    let containsDuplicateID (input: seq<string * int>) =
      input |> Seq.exists (fun (_, count) -> count = 2)

    let getDuplicateID (input: seq<string * int>) =
      let group = input |> Seq.find (fun (_, count) -> count = 2)
      fst group

    let solve (input: string) =
      let ids = input |> Util.splitByRow |> Seq.toArray
      let duplicateID = ids
                      |> createLookupTables
                      |> Seq.find containsDuplicateID
                      |> getDuplicateID
      duplicateID

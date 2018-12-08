namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle07Test () =
    [<Test>]
    member this.ParseSource () =
        let input = "Step C must be finished before step A can begin."
        let result = Solutions.Puzzle07.parseSource(input)
        Assert.AreEqual(("C", "A"), result)

    [<Test>]
    member this.Advance_1 () =
        let steps = [("C", "A"); ("B", "C")]
        let result = Solutions.Puzzle07.advance "" steps
        Assert.AreEqual("B", fst result)

    [<Test>]
    member this.Advance_2 () =
        let steps = [
            ("C", "A");
            ("C", "F");
            ("A", "B");
            ("A", "D");
            ("B", "E");
            ("D", "E");
            ("F", "E");
        ]
        let result = Solutions.Puzzle07.advance "" steps
        Assert.AreEqual("C", fst result)

    [<Test>]
    member this.Advance_3 () =
        let steps = [
            ("A", "B");
            ("A", "D");
            ("B", "E");
            ("D", "E");
            ("F", "E");
        ]
        let result = Solutions.Puzzle07.advance "C" steps
        Assert.AreEqual("CA", fst result)

    [<Test>]
    member this.Advance_4 () =
        let steps = [
            ("B", "E");
            ("D", "E");
            ("F", "E");
        ]
        let result = Solutions.Puzzle07.advance "CA" steps
        Assert.AreEqual("CAB", fst result)

    [<Test>]
    member this.Advance_5 () =
        let steps = [
            ("D", "E");
            ("F", "E");
        ]
        let result = Solutions.Puzzle07.advance "CAB" steps
        Assert.AreEqual("CABD", fst result)

    [<Test>]
    member this.Advance_6 () =
        let steps = [
            ("F", "E");
        ]
        let result = Solutions.Puzzle07.advance "CABD" steps
        Assert.AreEqual("CABDFE", fst result)

    [<Test>]
    member this.TestA () =
        let input = "Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin."
        let result = Solutions.Puzzle07.solveA(input)
        Assert.AreEqual("CABDFE", result)

    [<Test>]
    member this.DurationForStep () =
        Assert.AreEqual(61, Solutions.Puzzle07.duration "A")
        Assert.AreEqual(63, Solutions.Puzzle07.duration "C")
        Assert.AreEqual(86, Solutions.Puzzle07.duration "Z")

    [<Test>]
    member this.TestB () =
        let input = "Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin."
        let result = Solutions.Puzzle07.solveB(input)
        Assert.AreEqual(-1, result)

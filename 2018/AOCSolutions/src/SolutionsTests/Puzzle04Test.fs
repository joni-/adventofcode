namespace Tests

open NUnit.Framework
open Solutions
open NUnit.Framework
open System



[<TestClass>]
type Puzzle04aTest () =
    [<Test>]
    member this.ParseLogEntry () =
        let input = "[1518-11-01 00:20] Guard #10 begins shift"
        let result = Solutions.Puzzle04.parseLogEntry(input)
        Assert.AreEqual("Guard #10 begins shift", result.Action)
        Assert.AreEqual(DateTime(1518, 11, 1, 0, 20, 0), result.Timestamp)

    [<Test>]
    member this.SortLogEntries () =
        let input = "[1518-11-01 00:25] wakes up
                     [1518-11-02 00:05] falls asleep
                     [1518-11-01 00:20] Guard #10 begins shift"
        let result = Solutions.Puzzle04.parseAndSortLogs(input)
        let arr = Seq.toArray result
        Assert.AreEqual("Guard #10 begins shift", arr.[0].Action)
        Assert.AreEqual("wakes up", arr.[1].Action)
        Assert.AreEqual("falls asleep", arr.[2].Action)

    [<Test>]
    member this.ParseID () =
        let input = "[1518-11-01 00:20] Guard #10 begins shift"
        let result = Solutions.Puzzle04.parseID(input)
        Assert.AreEqual(10, result)


    [<Test>]
    member this.Test1_A () =
        let input = "[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up"
        let result = Solutions.Puzzle04.solveA(input)
        Assert.AreEqual(240, result)

    [<Test>]
    member this.Test1_B () =
        let input = "[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up"
        let result = Solutions.Puzzle04.solveB(input)
        Assert.AreEqual(4455, result)

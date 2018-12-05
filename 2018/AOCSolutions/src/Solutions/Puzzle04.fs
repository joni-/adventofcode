// --- Day 4: Repose Record ---
// You've sneaked into another supply closet - this time, it's across from the prototype suit manufacturing lab. You need to sneak inside and fix the issues with the suit, but there's a guard stationed outside the lab, so this is as close as you can safely get.

// As you search the closet for anything that might help, you discover that you're not the first person to want to sneak in. Covering the walls, someone has spent an hour starting every midnight for the past few months secretly observing this guard post! They've been writing down the ID of the one guard on duty that night - the Elves seem to have decided that one guard was enough for the overnight shift - as well as when they fall asleep or wake up while at their post (your puzzle input).

// For example, consider the following records, which have already been organized into chronological order:

// [1518-11-01 00:00] Guard #10 begins shift
// [1518-11-01 00:05] falls asleep
// [1518-11-01 00:25] wakes up
// [1518-11-01 00:30] falls asleep
// [1518-11-01 00:55] wakes up
// [1518-11-01 23:58] Guard #99 begins shift
// [1518-11-02 00:40] falls asleep
// [1518-11-02 00:50] wakes up
// [1518-11-03 00:05] Guard #10 begins shift
// [1518-11-03 00:24] falls asleep
// [1518-11-03 00:29] wakes up
// [1518-11-04 00:02] Guard #99 begins shift
// [1518-11-04 00:36] falls asleep
// [1518-11-04 00:46] wakes up
// [1518-11-05 00:03] Guard #99 begins shift
// [1518-11-05 00:45] falls asleep
// [1518-11-05 00:55] wakes up
// Timestamps are written using year-month-day hour:minute format. The guard falling asleep or waking up is always the one whose shift most recently started. Because all asleep/awake times are during the midnight hour (00:00 - 00:59), only the minute portion (00 - 59) is relevant for those events.

// Visually, these records show that the guards are asleep at these times:

// Date   ID   Minute
//             000000000011111111112222222222333333333344444444445555555555
//             012345678901234567890123456789012345678901234567890123456789
// 11-01  #10  .....####################.....#########################.....
// 11-02  #99  ........................................##########..........
// 11-03  #10  ........................#####...............................
// 11-04  #99  ....................................##########..............
// 11-05  #99  .............................................##########.....
// The columns are Date, which shows the month-day portion of the relevant day; ID, which shows the guard on duty that day; and Minute, which shows the minutes during which the guard was asleep within the midnight hour. (The Minute column's header shows the minute's ten's digit in the first row and the one's digit in the second row.) Awake is shown as ., and asleep is shown as #.

// Note that guards count as asleep on the minute they fall asleep, and they count as awake on the minute they wake up. For example, because Guard #10 wakes up at 00:25 on 1518-11-01, minute 25 is marked as awake.

// If you can figure out the guard most likely to be asleep at a specific time, you might be able to trick that guard into working tonight so you can have the best chance of sneaking in. You have two strategies for choosing the best guard/minute combination.

// Strategy 1: Find the guard that has the most minutes asleep. What minute does that guard spend asleep the most?

// In the example above, Guard #10 spent the most minutes asleep, a total of 50 minutes (20+25+5), while Guard #99 only slept for a total of 30 minutes (10+10+10). Guard #10 was asleep most during minute 24 (on two days, whereas any other minute the guard was asleep was only seen on one day).

// While this example listed the entries in chronological order, your entries are in the order you found them. You'll need to organize them before they can be analyzed.

// What is the ID of the guard you chose multiplied by the minute you chose? (In the above example, the answer would be 10 * 24 = 240.)

// --- Part Two ---
// Strategy 2: Of all guards, which guard is most frequently asleep on the same minute?

// In the example above, Guard #99 spent minute 45 asleep more than any other guard or minute - three times in total. (In all other cases, any guard spent any minute asleep at most twice.)

// What is the ID of the guard you chose multiplied by the minute you chose? (In the above example, the answer would be 99 * 45 = 4455.)

namespace Solutions

open System
open System.IO
open System.Text.RegularExpressions

module Puzzle04 =
    type EntryType = GuardSwitch | FallSleep | Wakeup

    type LogEntry(timestamp: DateTime, action: string, entryType: EntryType) =
        member this.Timestamp = timestamp
        member this.Action = action

        member this.EntryType = entryType

    type GuardLog(id: int, logEntries: seq<LogEntry>) =
        member this.Id = id
        member this.LogEntries = logEntries

    let parseTimeStamp(input: string): DateTime =
        let timestampString = input.Substring(1, input.IndexOf("]") - 1)
        let parts = timestampString.Split([|' '|])
        let dateString = Seq.head parts
        let timeString = Seq.last parts

        let dateParts = Seq.toArray (dateString.Split([|'-'|]))
        let year = dateParts.[0] |> int
        let month = dateParts.[1] |> int
        let day = dateParts.[2] |> int

        let timeParts = timeString.Split([|':'|])
        let hours = Seq.head timeParts |> int
        let minutes = Seq.last timeParts |> int

        DateTime(year, month, day, hours, minutes, 0)

    let parseLogEntry (input: string): LogEntry =
        let timestamp = parseTimeStamp(input)
        let action = (Seq.last (input.Split([|']'|]))).Trim()
        let entryType = match action with
                        | action when action.Contains("Guard") -> GuardSwitch
                        | action when action.Contains("falls asleep") -> FallSleep
                        | _ -> Wakeup
        LogEntry(timestamp, action, entryType)

    let parseAndSortLogs (input: string): seq<LogEntry> =
        let logEntries = Seq.map parseLogEntry (Seq.map (fun (s: string) -> s.Trim()) (input.Split([|'\n'|])))
        Seq.sortBy (fun entry -> entry.Timestamp) logEntries

    let (|ParseRegex|) regex str =
        let m = Regex(regex).Match(str)
        m.Value.Substring(1)

    let parseID (input: string): int =
        match input with
            | ParseRegex "#\d+" id -> id |> int

    let buildGuardLog(logEntries: seq<LogEntry>): Map<int, seq<LogEntry>> =
        let rec helper(acc: Map<int, seq<LogEntry>>, entriesLeft: seq<LogEntry>): Map<int, seq<LogEntry>> =
            if Seq.isEmpty entriesLeft then acc
            else
                let id = parseID (Seq.head entriesLeft).Action
                let logsWithoutFirstGuardSwitch = Seq.skip 1 entriesLeft
                let guardEntries = Seq.takeWhile (fun (e: LogEntry) -> e.EntryType <> GuardSwitch) logsWithoutFirstGuardSwitch
                let newEntries = match acc.TryFind(id) with
                                    | Some entries -> Seq.append guardEntries entries
                                    | None -> guardEntries
                helper(acc.Add(id, newEntries), Seq.skip (Seq.length guardEntries) logsWithoutFirstGuardSwitch)

        helper(Map.empty, logEntries)

    type GuardSleepStats(id: int, stats: Map<int, int>) =
        member this.Id = id
        member this.Stats = stats

    let everyOther elements =
        elements
        |> Seq.mapi (fun i e -> if i % 2 = 0 then Some(e) else None)
        |> Seq.choose id

    let guardSleepStats (id: int, logEntries: seq<LogEntry>): GuardSleepStats =
        if Seq.isEmpty logEntries then GuardSleepStats(id, Map.empty)
        else
            let fallAsSleepEntries = everyOther logEntries
            let wakeupEntries = everyOther (Seq.tail logEntries)
            let pairs = Seq.zip fallAsSleepEntries wakeupEntries
            let stats = Seq.fold (fun (acc: Map<int, int>) (a: LogEntry, b: LogEntry) ->
                            let minutesAsleep: seq<int> = { a.Timestamp.Minute .. b.Timestamp.Minute - 1 }
                            Seq.fold (fun inner (minute) ->
                                let newValue = match inner.TryFind(minute) with
                                                | Some x -> x + 1
                                                | None -> 1
                                inner.Add(minute, newValue)
                            ) acc minutesAsleep
                        ) Map.empty pairs
            GuardSleepStats(id, stats)

    let solveA (input: string) =
        let logEntries = parseAndSortLogs(input)
        let guardLog = buildGuardLog(logEntries)

        let guardLogSleepIntervals = Seq.map guardSleepStats (Map.toSeq guardLog)

        let mostSleep = Seq.maxBy (fun (i: GuardSleepStats) ->
                            let values = Seq.map snd (Map.toSeq i.Stats)
                            Seq.sum values
                        ) guardLogSleepIntervals

        let mostSleptGuardID = mostSleep.Id
        let mostSleptMinute = fst (Seq.maxBy (fun (k, v) -> v) (Map.toSeq mostSleep.Stats))
        mostSleptGuardID * mostSleptMinute

    let maxSleepMinute (stats: Map<int, int>): int * int =
        Seq.maxBy (fun (minute, count) -> count) (Map.toSeq stats)

    let solveB (input: string) =
        let logEntries = parseAndSortLogs(input)
        let guardLog = buildGuardLog(logEntries)
        let guardLogSleepIntervals = Seq.filter (fun (i: GuardSleepStats) -> not (Seq.isEmpty i.Stats)) (Seq.map guardSleepStats (Map.toSeq guardLog))

        let guardWithMostSleepOnSingleMinute = Seq.maxBy (fun (i: GuardSleepStats) ->
                                                    snd (maxSleepMinute i.Stats)
                                                ) guardLogSleepIntervals
        let maxSleep = maxSleepMinute guardWithMostSleepOnSingleMinute.Stats

        guardWithMostSleepOnSingleMinute.Id * fst maxSleep

    let readFileAndSolveA (file: string) = solveA(File.ReadAllText(file))
    let readFileAndSolveB (file: string) = solveB(File.ReadAllText(file))

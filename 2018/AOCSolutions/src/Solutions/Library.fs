namespace Solutions

module Say =
    let hello name =
        let result = "Hello, " + name
        result

module Util =
    let splitByRow (input: string) =
        input.Trim().Split([|'\n'|]) |> Seq.map (fun s -> s.Trim())
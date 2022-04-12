let foo11Down n =
    let rec loop n div counter =
        if div = 0 then counter
        else 
            let nextCounter = counter + 1
            let nextDiv = div - 1
            if n % div = 0 then loop n nextDiv nextCounter
            else loop n nextDiv counter
    loop n n 0

let foo11Up n =
    let rec loop n div =
        if div = 0 then 0
        else if n % div = 0 then 1 + loop n (div - 1)
             else loop n (div - 1)
    loop n n

let foo12Down list =
    let rec loop list product =
        match list with
        |head::tail ->
            let nextProduct = head * product
            if head % 2 = 0 then loop tail nextProduct
            else loop tail product
        |[] -> product
    loop list 1

let rec foo12Up list =
    match list with
    |head::tail ->
        if head % 2 = 0 then head * (foo12Up tail)
        else foo12Up tail
    |[] -> 1

let culcNumbers n =
    let rec loop n sum =
        if n <= 0 then sum
        else 
            let nextSum = sum + (n % 10)
            let nextN = n / 10
            loop nextN nextSum
    loop n 0

let foo21 list pred func =
    let rec loop list pred func l =
        match list with
        |head::tail ->
            let nextL = l @ [func head]
            if pred head then loop tail pred func nextL
            else loop tail pred func l
        |[] -> l
    loop list pred func []


let rec foo22 n pred acc =      
        if n = 0 then acc
        else 
            let nextAcc = [n % 10] @ acc
            let nextN = n / 10
            if pred (n % 10) then foo22 nextN pred nextAcc
            else foo22 nextN pred acc

let foo3 list =
    let rec loop list modList=
        match list with
        |head::tail ->
            let rec subLoop value count subList=
                match count with
                |count when count <> 0 ->
                    let nextSubList = subList @ [value]
                    let nextCount = count - 1
                    subLoop value nextCount nextSubList
                |count -> subList
            let nextModList = modList @ subLoop (fst head) (snd head) []
            loop tail nextModList
        |[] -> modList
    loop (list |> List.countBy id |> List.sortByDescending snd) []

let isPrime n =
    let rec loop n div counter =
        if div = 0 then counter = 2
        else if n = 1 then true
        else 
            let nextCounter = counter + if n % div = 0 then 1 else 0
            loop n (div - 1) nextCounter
    loop n n 0

let findAllPrimes n = 
    let rec loop n div list =
        if div = 0 then list
        else 
            let nextList = list @ [div]
            if  n % div = 0 && isPrime div then loop n (div - 1) nextList
            else loop n (div - 1) list
            
    loop n n []

let foo4 list = List.distinct (List.collect (fun i -> i ) (List.map (fun i -> findAllPrimes i) list))
   

[<EntryPoint>]
let main argv = 
    //printfn "%A" (foo21 [12;-10;23;-434] (fun i -> i > 0) culcNumbers)
    //printfn "%A" (foo12Down (foo22 185122 (fun i -> i % 2 = 0) []))
    //printfn "%A" (foo3 [5;6;2;2;3;3;3;5;5;5])
    printfn "%A" (foo4 [100;95;44;33;25])
    0 

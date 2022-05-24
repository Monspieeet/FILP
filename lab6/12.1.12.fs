open System

let rec readlist n = 
    if n = 0 then []
    else 
    let head = Console.ReadLine()|>Convert.ToInt32
    let tail = readlist (n-1)
    head::tail

let rec writelist = function 
    []->()
    |(head:int)::tail -> 
                System.Console.WriteLine(head)
                writelist tail

let findmax list = 
    let rec findmax1 list curmax maxid curid = 
        match list with
        |[]->(maxid, curmax)
        |h::t ->
            let newmax = if h>curmax then h else curmax 
            let newmaxid = if h>curmax then curid else maxid 
            let newid = curmax + 1 
            findmax1 t newmax newmaxid newid
    findmax1 list list.Head 0 0

let finmin list = 
    let rec finmin1 list curmin minid curid = 
        match list with 
        |[]->(minid, curmin)
        |h::t ->
            let newmin = if h<curmin then h else curmin 
            let newminid = if h < curmin then curid else minid
            let newid = curid + 1
            finmin1 t newmin newminid newid
    finmin1 list list.[0] 0 0

let reverse list = 
    let rec rev1 list newlist=
        match list with 
        |[]->newlist 
        |h::t->
            let newlist1 = [h] @ newlist 
            rev1 t newlist1 
    rev1 list []
       
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|>Int32.Parse
    let list = readlist n 
    Console.WriteLine()
    let max= fst (findmax list)
    let min= fst (finmin list)
    let start = Math.Min(max,min)
    let endpoint=Math.Max(min,max)
    let piece=list.[start+1..endpoint-1]
    let result= list.[0..start]@ (reverse piece) @ list.[endpoint..n-1]
    writelist(result)
    0 // return an integer exit code

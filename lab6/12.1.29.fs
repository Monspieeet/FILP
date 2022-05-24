let rec readlist n = 
    if n = 0 then []
    else 
    let head = Console.ReadLine()|>Convert.ToInt32
    let tail = readlist (n-1)
    head::tail

let readdata = 
    Console.WriteLine("Введите размер списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readlist n

let rec writeList = function //длина списка and write
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  

let Indmax list = 
    let rec Indmax2 list max indM indEl = 
        match list with 
        |[]->(max)
        |h::tail->
            let newMax = if h>=max then h else max 
            let newInd = if h>max then indEl else indM
            Indmax2 tail newMax newInd (indEl+1)
    Indmax2 list list.Head 0 0

[<EntryPoint>]
let main argv =
    let list=readdata 
    Console.WriteLine("Введите значение начала и конца интервала")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    let b=System.Convert.ToInt32(System.Console.ReadLine())
    let max= Indmax list
    Console.WriteLine("Максимум={0} ",max)
    if(max>a && max<b) then Console.WriteLine("Принадлежит")
    else Console.WriteLine("Не принадлежит")
    0 // return an integer exit code

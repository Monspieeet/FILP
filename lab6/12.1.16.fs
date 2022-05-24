open System

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

let IndMax list = //first max
    let rec IndMax2 list max indM indEl = 
        match list with 
        |[]->(indM, max)
        |h::t->
            let newMax = if h>=max then h else max 
            let newInd = if h>=max then indEl else indM
            IndMax2 t newMax newInd (indEl+1)
    IndMax2 list list.Head 0 0

let IndMax2 list max = 
    let rec newIndmax2 list max max2 IndM2 indEl = 
        match list with 
        |[]->(IndM2,max2)
        |h::t->
            let newmax = if (h>max2 && h<>max) then h else max2
            let newmaxid = if (h>max && h<>max) then indEl else IndM2
            newIndmax2 t max newmax newmaxid (indEl+1)
    newIndmax2 list max list.Head 0 0 

[<EntryPoint>]
let main argv =
    let list=readdata 
    let maxel=snd (IndMax list)
    let max1ind=fst (IndMax list)
    let max2el=snd (IndMax2 list maxel)
    let max2ind=fst (IndMax2 list maxel)
    Console.WriteLine("Первый максимум:{0} ",maxel)
    Console.WriteLine("Второй максимум:{0} ",max2el)
    let start=Math.Min(max1ind,max2ind)
    let finish=Math.Max(max1ind,max2ind)
    Console.WriteLine("Получившийся список из элементов, расположенных между первым и вторым максимальным: ")
    let answ=list.[start+1..finish-1]      //выбор элементов
    writeList(answ)
    0 // return an integer exit code

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

let count list a b=
   let rec count2 list a b init=
    match list with
    |[]->init
    |h::t->
         if(h>=a && h<=b) then 
         count2 t a b init+1
         else 
         count2 t a b init
   count2 list a b 0

[<EntryPoint>]
let main argv =
    let list=readdata 
    Console.WriteLine("Ввести значение начала и конца отрезка")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    let b=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Количество элементов,принадлежащих этому отрезку:{0}", count list a b)
    0 // return an integer exit code

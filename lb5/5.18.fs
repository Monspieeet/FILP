open System
//a
let rec nod a b = 
    if(a>0 && b>0)
    then if(a>b)
          then nod (a%b) b
          else nod a (b%a)
    else if (a = 0)
        then b 
        else a 

let proc x f init = 
    let rec proc x f init current = 
        if current = 0 then init
        else
            let newInit = if nod x current = 1 then f init current
                          else init
            let newCurrent = current - 1
            proc x f newInit newCurrent
    proc x f init x

let euler x = 
    proc x (fun x y-> x+1) 0
    
    [<EntryPoint>]
let main argv =
    let num = 11
    //printfn "%b" (10 = Eiler  num)
    Console.WriteLine(4 = euler 10)
    0

//b
let sumb x = 
    let rec sumb x sum=
        if x  =0 then sum 
        else 
            if x%10%3 = 0 then 
                let sum1 = sum+x%10
                let x1 = x/10
                sumb x1 sum1
            else
                let x1 = x/10
                sumb x1 sum 
    sumb x 0
    
    [<EntryPoint>]
let main argv =
    let num = 11
    //printfn "%b" (10 = Eiler  num)
    Console.WriteLine(4 = euler 10)
    printf"%b" (3+6 = sumb 123456)
    printf"%b" (3 = maxp 12)
    0
    
 //c
 let countPrime1 x div = 
    let rec CountPrime x del count = 
        if x = 0 then count
        else 
            if nod (x%10) del = 1 then //взаимно-простые
                let x = x/10
                let count = count + 1
                CountPrime x del count
            else 
                let x = x/10
                CountPrime x del count
    CountPrime x div 0

let maxp x = 
    let rec maxp1 x del maxCount maxdel = 
        if del = 0 then maxdel
        else 
            if countPrime1 x del > maxCount && x%del=0 then
                let maxCount = countPrime1 x del    
                let maxCount1 = maxCount
                let CurDiv = del
                maxp1 x (del-1) maxCount CurDiv
            else 
                maxp1 x (del-1) maxCount maxdel
    maxp1 x x 0 0

[<EntryPoint>]
let main argv =
    printf"%b" (3 = maxp 12)
    0

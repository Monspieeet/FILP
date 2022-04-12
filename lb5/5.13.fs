open System
let rec Up n =
    if n=0 then 1
    else (n%10)*Up(n/10)

let ProzTail n =
    let rec PT n pr =
        if n=0 then pr
        else 
          let newPr =pr*(n%10)
          let newn=n/10
          PT newn newPr
    PT n 1

let rec MinimUp n=
    if n<10 then n
    else 
        if MinimUp(n/10)<n%10 then MinimUp(n/10)
        else n%10

let MinimTail n=
    let rec MT n min =
        if n=0 then min
        else 
            if min>n%10 then (MT (n/10)(n%10))
            else MT (n/10) min
    MT n 10

let rec MaximUp n=
    if n<10 then n
    else 
        if MaximUp(n/10)>n%10 then MaximUp(n/10)
        else n%10

let MaximTail n=
    let rec MaxT n max=
        if n=0 then max
        else if n%10>max then MaxT (n/10)(n%10)
            else MaxT(n/10)max
    MaxT n 0

[<EntryPoint>]
let main argv =
   let n = Convert.ToInt32(Console.ReadLine())
   Console.WriteLine( Up n)
   Console.WriteLine( ProzTail n)
   Console.WriteLine( MinimUp n)
   Console.WriteLine( MinimTail n)
   Console.WriteLine( MaximUp n)
   Console.WriteLine( MaximTail n)
   0

open System

let rec nod a b = 
    if(a>0 && b>0)
    then if(a>b)
          then nod (a%b) b
          else nod a (b%a)
    else if (a = 0)
        then b 
        else a 

let rec ref n fec init known =
    let unnown = known - 1 
    if (known = 0) then init 
    else if ((nod n known) = 1)
    then 
        let Ninit = (f init known)
        ref n fec Ninit unnown 
    else ref n fec init unnown

let fz n fec init = 
    ref n fec init (n-1)

let Eiler n = 
    fz n (fun x y -> x+1) 0



[<EntryPoint>]
let main argv =
    let num = 11
    printfn "%b" (10 = Eiler  num)
    printfn "%b" (1+2+3+4+5+6+7+8+9+10 = fz num (fun x y -> x+y) 0)
    printfn "%b" (1*2*3*4*5*6*7*8*9*10 = fz num (fun x y -> x*y) 1)
    0 // return an integer exit code

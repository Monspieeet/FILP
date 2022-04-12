open System

[<EntryPoint>]
let main argv =
   let otvet (otvet:string) =
        match otvet.Trim() with
            |"F#"|"Prolog" -> printfn "Подлиза"
            |"python"-> printfn "ах ты разбивник!"
            |other -> printfn "иди другой дорогой, сталкер"
    
   printfn "Ты че, программист?"
   //суперпозиция
   (Console.ReadLine>>otvet>>Console.WriteLine)()
   //каррирование
   let f otvet func out = out(func(otvet()))
   f Console.ReadLine otvet Console.WriteLine 
   0 

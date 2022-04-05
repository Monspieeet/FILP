open System
let otvet otvet =
    match otvet with
      |"F#"|"Prolog" -> printfn "Подлиза"
      |"python"-> printfn "ах ты разбивник!"
      |other -> printfn "иди другой дорогой, сталкер"

[<EntryPoint>]
let main argv =
   printfn "Ты че, программист?"
   let yaz = Console.ReadLine()

   otvet yaz
   0

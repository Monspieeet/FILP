man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

children(X):-parent(X,Y),write(Y),nl,fail.
mother(X,Y):-parent(X,Y),woman(X),nl,fail.
mother(X):-parent(Y,X),woman(Y),write(Y),nl,fail.
brother(X,Y):-parent(Z,X),parent(Z,Y),man(Z),man(X).
brother(X):-parent(Z,X),parent(Z,Y),man(Z),man(Y),write(Y),nl,fail.
grand_pa(X,Y):-parent(X,Z),parent(Z,Y),man(X).
grand_pa(X):-parent(Y,Z),parent(Z,X),man(Y),write(Y),nl,fail.

%11
son(X,Y):-parent(Y,X),man(X).
son(X):-parent(X,Y),man(Y),write(Y),nl,fail.
%12
sister(X,Y):-woman(Y),parent(Z,X),parent(Z,Y),!.
sisters(X):-sister(X,Y),write(Y),nl,fail.

%13
grand_ma(X,Y):-parent(X,Z),parent(Z,Y),woman(X),!.
grand_mas(X):-grand_ma(Y,X),write(Y),nl,fail.

%14
grand_ma_and_da(X,Y):-(
    parent(X,Z),parent(Z,Y),man(X),woman(Y);
    parent(Y,Z),parent(Z,X),man(Y),woman(X)).
    
%15
max(X,X):-X<10,!.
max(X,M):-
    X1 is X div 10,
    X2 is X mod 10,

max(X1,M1),
(X2<M1, M is M1; M is X2).

%16
maxdown(X,Max):-maxdown(X,0,Max).
maxdown(0,Max,Max):-!.
maxdown(X,C,Max):-
    X1 is X div 10,
    D1 is X mod 10,
    D1>C, !,
    maxdown(X1,D1,Max);
    X2 is X div 10,
    maxdown(X2,C,Max).
    
%17
sm(0,0):-!.
sm(X,Y):-X1 is X mod 10, X2 is X div 10,sm(X2,Y1),Y is Y1+X1,
    0 is X1 mod 3,!.
sm(X,Y):-X2 is X div 10,sm(X2,Y).

%18
sum(X,R):-sum(X,0,R).
sum(0,T,T):-!.
sum(X,P,R):-D is X mod 10,
    0 is D mod 3,
    P1 is (D+P),
    X1 is X div 10,
    sum(X1,P1,R);
    X2 is X div 10,
    sum(X2,P,R).
    
%19
fib(1,1).
fib(0,0).
fib(X,Y):-
    X>1,X1 is X-1,
    X2 is X-2,
    fib(X1,Y1),
    fib(X2,Y2),
    Y is Y1+Y2.
    
%20
fib1(N,X):-fib1(0,1,1,N,X).
 fib1(_,Res,N,N,Res):-!.
fib1(X1,X2,I,N,Res):-
    X is X1+X2,
    I1 is I+1,
    fib1(X1,X,I1,N,Res).
    

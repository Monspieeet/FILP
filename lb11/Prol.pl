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

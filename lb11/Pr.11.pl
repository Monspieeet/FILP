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
son(X,Y):-parent(Y,X),man(X).
son(X):-parent(X,Y),man(Y),write(Y),nl,fail.

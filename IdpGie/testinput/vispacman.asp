sq(68).
idpd_polygon(field, array( point(0, 0),point(14*S, 0),point(14*S, 9*S), point(0, 9*S))) :- sq(S).
idpd_show(field).
idpd_xpos(field,S) :- sq(S).
idpd_ypos(field,S) :- sq(S).
idpd_color(field, 200, 200, 200).
idpd_depth(field, -15).


idpd_polygon(score, array( point(0, 0), point(4*S, 0), point(4*S, S), point(0, S))) :- sq(S).
idpd_xpos(score, S) :- sq(S).
idpd_ypos(score, S) :- sq(S).
idpd_color(score, 158, 220, 107).
idpd_depth(score, -12).
idpd_text(score, "Score").
idpd_show(score).
idpd_polygon(score2, array(point(0, 0), point(2*S, 0), point(2*S, S), point(0, S))) :- sq(S).
idpd_xpos(score2, 5*S) :- sq(S).
idpd_ypos(score2, S) :- sq(S).
idpd_color(score2, 158, 220, 107).
idpd_depth(score2, -12).
idpd_text_t(score2, "X", T) :- score(T, X).
idpd_show(score2).


idpd_image(player, "mondopenr", S, S) :- player(X, Y), sq(S).
idpd_xpos(player, Y*S+1+2*S) :- player(X,Y), sq(S).
idpd_ypos(player, X*S+1+2*S) :- player(X,Y), sq(S).
idpd_depth(player, -7) :- player(X,Y).
idpd_show(player).


idpd_ellipse(gold(X,Y), S/5, S/2) :- gold(X,Y), sq(S).
idpd_show(gold(X,Y)) :- gold(X,Y), sq(S).
idpd_xpos(gold(X, Y), Y*S+S/3+2*S) :- gold(X,Y), sq(S).
idpd_ypos(gold(X,Y), X*S+S/5+2*S) :- gold(X,Y), sq(S).
idpd_color(gold(X,Y), 167, 136, 47) :- gold(X,Y).
idpd_depth(gold(X,Y), -9) :- gold(X,Y).

idpd_polygon(teleport(X, Y), array(point(0, 0), point(0, S/2),point(S/2, S/2), point(S/2, 0))) :- teleport(X, Y), sq(S).
idpd_show(teleport(X, Y)) :- teleport(X, Y).
idpd_xpos(teleport(X,Y), Y*S+S/2+2*S) :- teleport(X,Y), sq(S).
idpd_ypos(teleport(X,Y), X*S+S/2+2*S) :- teleport(X,Y), sq(S).
idpd_color(teleport(X,Y), 158, 210, 107) :- teleport(X,Y).
idpd_depth(teleport(X,Y), -8) :- teleport(X,Y).
idpd_text(teleport(X,Y), "T") :- teleport(X,Y).

idpd_foo(bar).


idpd_polygon(square(X, Y), array(point(0, 0), point(0, S), point(S, S),point(S, 0))) :- square(X, Y), sq(S).
idpd_xpos(square(X, Y), Y*S+2*S) :- square(X, Y), sq(S).
idpd_ypos(square(X, Y), X*S+2*S) :- square(X, Y), sq(S).
idpd_pencolor(square(X, Y), 158, 173, 107) :- square(X, Y).
idpd_color(square(X, Y), 158, 210, 107) :- square(X, Y).
idpd_depth(square(X, Y), -10) :- square(X, Y).
idpd_show(square(X,Y)) :- square(X, Y).

idpd_polygon(wall(X, Y, "l"), array(point(0,0),point(0,S))) :- walls(X, Y, "l"), sq(S).
idpd_xpos(wall(X, Y, "l"), Y*S+2*S) :- walls(X, Y, "l"), sq(S).
idpd_ypos(wall(X, Y, "l"), X*S+2*S) :- walls(X, Y, "l"), sq(S).

idpd_polygon(wall(X, Y, "r"), array(point(0,0),point(0,S))) :- walls(X, Y, "r"), sq(S).
idpd_xpos(wall(X, Y, "r"), (Y+1)*S+2*S) :- walls(X, Y, "r"), sq(S).
idpd_ypos(wall(X, Y, "r"), X*S+2*S) :- walls(X, Y, "r"), sq(S).

idpd_polygon(wall(X, Y, "d"), array(point(0,0),point(S,0))) :- walls(X, Y, "d"), sq(S).
idpd_xpos(wall(X, Y, "d"), Y*S+2*S) :- walls(X, Y, "d"), sq(S).
idpd_ypos(wall(X, Y, "d"), (X+1)*S+2*S) :- walls(X, Y, "d"), sq(S).

idpd_polygon(wall(X, Y, "u"), array(point(0,0),point(S,0))) :- walls(X, Y, "u"), sq(S).
idpd_xpos(wall(X, Y, "u"), Y*S+2*S) :- walls(X, Y, "u"), sq(S).
idpd_ypos(wall(X, Y, "u"), X*S+2*S) :- walls(X, Y, "u"), sq(S).

idpd_depth(wall(X, Y, D), -5):- walls(X, Y, D).
idpd_show(wall(X, Y, D)):- walls(X, Y, D).
idpd_color(wall(X, Y, D), 0, 0, 255):- walls(X, Y, D).

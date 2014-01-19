sq(1000).
idpd_polygon(4, field, 0, 0, 14*S, 0, 14*S, 9*S, 0, 9*S) :- sq(S).
idpd_xpos(field, -S) :- sq(S).
idpd_ypos(field, -S) :- sq(S).
idpd_color(field, 200, 200, 200).
idpd_depth(field, 15).


idpd_polygon(4, score, 0, 0, 4*S, 0, 4*S, S, 0, S) :- sq(S).
idpd_xpos(score, -S) :- sq(S).
idpd_ypos(score, -S) :- sq(S).
idpd_color(score, 158, 220, 107).
idpd_depth(score, 12).
idpd_text(score, "Score").
idpd_polygon(4, score2, 0, 0, 2*S, 0, 2*S, S, 0, S) :- sq(S).
idpd_xpos(score2, 3*S) :- sq(S).
idpd_ypos(score2, -S) :- sq(S).
idpd_color(score2, 158, 220, 107).
idpd_depth(score2, 12).
idpd_text_t(T, score2, X) :- score(T, X).


idpd_image_t(T, player, monddichtl, S, S) :- player(T,X, Y), (T #mod 2) == 0, sq(S).
idpd_image_t(T, player, monddichtl, S, S) :- player(T,X, Y), end(T2), T>T2, sq(S).
idpd_image_t(T, player, monddichtu, S, S) :- player(T,X, Y), (T #mod 2) == 0, sq(S), move(T-1, u).
idpd_image_t(T, player, mondopenu, S, S) :- player(T,X, Y), (T #mod 2) == 1, sq(S), move(T-1, u).
idpd_image_t(T, player, monddichtd, S, S) :- player(T,X, Y), (T #mod 2) == 0, sq(S), move(T-1, d).
idpd_image_t(T, player, mondopend, S, S) :- player(T,X, Y), (T #mod 2) == 1, sq(S), move(T-1, d).
idpd_image_t(T, player, monddichtr, S, S) :- player(T,X, Y), (T #mod 2) == 0, sq(S), move(T-1, r).
idpd_image_t(T, player, mondopenr, S, S) :- player(T,X, Y), (T #mod 2) == 1, sq(S), move(T-1, r).
idpd_image_t(T, player, monddichtl, S, S) :- player(T,X, Y), (T #mod 2) == 0, sq(S), move(T-1, l).
idpd_image_t(T, player, mondopenl, S, S) :- player(T,X, Y), (T #mod 2) == 1, sq(S), move(T-1, l).
idpd_xpos_t(T, player, Y*S+1) :- player(T,X,Y), sq(S).
idpd_ypos_t(T, player, X*S+1) :- player(T,X,Y), sq(S).
idpd_depth_t(T, player, 7) :- player(T,X,Y).


idpd_ellipse_t(T, gold, X, Y, S/5, S/2) :- gold(T,X,Y), sq(S).
idpd_xpos_t(T, gold, X, Y, Y*S+S/3) :- gold(T,X,Y), sq(S).
idpd_ypos_t(T, gold, X, Y, X*S+S/5) :- gold(T,X,Y), sq(S).
idpd_color_t(T, gold, X, Y, 167, 136, 47) :- gold(T,X,Y).
idpd_depth_t(T, gold, X, Y, 9) :- gold(T,X,Y).

idpd_polygon(4, teleport, X, Y, 0, 0, 0, S/2, S/2, S/2, S/2, 0) :- teleport(X, Y), sq(S).
idpd_xpos(teleport,X,Y, Y*S+S/2) :- teleport(X,Y), sq(S).
idpd_ypos(teleport,X,Y, X*S+S/2) :- teleport(X,Y), sq(S).
idpd_color(teleport,X,Y, 158, 210, 107) :- teleport(X,Y).
idpd_depth(teleport,X,Y, 8) :- teleport(X,Y).
idpd_text(teleport,X,Y, "T") :- teleport(X,Y).


idpd_polygon(4, square, X, Y, 0, 0, 0, S, S, S, S, 0) :- square(X, Y), sq(S).
idpd_xpos(square, X, Y, Y*S) :- square(X, Y), sq(S).
idpd_ypos(square, X, Y, X*S) :- square(X, Y), sq(S).
idpd_pencolor(square, X, Y, 158, 173, 107) :- square(X, Y).
idpd_color(square, X, Y, 158, 210, 107) :- square(X, Y).
idpd_depth(square, X, Y, 10) :- square(X, Y).


idpd_depth(wall, X, Y, D, 5):- walls(X, Y, D).
idpd_color(wall, X, Y, D, 0, 0, 255):- walls(X, Y, D).

idpd_polygon(2, wall, X, Y, l, 0,0,0,S) :- walls(X, Y, l), sq(S).
idpd_xpos(wall, X, Y, l, Y*S) :- walls(X, Y, l), sq(S).
idpd_ypos(wall, X, Y, l, X*S) :- walls(X, Y, l), sq(S).

idpd_polygon(2, wall, X, Y, r, 0,0,0,S) :- walls(X, Y, r), sq(S).
idpd_xpos(wall, X, Y, r, (Y+1)*S) :- walls(X, Y, r), sq(S).
idpd_ypos(wall, X, Y, r, X*S) :- walls(X, Y, r), sq(S).

idpd_polygon(2, wall, X, Y, d, 0,0,S,0) :- walls(X, Y, d), sq(S).
idpd_xpos(wall, X, Y, d, Y*S) :- walls(X, Y, d), sq(S).
idpd_ypos(wall, X, Y, d, (X+1)*S) :- walls(X, Y, d), sq(S).

idpd_polygon(2, wall, X, Y, u, 0,0,S,0) :- walls(X, Y, u), sq(S).
idpd_xpos(wall, X, Y, u, Y*S) :- walls(X, Y, u), sq(S).
idpd_ypos(wall, X, Y, u, X*S) :- walls(X, Y, u), sq(S).
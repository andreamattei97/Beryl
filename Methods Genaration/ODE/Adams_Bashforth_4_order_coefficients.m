%generates the Adam-Bashfort 4th order coefficients with variable step
%it uses the Symbolic Math Toolbox
clear all
x = sym('x');

h1=sym('h1'); %h(n)
h2=sym('h2'); %h(n-1)
h3=sym('h3'); %h(n-2)
h4=sym('h4'); %h(n-3)

x1 = sym ('x1'); %x(n)
x2 = x1-h2;      %x(n-1)
x3 = x2-h3;      %x(n-2)
x4 = x3-h4;      %x(n-3)

v_x=[x1 x2 x3 x4]; %abscissas of the previous points

y1 = sym('y1'); %y(n)
y2 = sym('y2'); %y(n-1)
y3 = sym('y3'); %y(n-2)
y4 = sym('y4'); %y(n-3)

v_y=[y1 y2 y3 y4]; %ordinates of the previous points

interp_polynomial=0; %the interpolating polynomial of the previous point generated as a lagrange polynomial

for i=1:4
   term=v_y(i);
   for j=1:4
      if i~=j 
          term=term*(x-v_x(j))/(v_x(i)-v_x(j));
      end
   end
   interp_polynomial= interp_polynomial+term;
end

raw_formula=y1+int(interp_polynomial,x,[x1 x1+h1]); %not simplified formula
formula=simplify(raw_formula) %the final formula

%test of the validity of the formula using an uniform step (uniform step=standard 4th order method)
uniform_formula=subs(formula,h2,h1);
uniform_formula=subs(uniform_formula,h3,h1);
uniform_formula=subs(uniform_formula,h4,h1);
%simplifies the formula with uniform steps
simplify(uniform_formula)
%coefficients of the uniform 4th order method: 55/24; -59/24; 37/24; -9/24

%note the following formula is the one adapted to c# and used in the
%project (where the power operator don't exist)
%formula= (6 * (h1 * h1) * (h2 * h2) * (h3 * h3 * h3) * y3 - 6 * (h1 * h1) * (h2 * h2) * (h4 * h4 * h4) * y2 + 12 * (h1 * h1) * (h2 * h2 * h2) * (h3 * h3) * y3 - 12 * (h1 * h1) * (h2 * h2 * h2) * (h4 * h4) * y2 + 6 * (h1 * h1) * (h3 * h3) * (h4 * h4 * h4) * y1 + 12 * (h1 * h1) * (h3 * h3 * h3) * (h4 * h4) * y1 + 12 * (h1 * h1 * h1) * (h2 * h2) * (h3 * h3) * y3 - 12 * (h1 * h1 * h1) * (h2 * h2) * (h4 * h4) * y2 + 12 * (h1 * h1 * h1) * (h3 * h3) * (h4 * h4) * y1 + 36 * (h2 * h2) * (h3 * h3) * (h4 * h4) * y1 - 6 * (h1 * h1) * (h2 * h2) * (h3 * h3 * h3) * y4 + 6 * (h1 * h1) * (h2 * h2) * (h4 * h4 * h4) * y3 - 12 * (h1 * h1) * (h2 * h2 * h2) * (h3 * h3) * y4 + 12 * (h1 * h1) * (h2 * h2 * h2) * (h4 * h4) * y3 - 6 * (h1 * h1) * (h3 * h3) * (h4 * h4 * h4) * y2 - 12 * (h1 * h1) * (h3 * h3 * h3) * (h4 * h4) * y2 - 12 * (h1 * h1 * h1) * (h2*h2) * (h3*h3) * y4 + 12 * (h1*h1*h1) * (h2*h2) * (h4*h4) * y3 - 12 * (h1*h1*h1) * (h3*h3) * (h4*h4) * y2 + 12 * h2 * (h3*h3*h3*h3) * h4 * y1 + 12 * h2 * (h3*h3) * (h4*h4*h4) * y1 + 24 * h2 * (h3*h3*h3) * (h4*h4) * y1 + 6 * (h1*h1) * (h2*h2*h2*h2) * h3 * y3 - 6 * (h1*h1) * (h2*h2*h2*h2) * h4 * y2 + 6 * (h1*h1) * (h3*h3*h3*h3) * h4 * y1 + 4 * (h1*h1*h1) * h2 * (h3*h3*h3) * y3 - 4 * (h1*h1*h1) * h2 * (h4*h4*h4) * y2 + 4 * (h1*h1*h1) * h3 * (h4*h4*h4) * y1 + 8 * (h1*h1*h1) * (h2*h2*h2) * h3 * y3 - 8 * (h1*h1*h1) * (h2*h2*h2) * h4 * y2 + 8 * (h1*h1*h1) * (h3*h3*h3) * h4 * y1 + 12 * (h2*h2) * h3 * (h4*h4*h4) * y1 + 24 * (h2*h2) * (h3*h3*h3) * h4 * y1 + 3 * (h1*h1*h1*h1) * h2 * (h3*h3) * y3 - 3 * (h1*h1*h1*h1) * h2 * (h4*h4) * y2 + 3 * (h1*h1*h1*h1) * h3 * (h4*h4) * y1 + 3 * (h1*h1*h1*h1) * (h2*h2) * h3 * y3 - 3 * (h1*h1*h1*h1) * (h2*h2) * h4 * y2 + 3 * (h1*h1*h1*h1) * (h3*h3) * h4 * y1 + 12 * (h2*h2*h2) * h3 * (h4*h4) * y1 + 12 * (h2*h2*h2) * (h3*h3) * h4 * y1 - 6 * (h1*h1) * (h2*h2*h2*h2) * h3 * y4 + 6 * (h1*h1) * (h2*h2*h2*h2) * h4 * y3 - 6 * (h1*h1) * (h3*h3*h3*h3) * h4 * y2 - 4 * (h1*h1*h1) * h2 * (h3*h3*h3) * y4 + 4 * (h1*h1*h1) * h2 * (h4*h4*h4) * y3 - 4 * (h1*h1*h1) * h3 * (h4*h4*h4) * y2 - 8 * (h1*h1*h1) * (h2*h2*h2) * h3 * y4 + 8 * (h1*h1*h1) * (h2*h2*h2) * h4 * y3 - 8 * (h1*h1*h1) * (h3*h3*h3) * h4 * y2 - 3 * (h1*h1*h1*h1) * h2 * (h3*h3) * y4 + 3 * (h1*h1*h1*h1) * h2 * (h4*h4) * y3 - 3 * (h1*h1*h1*h1) * h3 * (h4*h4) * y2 - 3 * (h1*h1*h1*h1) * (h2*h2) * h3 * y4 + 3 * (h1*h1*h1*h1) * (h2*h2) * h4 * y3 - 3 * (h1*h1*h1*h1) * (h3*h3) * h4 * y2 + 12 * h1 * h2 * (h3*h3) * (h4*h4*h4) * y1 + 24 * h1 * h2 * (h3*h3*h3) * (h4*h4) * y1 + 12 * h1 * (h2*h2) * h3 * (h4*h4*h4) * y1 + 24 * h1 * (h2*h2) * (h3*h3*h3) * h4 * y1 + 12 * h1 * (h2*h2*h2) * h3 * (h4*h4) * y1 + 12 * h1 * (h2*h2*h2) * (h3*h3) * h4 * y1 + 12 * (h1*h1) * h2 * h3 * (h4*h4*h4) * y1 + 24 * (h1*h1) * h2 * (h3*h3*h3) * h4 * y1 + 12 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y1 + 12 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y1 - 12 * (h1*h1) * h2 * h3 * (h4*h4*h4) * y2 - 24 * (h1*h1) * h2 * (h3*h3*h3) * h4 * y2 - 24 * (h1*h1) * (h2*h2*h2) * h3 * h4 * y2 - 24 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y2 - 24 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y2 - 24 * (h1*h1*h1) * (h2*h2) * h3 * h4 * y2 + 24 * (h1*h1) * (h2*h2*h2) * h3 * h4 * y3 + 12 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y3 + 12 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y3 + 24 * (h1*h1*h1) * (h2*h2) * h3 * h4 * y3 + 36 * h1 * (h2*h2) * (h3*h3) * (h4*h4) * y1 + 36 * (h1*h1) * h2 * (h3*h3) * (h4*h4) * y1 + 18 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y1 + 18 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y1 - 36 * (h1*h1) * h2 * (h3*h3) * (h4*h4) * y2 - 36 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y2 - 36 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y2 + 18 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y3 + 18 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y3 + 12 * h1 * h2 * (h3*h3*h3*h3) * h4 * y1 - 6 * (h1*h1*h1*h1) * h2 * h3 * h4 * y2 + 6 * (h1*h1*h1*h1) * h2 * h3 * h4 * y3) / (12 * h2 * h3 * h4 * (h2 + h3) * (h3 + h4) * (h2 + h3 + h4));



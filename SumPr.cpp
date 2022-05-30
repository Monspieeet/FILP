#include <iostream>
#include <math.h>
#include <cmath>
using namespace std;

typedef double(*pointFunc)(double);

double f(double x) 
{
    return x*x - 7;
}

double rectangle_integral(pointFunc f, double a, double x, int n)
{
    double h;
    double sum = 0.0;
    double fx;
    h = (x - a) / n;  //шаг

    for (int i = 0; i < n; i++) {
        x = a + i * h;
        fx = f(x);
        sum += fx;
    }
    return (sum * h); //приближенное значение интеграла равно сумме площадей прямоугольников 
}
int main() 
{
    setlocale(LC_ALL, "Russian");
    double a, b, eps,x;
    double s1, s;
    int n = 1; //начальное число шагов

    cout << "Введите a = ";
    cin >> a;
    cout << "Введите x = ";
    cin >> x;
    cout << "Введите b = ";
    cin >> b;
    cout << "Введите требуемую точность eps = ";
    cin >> eps;

    double x1, x2;
    double y, res;
    x1 = a;
    x2 = x;
    do
    {
        y = x1;
        res = x2 - ((x2 - x1) / ((f(x2)-b) - (f(x1)-b))) * (f(x2)-b);
        x1 = x2;
        x2 = res;
    } while (fabs(y - res) >= eps);
    s1 = rectangle_integral(f, a, res, n); //первое приближение для интеграла
    do {
        s = s1;     //второе приближение
        n = 2 * n;  //увеличение числа шагов в два раза, т.е. уменьшение значения шага в два раза
        s1 = rectangle_integral(f, a, res, n);
    } while (fabs(s1 - s) > eps);  //сравнение приближений с заданной точностью
    cout << "Результат = " << s1 << endl;
}

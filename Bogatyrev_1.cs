using System;
/*
Реализован полный функционал из тз(+, -, *, /,%, 1/x, x^2, корень квадратный из x, M+, M-, MR.
) + функция exit для завершения работы калькулятора
Так же реализован обработчик ошибок(Введенн не тот тип данных, Деление на 0)
Возможные ошибки: Переполнение double
*/
class HelloWorld {
    static void Main() {
        bool exit = false;
        double result = 0.0;
        double memory = 0.0;

        while (!exit) {
            Console.WriteLine("Введите операцию: +, -, *, /, %, 1/x, x^2, sqrt(x), M+, M-, MR или exit");
            string op = Console.ReadLine();

            try {
                exit = (op == "exit");
                if (exit) break;

                if (op == "MR") {
                    Console.WriteLine($"Значение из памяти: {memory}");
                    continue;
                } else if (op == "M+") {
                    memory += result;
                    Console.WriteLine($"{result} добавлено в память. Текущее значение памяти: {memory}");
                    continue;
                } else if (op == "M-") {
                    memory -= result;
                    Console.WriteLine($"{result} удалено из памяти. Текущее значение памяти: {memory}");
                    continue;
                }

                Console.WriteLine("Введите первое число:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%") {
                    Console.WriteLine("Введите второе число:");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    if (op == "+") result = num1 + num2;
                    else if (op == "-") result = num1 - num2;
                    else if (op == "*") result = num1 * num2;
                    else if (op == "/") {
                        if (num2 == 0) throw new DivideByZeroException();
                        result = num1 / num2;
                        
                    }
                    else if (op == "%") {
                        if (num2 == 0) throw new DivideByZeroException();
                        result = num1 % num2;
                    }
                } else if (op == "1/x") {
                    if (num1 == 0) throw new DivideByZeroException();
                    result = 1 / num1;
                } else if (op == "x^2") {
                    result = num1 * num1;
                } else if (op == "sqrt(x)") {
                    result = Math.Sqrt(num1);
                } else {
                    Console.WriteLine("Неизвестная операция.");
                    continue;
                }

                Console.WriteLine($"Результат: {result}");
            } catch (Exception e) {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
